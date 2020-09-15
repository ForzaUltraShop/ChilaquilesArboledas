
$(document).ready(function () {

    $('#lnkShareMyLocation').hide();
    $('#OkShareLocation').hide();

    $('#lnkShareMyLocation').click(function ()
    {
        if (navigator.geolocation)
        {
            navigator.geolocation.getCurrentPosition(savePosition);
        }
        else
        {
            swal("Error", "No fue posible obtener tu ubicación actual", "error");
        }
    });

    function savePosition(position) {
        $('#hdfLatitude').val(position.coords.latitude);
        $('#hdfLongitude').val(position.coords.longitude);
        $('#lnkShareMyLocation').hide();
        $('#OkShareLocation').show();
    }

    $('.rbtDeliveryOption').change(function () {
        let radio = $(this);
        if (radio.is(':checked')){
            switch (parseInt(radio.val())) {
                case 0:
                    $('#lnkShareMyLocation').hide();
                    $('#OkShareLocation').hide();
                    console.log('Para llevar');
                    break;
                case 1:
                    $('#lnkShareMyLocation').hide();
                    $('#OkShareLocation').hide();
                    console.log('Para ir comiendo');
                    break;
                case 2:
                    $('#lnkShareMyLocation').show();
                    $('#OkShareLocation').hide();
                    console.log('Entrega a domicilio');
                    break;
            }
        }
    });

    $('#btnSendOrder').click(function ()
    {
        let cartCheckOut = {
            OrderDTO: {
                OrderIdentifier: parseInt($('#hdfOrderIdentifier').val())
            },
            AditionalCommnents: $('#txtAditionalComments').val(),
            DeliveryOption: parseInt($('.rbtDeliveryOption:checked').val()),
            NotifyDTO: {
                Latitude: $('#hdfLatitude').val(),
                Longitude: $('#hdfLongitude').val()
            }
        };

        console.log('cartCheckOut:', cartCheckOut);

        $.ajax({
            type: "POST",
            url: "../Forms/CartCheckOut.aspx/CartCheckOutExecute",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ "cartCheckOut": cartCheckOut }),
            dataType: "json",
            success: function (response)
            {
                let data = response.d;
                if (data.Success)
                {
                    swal("Pedido completado", "Hemos recibido tu orden y enseguida empezaremos a preparalo", "success");
                }
                else
                {
                    swal("Oops!", "No fue posible generar tu orden este momento, por favor intenta más tarde", "error");
                }
            },
            failure: function (xhr, textStatus, errorThrown) {

            }
        });
    });
});

function loadCart()
{    
    $.ajax({
        type: "POST",
        url: "../Forms/CartCheckOut.aspx/OrderGetItem",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "orderIdentifier": parseInt($('#hdfOrderIdentifier').val()) }),
        dataType: "json",
        success: function (response)
        {
            let data = response.d;
            if (data.Success)
            {
                console.log('Order', data.Result);

                const groupedDetailList = _.groupBy(data.Result.OrderDetailList, detail => detail.UniqueKeyIdentifier);
                console.log('groupedDetailList: ', groupedDetailList);

                $('#tblOrderDetail tbody').empty();
                $('#tblOrderDetail tfoot').empty();

                var tableContent = '';
                $.each(groupedDetailList, function (i, item)
                {
                    let dishPrice = parseFloat(groupedDetailList[i][0].Dish.DishPrice) * parseInt(groupedDetailList[i][0].Quantity)
                    let complementAditionalCost = 0;
                    for (var j = 0; j < groupedDetailList[i].length; j++) {
                        complementAditionalCost += parseInt(groupedDetailList[i][0].Quantity) * parseFloat(groupedDetailList[i][j].AditionalCost)
                    }

                    tableContent += "<tr>";
                    tableContent += "    <td style='width:80%'>";
                    tableContent += "        <span style='font-weight: bold'>" + groupedDetailList[i][0].Quantity + "X</span>&nbsp;<strong>" + groupedDetailList[i][0].Dish.DishName + "</strong>";
                    tableContent += "    </td>";
                    tableContent += "    <td style='width:20 %; text-align: right'>";
                    tableContent += "        <span style='color:#28a745; font-weight:bold'>" + castToCurrency(dishPrice + complementAditionalCost) + "</span>";
                    tableContent += "    </td>";
                    tableContent += "</tr>";

                    for (var j = 0; j < groupedDetailList[i].length; j++)
                    {
                        tableContent += "<tr>";
                        tableContent += "    <td colspan='2'>"
                        tableContent += "        <span style='color:grey'>" + groupedDetailList[i][j].DishComplementName + "</span>";
                        tableContent += "    </td>";
                        tableContent += "</tr>";
                    }
                });

                $('#tblOrderDetail tbody').append(tableContent);

                let tableFooterContent = "";
                tableFooterContent += "<tr style='border-top:1px solid black'>";
                tableFooterContent += " <td style='width:80%; text-align:right;'><span style='font-weight:bold'>Total:</span></td>";
                tableFooterContent += " <td style='width:20%; text-align:right;'><span style='font-weight:bold'>" + castToCurrency(data.Result.ItemsTotalAmount) + "</span></td>";
                tableFooterContent += "</tr>";
                $('#tblOrderDetail tfoot').append(tableFooterContent);
            }
            else
            {
                swal("Oops!", "No fue posible generar tu orden este momento, por favor intenta más tarde", "error");
            }
        },
        failure: function (xhr, textStatus, errorThrown) {

        }
    });
};