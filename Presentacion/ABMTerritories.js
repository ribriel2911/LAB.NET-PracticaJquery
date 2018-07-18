$(document).ready(function () {

        $("#loading").show();

        $.ajax({
            type: "GET",                                              // tipo de request 
            url: 'ABMTerritories.ashx',                                  // URL a donde vamos
            data: "MethodName=GetTerritories",                                                // data permite enviar params al server
            contentType: "application/json; charset=utf-8",            // tipo de contenido
            dataType: "json",                                          // como se enviaran los datos
            async: true,                                               // si es asincrónico o no
            success: function (data) {                             // función callback que va a ejecutar si el pedido fue exitoso
                for (var i = 0; i < data.length; i++) {

                    var tr = $("<tr />");
                    var btd = $("<td />");
                    var btn = $('<button type="button" ID="btn' + data[i].TerritoryID + '" class="btn btn-grid">Select</>');
                    var id = $("<td />)");
                    var desc = $("<td />)");
                    var rid = $("<td />)");

                    btd.append(btn);
                    id.html(data[i].TerritoryID);
                    desc.html(data[i].TerritoryDescription);
                    rid.html(data[i].RegionID);

                    tr.append(btd, id, desc, rid);
                    $('#Grid1').append(tr);
                    $('#btn' + data[i].TerritoryID).click(function () {
                        $('#txtTerritoryId').val(data[i].TerritoryID);
                    });
                }

                $("#loading").hide();
                $('#Grid1').show();
            }
    });

    $.ajax({
        type: "GET",                                              // tipo de request 
        url: 'ABMTerritories.ashx',                                  // URL a donde vamos
        data: "MethodName=GetRegions",                                                // data permite enviar params al server
        contentType: "application/json; charset=utf-8",            // tipo de contenido
        dataType: "json",                                          // como se enviaran los datos
        async: true,                                               // si es asincrónico o no
        success: function (data) {                             // función callback que va a ejecutar si el pedido fue exitoso
            for (var i = 0; i < data.length; i++) {

                var opt = $('<option />');

                opt.html(data[i].RegionDescription);
                $('#listRegion').append(opt);
            }
        }
   });
});