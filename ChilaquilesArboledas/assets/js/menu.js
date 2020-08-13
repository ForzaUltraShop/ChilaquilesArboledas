$(document).ready(function () {

    loadCategoryItems();

});

function loadCategoryItems()
{
    $.ajax({
        type: "POST",
        url: "../Menu.aspx/CategoriesGetList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            let data = response.d;
            if (data != undefined) {
                console.log('registerData', data);
                if (data.Success) {
                    $('#txtRegisterName').val('');
                    $('#txtRegisterPhone').val('');
                    $('#txtRegisterEmail').val('');
                    $('#txtRegisterPassword').val('');
                    $('#txtRegisterPostalCode').val('');
                    $('#txtRegisterAddress').val('');
                    alert("Tu registro esta completo, ya puedes iniciar sesión");
                }
                else {
                    $('#spnRegisterError').text("No fue posible realizar tu registro, por favor intenta más tarde");
                    $('#spnRegisterError').show();
                }
            }
        },
        failure: function (xhr, textStatus, errorThrown) {
            $('#spnRegisterError').text("Ocurrió un error al realizar tu registro, por favor intenta más tarde");
            $('#spnRegisterError').show();
        }
    });
};