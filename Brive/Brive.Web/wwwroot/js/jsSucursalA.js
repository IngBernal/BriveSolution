$(document).ready(function () {

    $("#addProductSucursalA").click(function () {

        var Code = $("#codeSA").val();
        var Quantity = $("#quantity").val();
        
        var isValid = true;

        if (Code.length <= 5 || Code.length > 7) {
            alert("Agrege un codigo de 6 caracteres");
            isValid = false;
        }

        if (isValid) {

            var ChangeQuantity = {
                Code: Code,
                Quantity: parseInt(Quantity)
            };

            $.ajax({
                url: "http://localhost:51922/api/SucursalA/UpdateProductSucursalA",
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                data: JSON.stringify(ChangeQuantity),
                success: function (result) {

                    if (result === true) {
                        LoadDadaSucursal_A();                        
                        cleanInputs();
                        alert("Se modifico de forma correcta la cantidad del producto.");
                    }
                    else if (result === -1) {
                        alert("Ya existe un tarjeta con ese numero");
                        limpiarCampos();
                    }
                },
                error: function (errorMensaje) {
                    alert(errorMensaje.responseText);
                }
            });
        }

    });

    $("#ComprarSucursalA").click(function () {

        var Code = $("#codeSA").val();
        var Quantity = $("#quantity").val();

        var isValid = true;

        if (Code.length <= 5 || Code.length > 7) {
            alert("Agrege un codigo de 6 caracteres");
            isValid = false;
        }

        if (isValid) {

            var ChangeQuantity = {
                Code: Code,
                Quantity: parseInt(Quantity)
            };

            $.ajax({
                url: "http://localhost:51922/api/SucursalA/ComprarProductSucursalA",
                type: "DELETE",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                data: JSON.stringify(ChangeQuantity),
                success: function (result) {

                    if (result === true) {
                        LoadDadaSucursal_A();
                        cleanInputs();
                        alert("Se realizo su compra de forma exitosa.");
                    }
                    else if (result === -1) {
                        alert("Ya existe un tarjeta con ese numero");
                        limpiarCampos();
                    }
                },
                error: function (errorMensaje) {
                    alert(errorMensaje.responseText);
                }
            });
        }
    });

    function LoadDadaSucursal_A() {

        $.ajax({
            url: "http://localhost:51922/api/SucursalA/GetProductsSucursalA",
            type: "GET",
            dataType: "json",
            data: {},
            success: function (result) {

                var html = '';

                for (let product of result) {

                    html += '<tr>';
                    html += '<td>' + product.id + '</td>';
                    html += '<td>' + product.productName + '</td>';
                    html += '<td>' + product.code + '</td>';
                    html += '<td>' + product.quantity + '</td>';
                    html += '<td>' + product.unitPrice + '</td>';
                    html += '</tr>';
                }

                $(".sucursalA").html(html);
            },
            error: function (errorMensaje) {
                alert(errorMensaje.responseText);
            }
        });
    }

    function cleanInputs() {
        $("#codeSA").val("");
        $("#quantity").val("");
    }
});