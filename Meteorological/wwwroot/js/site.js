// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// var UrlPrevisao = "http://servicos.cptec.inpe.br/XML/cidade/7dias/{CodigoDaCidade}/previsao.xml ";

    $("#cityNameInput").keyup(function () {
        var Url = "http://servicos.cptec.inpe.br/XML/listaCidades";
        var UrlPrevisao = "http://servicos.cptec.inpe.br/XML/cidade/7dias/{CodigoDaCidade}/previsao.xml ";

        $.ajax({
            type: "GET",
            url: Url,
            dataType: "xml",
            data: { city: $("#cityNameInput").val() },
            success: function (xml) {
                $("#result").empty();
                $(xml).find('cidade').each(function (k, v) {
                    if (k <= 5) {
                        var code = $(this).find('id').text();
                        var name = $(this).find('nome').text();
                        var uf = $(this).find('uf').text();

                        $("#result").append('<div class="row" >'
                                            +   '<div class="col-md-12 item-city-code">'
                                                 + '<a href="/Previsao/Cidade/'+code+'" >'
                                            +           '<p>' + name + ' / ' + uf + ' </p>'
                                            +           '<p> /Previsao/Cidade/'+code+' </p>'
                                            +       '</a>'
                                            +   '</div>'
                                            +'</div>');
                    }
                });

            },
            error: function () {
                setTimeout(function () {
                    $("#erroMessage").text("Ocorreu um erro inesperado durante o processamento.");
                }, 300);
                $("#erroMessage").text("");
            }
        });
    }); 


