
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

                const groupedDetailList = _.groupBy(data.Result.OrderDetailList, detail => detail.Dish.DishIdentifier);
                console.log('groupedDetailList: ', groupedDetailList);

                $('#tblOrderDetail tbody').empty();

                var tableContent = '';
                $.each(groupedDetailList, function (i, item) {

                    tableContent += "<tr>";
                    tableContent += "    <td style='width:80%'>";
                    tableContent += "        <span style='font-weight: bold'>" + groupedDetailList[i][0].Quantity + "x</span>&nbsp;<strong>" + groupedDetailList[i][0].Dish.DishName + "</strong>";
                    tableContent += "    </td>";
                    tableContent += "    <td style='width:20 %; text-align: right'>";
                    tableContent += "        <span style='color:#28a745;'>" + castToCurrency(groupedDetailList[i][0].TotalAmount) + "</span>";
                    tableContent += "    </td>";
                    tableContent += "</tr>";

                    for (var j = 0; j < groupedDetailList[i].length; j++) {
                        tableContent += "<tr>";
                        tableContent += "    <td colspan='2'>"
                        tableContent += "        <span style='color:grey'>" + groupedDetailList[i][j].DishComplementName + "</span>";
                        tableContent += "    </td>";
                        tableContent += "</tr>";
                    }
                });

                $('#tblOrderDetail tbody').append(tableContent);

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