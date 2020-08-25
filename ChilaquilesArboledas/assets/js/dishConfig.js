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

                    let bodyContent = "<br/>";
                    bodyContent += "<div class='row'>";
                    bodyContent += " <div class='col-4'>";
                    bodyContent += "     <img src='" + headerImageUrl + "' alt='' width='90px' height='90px' />";
                    bodyContent += " </div>"
                    bodyContent += " <div class='col-8'>";
                    bodyContent += "     <h3 class='align-middle'>" + category.CategoryName + "</h3>";
                    bodyContent += " </div>";
                    bodyContent += "</div>";
                    bodyContent += "<br />";

                    for (var i = 0; i < category.DishesList[0].DishSectionsList.length; i++)
                    {
                        bodyContent += "<div class='row' style='background-color:silver'>"
                        bodyContent += "    <strong>" + category.DishesList[0].DishSectionsList[i].DishSectionName + "</strong>";
                        bodyContent += "</div>";

                        let sectionAllowMultipleOptions = category.DishesList[0].DishSectionsList[i].AllowMultipleOptions;
                        if (category.DishesList[0].DishSectionsList[i].DishComplementsList.length > 0)
                        {
                            let complementsList = category.DishesList[0].DishSectionsList[i].DishComplementsList;
                            for (var j = 0; j < complementsList.length; j++) {

                                let aditionalCost = complementsList[j].AditionalCost;

                                bodyContent += "<div class='row' style='background-color: white'>";
                                bodyContent += "	<table width='100%'>";
                                bodyContent += "		<tr>";
                                bodyContent += "			<td width='50%'>";

                                if (sectionAllowMultipleOptions)
                                {
                                    bodyContent += "<input type='checkbox' class='chkOption' />&nbsp;" + complementsList[j].DishComplementName;
                                }
                                else
                                {
                                    bodyContent += "<input type='radio' class='rbtOption' name='rbtSeccion" + category.DishesList[0].DishSectionsList[i].DishSectionId + "' />&nbsp;" + complementsList[j].DishComplementName;
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

                    console.log(bodyContent);

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