$(document).ready(function () {

        $(".data").html("");
        $("#loading").show();

        $.ajax({
            type: "POST",                                              // tipo de request 
            url: 'ABMTerritories.ashx',                                  // URL a donde vamos
            data: null,                                                // data permite enviar params al server
            contentType: "application/json; charset=utf-8",            // tipo de contenido
            dataType: "json",                                          // como se enviaran los datos
            async: true,                                               // si es asincrónico o no
            success: function (territories) {                             // función callback que va a ejecutar si el pedido fue exitoso
                for (var i = 0; i < territories.length; i++) {

                    var tr = $("<tr />");
                    var btd = $("<td />");
                    var btn = $('<button type="button" ID="btn' + territories[i].TerritoryID + ' class="btn btn-grid">Select</>');
                    var id = $("<td />)");
                    var desc = $("<td />)");
                    var rid = $("<td />)");

                    btd.append(btn);
                    id.html(territories[i].TerritoryID);
                    desc.html(territories[i].TerritoryDescription);
                    rid.html(territories[i].RegionID);

                    tr.append(btd, id, desc, rid);
                    $('#Grid1').append(tr); 
                }

                $("#loading").hide();
                $('#Grid1').show();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                console.log(error.Message);
            }
        });
    });