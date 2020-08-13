$(document).ready(function () {

    loadCategoryItems();

});

function loadCategoryItems()
{
    $.ajax({
        type: "POST",
        url: "../Forms/Menu.aspx/CategoriesGetList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            let data = response.d;
            if (data != undefined) {
                if (data.Success) {
                    var list = data.Result.filter(item => item.IsActive);

                    $('#divContent').empty();
                    $.each(list, function (i, item) {

                        let imgSource = "../assets/images/" + list[i].CategoryImagePath;

                        let categoryRow = "<div class='card'>";
                        categoryRow += "<div class='row '>";
                        categoryRow += "<div class='col-md-3'>";
                        categoryRow += "<div>";
                        categoryRow += "<img class='d-block' src='" + imgSource +"' height='200px' width='250px' />";
                        categoryRow += "</div>";
                        categoryRow += "</div>";
                        categoryRow += "<div class='col-md-9 px-3'>";
                        categoryRow += "<div class='card-block px-6'>";
                        categoryRow += "<h4 class='card-title'>" + list[i].CategoryName + "</h4>";
                        categoryRow += "<p class='card-text'>" + list[i].CategoryDescription + "</p>";
                        categoryRow += "<br>";
                        categoryRow += "<a href='#' class='mt-auto btn btn-success'>Armálos como más te gusté</a>";
                        categoryRow += "</div>";
                        categoryRow += "</div>";
                        categoryRow += "</div>";
                        categoryRow += "</div>";
                        $('#divContent').append(categoryRow);
                    });
                }
                else {
                    alert("No fue posible cargar el listado de categorias");
                }
            }
        },
        failure: function (xhr, textStatus, errorThrown) {
            console.log("Ocurrió un error al cargar el listado de categorias");
        }
    });
};