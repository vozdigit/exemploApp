var login = function () {

    var exibaLoad = function () {
        $("#loginWidget").block({ overlayCSS: { backgroundColor: '#000', opacity: 0.6 } });
    };

    var removeLoad = function () {
        $("#loginWidget").unblock();
    };

    var OnErro = function (data) {
        principal.exibaErroGlobal(data);
    };

    var OnClick = function (url) {

        var resultado = validacoes.validar();

        if (resultado == false) {
            return false;
        } else {
            exibaLoad();
            $.post($('#formularioPadrao').attr('action'), $('#formularioPadrao').serialize())
                .done(function (data) {
                    var json = JSON.parse(data);
                    if (json.Sucesso) {

                        if (json.UrlRetorno == undefined) {

                            principal.carreguePost(url);
    

                        } else {

                            principal.carreguePost(json.UrlRetorno);
                        }
                    }
                    else {
                        
                        mensagemNotificacao.exibaErro($("#loginWidget"), "Login/senha inválidos");
                        removeLoad();
                    }
                });
        }
    };

    return {
        OnErroOnErro: OnErro,
        OnClick: OnClick
    };
}()

$(document).ready(function () {
    $('input').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            $("button").click();
        }
    });
});