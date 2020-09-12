
let complementsArray = [];

$('#btnPlus').click(function (e)
{
    let quantity = parseFloat($('#spnQuantity').text());
    let dishPrice = parseFloat($('#hdfNewDishPrice').val());

    let newQuantity = quantity + 1;
    $('#spnQuantity').text(newQuantity);

    //let newDishPrice = dishPrice * newQuantity
    //$('#spnPrice').text(castToCurrency(newDishPrice));
});

$('#btnMinus').click(function (e)
{
    let quantity = parseFloat($('#spnQuantity').text());
    let dishPrice = parseFloat($('#hdfNewDishPrice').val());

    if (quantity > 1)
    {
        let newQuantity = quantity - 1;
        $('#spnQuantity').text(newQuantity);

        //let newDishPrice = dishPrice * newQuantity
        //$('#spnPrice').text(castToCurrency(newDishPrice));
    }
});

$('#btnAddToCart').click(function (e) {

    fillComplementsArray();

    let quantity = parseInt($('#spnQuantity').text());
    let dishIdentifier = parseInt($('#hdfDishIdentifier').val());

    $.ajax({
        type: "POST",
        url: "../Forms/DishConfig.aspx/CreateOrder",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "dishIdentifier": dishIdentifier, "complementsList": complementsArray, "quantity": quantity }),
        dataType: "json",
        success: function (response) {
            let data = response.d;
            if (data.Success) {

            }
            else {
                swal("Oops!", "No fue posible generar tu orden este momento, por favor intenta más tarde", "error");
            }
        },
        failure: function (xhr, textStatus, errorThrown) {
            
        }
    });
});

function fillComplementsArray()
{
    complementsArray.length = 0;

    $('.chkOption:checkbox:checked').each(function () {
        complementsArray.push($(this).data('complement'));
    });

    $('.rbtOption:radio:checked').each(function () {
        complementsArray.push($(this).data('complement'));
    });
}

function removeFromComplementsArray(value)
{
    const index = complementsArray.indexOf(value);
    if (index > -1) {
        complementsArray.splice(index, 1);
    }
}

function loadControlsByDishId(dishIdentifier)
{
    let filter = {
        'dishIdentifier': parseInt(dishIdentifier)
    };

    $.ajax({
        type: "POST",
        url: "../Forms/DishConfig.aspx/LoadControlsByDishId",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(filter),
        dataType: "json",
        success: function (response)
        {
            let categoryResponse = response.d;
            if (categoryResponse != undefined)
            {
                if (categoryResponse.Success)
                {
                    $('#divContent').empty();

                    let category = categoryResponse.Result;
                    let headerImageUrl = "../assets/images/" + category.CategoryImagePath;

                    //Cargo el hidden con el valor original del platillo
                    $('#hdfNewDishPrice').val(category.DishesList[0].DishPrice);

                    let bodyContent = "<br/>";
                    bodyContent += "<div class='row'>";
                    bodyContent += " <div class='col-4' style='text-align:center;'>";
                    bodyContent += "     <img src='" + headerImageUrl + "' alt='' width='90px' height='90px' />";
                    bodyContent += " </div>"
                    bodyContent += " <div class='col-8'>";
                    bodyContent += "     <h3 class='align-left'>" + category.CategoryName + "</h3>";
                    bodyContent += "     <span id='spnPrice'>" + castToCurrency(category.DishesList[0].DishPrice) + "</span>";
                    bodyContent += " </div>";
                    bodyContent += "</div>";
                    bodyContent += "<br />";
                    
                    for (var i = 0; i < category.DishesList[0].DishSectionsList.length; i++)
                    {
                        bodyContent += "<div class='row' style='background-color:silver; padding-top: 5px; padding-bottom: 5px; padding-left:5px'>"
                        bodyContent += "    <strong>" + category.DishesList[0].DishSectionsList[i].DishSectionName + "</strong>";
                        bodyContent += "</div>";

                        let sectionAllowMultipleOptions = category.DishesList[0].DishSectionsList[i].AllowMultipleOptions;
                        if (category.DishesList[0].DishSectionsList[i].DishComplementsList.length > 0)
                        {
                            let complementsList = category.DishesList[0].DishSectionsList[i].DishComplementsList;
                            for (var j = 0; j < complementsList.length; j++) {

                                let aditionalCost = complementsList[j].AditionalCost;

                                bodyContent += "<div class='row' style='background-color: white; padding-top: 5px;padding-bottom: 5px;'>";
                                bodyContent += "	<table width='100%'>";
                                bodyContent += "		<tr>";
                                bodyContent += "			<td width='50%' style='padding-left: 5px'>";

                                if (sectionAllowMultipleOptions)
                                {
                                    bodyContent += "<input type='checkbox' class='chkOption' value='" + aditionalCost + "' data-complement='" + complementsList[j].DishComplementId + "' />&nbsp;" + complementsList[j].DishComplementName;
                                }
                                else
                                {
                                    bodyContent += "<input type='radio' class='rbtOption' value='" + aditionalCost + "' data-complement='" + complementsList[j].DishComplementId + "'  name='rbtSeccion" + category.DishesList[0].DishSectionsList[i].DishSectionId + "' />&nbsp;" + complementsList[j].DishComplementName;
                                }

                                bodyContent += "				<br />";
                                bodyContent += "			</td>";
                                bodyContent += "			<td width='50%' style='text-align: right; padding-right: 5px'>";

                                if (complementsList[j].IsIncludedInOrder || parseInt(aditionalCost) == 0)
                                {
                                    bodyContent += "Sin costo adicional";
                                }
                                else
                                {
                                    bodyContent += castToCurrency(aditionalCost);
                                }

                                bodyContent += "			</td>";
                                bodyContent += "		</tr>";
                                bodyContent += "	</table>";
                                bodyContent += "</div>";
                            }
                        }
                    }
                    
                    //Agrego el armado del cuerpo al div principal
                    $('#divContent').append(bodyContent);
                    
                }
                else {
                    alert("No fue posible cargar esta página, por favor intente más tarde");
                }
            }
        },
        failure: function (xhr, textStatus, errorThrown) {
            console.log("Ocurrió un error al cargar la configuracion dinamica");
        }
    });
}