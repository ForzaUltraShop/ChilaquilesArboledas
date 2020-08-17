
function loadDishesByCategoryId(categoryId)
{
    let filter = {
        'categoryIdentifier': parseInt(categoryId)
    };

    $.ajax({
        type: "POST",
        url: "../Forms/Especiales.aspx/DishesGetByCategoryIdentifier",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(filter),
        dataType: "json",
        success: function (response) {
            let data = response.d;
            if (data != undefined) {
                if (data.Success) {
                    var list = data.Result.filter(item => item.IsActive);

                    $('#divContent').empty();
                    $.each(list, function (i, item) {

                        let imgSource = "../assets/images/" + list[i].DishImagePath;

                        let dishRow = "<div class='card' data-dish='" + list[i].DishIdentifier + "'>";
                        dishRow += "<div class='row '>";
                        dishRow += "<div class='col-md-3'>";
                        dishRow += "<div>";
                        dishRow += "<img class='d-block' src='" + imgSource + "' height='200px' width='250px' />";
                        dishRow += "</div>";
                        dishRow += "</div>";
                        dishRow += "<div class='col-md-9 px-3'>";
                        dishRow += "<div class='card-block px-6'>";
                        dishRow += "<h4 class='card-title'>" + list[i].DishName + "</h4>";
                        dishRow += "<p class='card-text'>" + list[i].DishDescription + "</p>";
                        //dishRow += "<br/>";
                        //categoryRow += "<a href='#' class='mt-auto btn btn-success'>Armálos como más te gusté</a>";
                        dishRow += "<p>Desde: " + castToCurrency(list[i].DishPrice) + "</p>"; 
                        dishRow += "</div>";
                        dishRow += "</div>";
                        dishRow += "</div>";
                        dishRow += "</div>";

                        $('#divContent').append(dishRow);

                        $('.card').off('click').on('click', function () {
                            let dishId = $(this).data('dish');
                            console.log('categoryId', dishId);
                            //window.location.replace('../Forms/Especiales?CategoryId=' + dishId);
                        });

                    });
                }
                else {
                    alert("No fue posible cargar el listado de platillos");
                }
            }
        },
        failure: function (xhr, textStatus, errorThrown) {
            console.log("Ocurrió un error al cargar el listado de categorias");
        }
    });

}