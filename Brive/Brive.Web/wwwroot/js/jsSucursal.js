$(document).ready(function () {

    LoadDadaSucursal_A();
    LoadDadaSucursal_B()

    $("#addProduct").click(function () {

        var ProductName = $("#product").val();
        var Code = $("#code").val();

        var isValid = true;

        if (ProductName.length < 4) {
            alert("El nombre del producto debe tener una longitud mayor a 5");
            isValid = false;
        }

        if (Code.length <= 5 || Code.length > 7) {
            alert("Agrege un codigo de 6 caracteres");
            isValid = false;
        }

        if (isValid) {

            var Product = {
                ProductName: ProductName,
                Code: Code
            };

            $.ajax({
                url: "http://localhost:51922/api/Sucursal/AddProduct",
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                data: JSON.stringify(Product),
                success: function (result) {

                    if (result === true) {
                        LoadDadaSucursal_A();
                        LoadDadaSucursal_B();
                        cleanInputs();
                        alert("Se agrego de forma correcta el producto.");
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

    $("#btnSearch").click(function () {
        var id = $("#codeSearch").val();

        $.ajax({
            url: "http://localhost:51922/api/SucursalA/GetById?id=" + id,
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            success: function (result) {

                var html = '';

                html += '<tr>';
                html += '<td>' + result.id + '</td>';
                html += '<td>' + result.productName + '</td>';
                html += '<td>' + result.code + '</td>';
                html += '<td>' + result.quantity + '</td>';
                html += '<td>' + result.unitPrice + '</td>';
                html += '</tr>';


                $(".tsearch").html(html);
            },
            error: function (errorMensaje) {
                alert(errorMensaje.responseText);
            }
        });

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

    function LoadDadaSucursal_B() {

        $.ajax({
            url: "http://localhost:51922/api/SucursalB/GetProductsSucursalB",
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

                $(".sucursalB").html(html);
            },
            error: function (errorMensaje) {
                alert(errorMensaje.responseText);
            }
        });
    }

    function cleanInputs() {
        $("#product").val("");
        $("#code").val("");
    }
});
