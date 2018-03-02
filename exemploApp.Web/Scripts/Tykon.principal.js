var principal = function () {

    var exibaTelaEdicao = function (url, data, callback) {

        carregueConteudoComPost(url, content, data, callback);
    };

    var exibaTelaNovo = function (url, callback) {
        carregueConteudoComPost(url, content, callback);
    };

    var exibaTelaListagem = function (url, callback) {
        carregueConteudoComPost(url, content, callback);
    };

    var painelDetalhe = function () {
        return $(".widget.containerConteudo");
    }

    var exibaLoadPainelDetalhe = function () {
        painelDetalhe().block();
    }

    var removeLoadPainelDetalhe = function () {
        painelDetalhe().unblock();
    }

    var salvar = function (elformulario) {
        exibaLoadPainelDetalhe();
        var resultado = validacoes.validar();

        if (resultado == false) {
            mensagemNotificacaoGeral.exibaErro("Existem inconsistências");
            removeLoadPainelDetalhe();
            return false;
        } else {

            $.post(elformulario.attr('action'), elformulario.serialize())
                .done(function (data) {
                    var json = JSON.parse(data);
                    if (json.Sucesso) {

                        var msgSucesso = function () {
                            mensagemNotificacaoGeral.exibaSucessoPadrao(json.Mensagem);
                        }

                        exibaTelaListagem(json.UrlRetorno, msgSucesso);
                    }
                    else {
                        validacoes.exibir(json.Inconsistencias, json.Mensagem);
                        removeLoadPainelDetalhe();
                    }
                });
        }
    }

    var excluir = function (elformulario) {
        exibaLoadPainelDetalhe();
        $.post(elformulario.attr('actionExclusao'), elformulario.serialize())
                   .done(function (data) {
                       var json = JSON.parse(data);
                       if (json.Sucesso) {

                           var msgSucesso = function () {
                               mensagemNotificacaoGeral.exibaSucessoPadrao(json.Mensagem);
                           }

                           exibaTelaListagem(json.UrlRetorno, msgSucesso);
                       }
                       else {
                           validacoes.exibir(json.Inconsistencias, json.Mensagem);
                           removeLoadPainelDetalhe();
                       }
                   });
    }

    var excluirPadrao = function () {
        excluir($(formularioPadrao()));
    }

    var salvarPadrao = function () {
        salvar($(formularioPadrao()))
    }

    var carregueConteudoComPost = function (url, local, data, callback, containerLoad) {

        exibaLoad(painelDetalhe, containerLoad);

        if (data) {
            local().load(url, data, function () {

                removeLoad(painelDetalhe, containerLoad);
                if (callback) {
                    callback();
                }
            });
        } else {

            local().load(url, function () {
                removeLoad(painelDetalhe, containerLoad);
                if (callback) {
                    callback();
                }
            });
        }
    };

    var carreguePost = function (url, callback) {
        carregueConteudoComPost(url, pagina, callback);
    }

    var selecionarItemMenu = function (el, url) {
        aplicarComportamento($(el).parent());
        exibaTelaListagem(url);
    }

    var aplicarComportamento = function (el) {

        $(el).parents('.sidebar').find(".active").each(function (i, e) {
            $(e).removeClass("active");
        });

        adicionaAtivo(el);
    }

    var adicionaAtivo = function (el) {
        $(el).addClass("active");

        $(el).parents("li").each(function (i, e) {
            $(e).addClass("active")
        });
    }

    var exibaLoad = function (local, containerLoad) {

        if (containerLoad != undefined) {
            containerLoad().block();
        } else {

            local().block();
        }
    };

    var removeLoad = function (local, containerLoad) {

        if (containerLoad != undefined) {
            containerLoad().unblock();
        } else {

            local().unblock();
        }
    };

    var content = function () {
        return $("#am-content");
    };

    var pagina = function () {
        return $("#page-container");
    }

    var formularioPadrao = function () {
        return $("#formularioPadrao");
    }

    return {
        fluxoEdicao: exibaTelaEdicao,
        fluxoListagem: exibaTelaListagem,
        fluxoNovo: exibaTelaNovo,
        carreguePost: carreguePost,
        selecionarItemMenu: selecionarItemMenu,
        salvarPadrao: salvarPadrao,
        excluirPadrao: excluirPadrao,
        carregueConteudoComPost: carregueConteudoComPost,
        exibaLoadPainelDetalhe: exibaLoadPainelDetalhe,
        removeLoadPainelDetalhe: removeLoadPainelDetalhe

    };

}();


var validacoesRelativas = function () {

    var validarClienteSide = function (formulario) {

        this.limpar(formulario);
        return validador(formulario).validate();
    };

    var validador = function (formulario) {
        return $(formulario).parsley();
    };

    var limpar = function (formulario) {
        validador(formulario).reset();
    };

    var exibir = function (formulario, inconsistencias, mensagemDetalhada) {

        this.limpar(formulario);

        if (inconsistencias == null || inconsistencias == undefined) {
            mensagemNotificacaoGeral.exibaErro(mensagemDetalhada);
        } else {

            var inconsistenciasSemVinculo = [];
            inconsistencias.forEach(function (elemento, indice) {
                var encontrado = false;
                validador(formulario).fields.forEach(function (e, i) {
                    var propriedade = e.$element.attr("Propriedade");
                    var nome = e.$element.attr("Name");
                    if (propriedade != undefined && elemento.Propriedade == propriedade) {
                        ParsleyUI.addError(e, nome, elemento.Mensagem);
                        encontrado = true;
                    }
                });

                if (!encontrado) {
                    inconsistenciasSemVinculo[indice] = elemento;
                }
            });

            mensagemNotificacaoGeral.exibaErroDetalhado(inconsistenciasSemVinculo);
        }

    }

    return {
        exibir: exibir,
        limpar: limpar,
        validar: validarClienteSide,
    }
}();

var validacoes = function () {

    var formularioPadrao = function () {
        return $("#formularioPadrao");
    };

    var validarClienteSide = function () {
        return validacoesRelativas.validar(formularioPadrao())
    };

    var exibir = function (inconsistencias, mensagemDetalhada) {
        validacoesRelativas.exibir(formularioPadrao(), inconsistencias, mensagemDetalhada);
    }

    var limpar = function () {
        validacoesRelativas.limpar(formularioPadrao());
    };

    return {
        exibir: exibir,
        limpar: limpar,
        validar: validarClienteSide,
    }
}();

var mensagemNotificacao = function () {
    var exibaMensagem = function (tipoMensagem, escopo, mensagemPadrao, inconsistencias) {

        if (inconsistencias && inconsistencias.length > 0) {
            var erro = "";

            inconsistencias.forEach(function (e, i) {
                erro += "<span> <strong> " + e.Propriedade + " </strong> - " + e.Mensagem + "</span> </br>";
            });

            var mensagemCompleta = "<strong>Erro! Verifique as regras: </strong> </div> </br>" + erro;

            if (escopo != undefined) {
                $(escopo).notify({ mensagemHtml: mensagemCompleta }, { autoHideDelay: 7000, style: "vd-modal", position: "top-center", className: tipoMensagem });
            } else {
                $.notify({ mensagemHtml: mensagemCompleta }, { autoHideDelay: 7000, style: "vd", className: tipoMensagem })
            }
        }
        else {

            if (escopo != undefined) {
                $(escopo).notify({ mensagemHtml: mensagemPadrao }, { autoHideDelay: 7000, style: "vd-modal", position: "top-center", className: tipoMensagem });
            } else {
                $.notify({ mensagemHtml: mensagemPadrao }, { autoHideDelay: 7000, style: "vd", className: tipoMensagem })
            }
        }
    };

    var exibaErroDetalhado = function (escopo, inconsistencias) {
        return exibaMensagem('error', escopo, "Existem inconsistências.", inconsistencias);
    }

    var exibaErro = function (escopo, mensagem) {
        return exibaMensagem('error', escopo, '<strong>Erro!</strong> ' + mensagem + '.');
    }

    var exibaNotificacao = function (escopo, mensagem) {
        return exibaMensagem('warning', escopo, mensagem);
    }

    var exibaSucesso = function (escopo, mensagem) {
        return exibaMensagem('success', escopo, mensagem);
    }

    return {
        exibaErroDetalhado: exibaErroDetalhado,
        exibaNotificacao: exibaNotificacao,
        exibaSucesso: exibaSucesso,
        exibaErro: exibaErro
    }
}();

var mensagemNotificacaoModal = function () {
    var exibaErroDetalhado = function (inconsistencias) {
        return mensagemNotificacao.exibaErroDetalhado($(".modal.in .modal-content"), inconsistencias);
    }

    var exibaNotificacao = function (mensagem) {
        return mensagemNotificacao.exibaNotificacao($(".modal.in .modal-content"), mensagem);
    }

    var exibaSucesso = function (mensagem) {
        return mensagemNotificacao.exibaSucesso($(".modal.in .modal-content"), mensagem);
    }

    return {
        exibaErroDetalhado: exibaErroDetalhado,
        exibaNotificacao: exibaNotificacao,
        exibaSucesso: exibaSucesso
    }
}();

var mensagemNotificacaoGeral = function () {

    var exibaErroDetalhado = function (inconsistencias) {
        return mensagemNotificacao.exibaErroDetalhado(undefined, inconsistencias);
    }

    var exibaNotificacao = function (mensagem) {
        return mensagemNotificacao.exibaNotificacao(undefined, mensagem);
    }

    var exibaSucesso = function (mensagem) {
        return mensagemNotificacao.exibaSucesso(undefined, mensagem);
    }

    var exibaSucessoPadrao = function (detalhamento) {
        if (detalhamento != undefined) {
            return this.exibaSucesso('<strong>Sucesso!</strong> ' + detalhamento);
        } else {
            return this.exibaSucesso('<strong>Sucesso!</strong> Operação realizada.');
        }
    }

    var exibaErro = function (mensagem) {
        return mensagemNotificacao.exibaErro(undefined, mensagem);
    }

    return {
        exibaErro: exibaErro,
        exibaNotificacao: exibaNotificacao,
        exibaSucesso: exibaSucesso,
        exibaSucessoPadrao: exibaSucessoPadrao,
        exibaErroDetalhado: exibaErroDetalhado
    }
}();

var acessibilidade = function (instancia) {
    if (instancia) {
        return instancia;
    }

    /*Alteração de fontes*/
    var alterarTamanhoFonte = function (escopo, tamanho) {
        $(escopo).find('*').each(function () {

            var tamanhoCorrente = parseInt($(this).css('font-size'));
            $(this).attr("data-font-atual", tamanhoCorrente);

            var tamanhoAtual = parseInt($(this).data("font-atual"));

            if ($(this).attr("data-font-original") == undefined) {
                $(this).attr("data-font-original", tamanhoAtual);
            }
        });

        $(escopo).find('*').each(function () {
            var atual = parseInt($(this).attr("data-font-atual"));

            var novoTamanho = parseInt(atual + tamanho);

            $(this).css('font-size', novoTamanho);
            $(this).attr('data-font-atual', novoTamanho);
        });
    };

    var voltarFonteOriginal = function (escopo) {
        $(escopo).find('*').each(function () {

            var valorAntigo = parseInt($(this).attr('data-font-original'));

            if (valorAntigo && valorAntigo != 0) {
                $(this).css('font-size', valorAntigo);
                $(this).attr('data-font-atual', valorAntigo);
            }
        });
    };

    var aumentarTamanhoFonte = function () {
        alterarTamanhoFonte($("#content"), +1);
    };

    var diminuirTamanhoFonte = function () {
        alterarTamanhoFonte($("#content"), -1);
    };

    var resetarTamanhoFonte = function () {
        voltarFonteOriginal($("#content"));
    };

    var aplicarAltoContraste = function () {
        if ($('body').hasClass('contraste')) {
            $('body').removeClass("contraste");
        } else {
            $('body').addClass("contraste");
        }

    };

    var aplicarRelevo = function () {
        if ($('body').hasClass('relevo')) {
            $('body').removeClass("relevo");
        } else {
            $('body').addClass("relevo");
        }
    };

    var inverterCores = function () {
        var css = 'html {-webkit-filter: invert(100%);' + '-moz-filter: invert(100%);' + '-o-filter: invert(100%);' + '-ms-filter: invert(100%); }',
        head = document.getElementsByTagName('head')[0],
        style = document.createElement('style');
        if (!window.counter) {
            window.counter = 1;
        } else {
            window.counter++;
            if (window.counter % 2 == 0) {
                var css = 'html {-webkit-filter: invert(0%); -moz-filter: invert(0%); -o-filter: invert(0%); -ms-filter: invert(0%); }'
            }
        };
        style.type = 'text/css';
        if (style.styleSheet) {
            style.styleSheet.cssText = css;
        } else {
            style.appendChild(document.createTextNode(css));
        }
        head.appendChild(style);
    };

    return {
        aumentarTamanhoFonte: aumentarTamanhoFonte,
        diminuirTamanhoFonte: diminuirTamanhoFonte,
        inverterCores: inverterCores,
        aplicarAltoContraste: aplicarAltoContraste,
        aplicarRelevo: aplicarRelevo,
        resetarTamanhoFonte: resetarTamanhoFonte

    }
}(acessibilidade || undefined);

var helperGrid = function () {

    var exibaLoad = function (elContainerLoad) {
        elContainerLoad.block();
    }

    var removeLoad = function (elContainerLoad) {
        elContainerLoad.unblock();
    }

    var clickFiltrar = function (elContainerLoad, url, parametros, funcaoAtualizaItens) {
        exibaLoad(elContainerLoad);

        $.post(url, parametros)
          .done(function (data) {
              removeLoad(elContainerLoad);
              var objeto = JSON.parse(data);
              funcaoAtualizaItens(objeto.Itens);
          });
    }

    return {
        clickFiltrar: clickFiltrar
    }

}();

//{
//    position: absolute;
//    float: right;
//    bottom: 10px;
//    right: 51px;
//    font-size: 11px;
//    font-weight: 600;
//}

var controleVersao = function () {

    var insereAtualizaVersaoAplicacao = function (dados) {
        var html = $('body').find(".controleVersao");
        if (html != undefined) {
            html.remove();
        }

        var tooltip = "Runtime: " + dados.Runtime + "\n"
                        + "Version: " + dados.Version + "\n"
                        + "Build-Id: " + dados.BuildId + "\n"
                        + "Build-Number: " + dados.BuildNumber + "\n"
                        + "Build-Tag: " + dados.BuildTag + "\n"
                        + "CommitDate: " + dados.CommitDate + "\n"
                        + "Svn-Path: " + dados.SvnPath + "\n"
                        + "Svn-Revision: " + dados.SvnRevision;

        var template = "<div class='controleVersao' style='bottom:0; position: fixed;right: 51px;font-size: 11px;font-weight: 600; float: right;margin-bottom: 5px;' title='"
                        + tooltip + "'> <span>v" + dados.Version + "</span> </div>"

        $('body').append(template)

    };

    var insereAtualizaVersaoIcone = function (dados) {
        var html = $('body').find(".controleVersaoIcone");
        if (html != undefined) {
            html.remove();
        }

        var template =
                        "<li class='hidden-xs dropdown controleVersaoIcone'> \
                            <a href='#' title='Sobre' id='versao'\
                               class='dropdown-toggle' \
                               data-toggle='dropdown'> \
                                <i class='fa fa-tv'></i> \
                            </a> \
                            <ul id='versao-menu' class='dropdown-menu account' role='menu'> \
                                <li role='presentation' class='account-picture'> "
                                +
                                            "<i class='fa fa-info-circle'></i>"
                                + "<span class='conteudoDropDownInterno'> v" + dados.Version + "</span>"
                                    + "</li> \
                                <li role='presentation' class='account-picture'> \
                                    <i class='fa fa-calendar'></i> "
                                            + "<span class='conteudoDropDownInterno'>" + dados.BuildTime + "</span> \
                                </li> \
                            </ul> \
                        </li>";


        $(template).insertAfter($(".page-header .divider"));

    };

    var init = function (url) {

        $.get(url).done(function (retorno) {

            var retObj = JSON.parse(retorno);

            if (retObj.Sucesso) {
                    insereAtualizaVersaoIcone(retObj.Data);
            }
        });
    };

    return {
        init: init
    }

}();


function fcData(fcn_data) {
    var fcn_dia = parseInt(fcn_data.substring(0, 2), 10);
    var fcn_mes = parseInt(fcn_data.substring(3, 5), 10);
    var fcn_ano = parseInt(fcn_data.substring(6, 10), 10);
    if (fcn_dia <= 31 && fcn_mes <= 12 && fcn_ano >= 1000) {
        if (fcn_data.substring(0, 1) == '0' && fcn_data.substring(1, 2) != '0' || fcn_data.substring(0, 1) != '0') {
            if (fcn_data.substring(2, 3) == "/") {
                if (fcn_data.substring(3, 4) == '0' && fcn_data.substring(4, 5) != '0' || fcn_data.substring(3, 4) != '0') {
                    if (fcn_data.substring(5, 6) == "/") {
                        if (fcn_data.substring(6, 7) == '0' || fcn_data.substring(6, 7) == '' && fcn_data.substring(7, 8) != '0') {
                            window.alert('O ano que você digitou não existe!');
                            return false;
                        } else {
                            if (fcn_mes == 2) {
                                if ((fcn_dia > 0) && (fcn_dia <= 29)) {
                                    if (fcn_dia == 29) {
                                        if ((fcn_ano % 4) == 0) {
                                            return true;
                                        } else {
                                            window.alert('Este dia não existe, certifique - se de que digitou corretamente!');
                                            return false;
                                        }
                                    }
                                } else {
                                    window.alert('Este dia não existe, certifique - se de que digitou corretamente!');
                                    return false;
                                }
                            }
                            if ((fcn_mes == 4) || (fcn_mes == 6) || (fcn_mes == 9) || (fcn_mes == 11)) {
                                if ((fcn_dia > 0) && (fcn_dia <= 30)) {
                                    return true;
                                } else {
                                    window.alert('Este dia não existe, certifique - se de que digitou corretamente!');
                                    return false;
                                }
                            }
                            if ((fcn_mes == 1) || (fcn_mes == 3) || (fcn_mes == 5) || (fcn_mes == 7) || (fcn_mes == 8) || (fcn_mes == 10) || (fcn_mes == 12)) {
                                if ((fcn_dia > 0) && (fcn_dia <= 31)) {
                                    return true;
                                } else {
                                    window.alert('Este dia não existe, certifique-se de que digitou corretamente!');
                                    return false;
                                }
                            }
                        }
                    } else {
                        window.alert('A data foi digitada fora do padrão(dd/mm/aaaa)  !');
                        return false;
                    }
                } else {
                    window.alert('Você digitou um mês que não existe!');
                    return false;
                }
            } else {
                window.alert('A data foi digitada fora do padrão (dd/mm/aaaa)  !');
                return false;
            }
        } else {
            window.alert('Você digitou um fcn_dia que não existe!');
            return false;
        }
    } else {
        window.alert('O dia e/ou o mês que você digitou não existe, ou Você digitou fora do padrão (dd/mm/aaaa) !');
        return false;
    }
    return true;
}


var localizacaoGrid = {
    // separator of parts of a date (e.g. '/' in 11/05/1955)
    '/': "/",
    // separator of parts of a time (e.g. ':' in 05:44 PM)
    ':': ":",
    // the first day of the week (0 = Sunday, 1 = Monday, etc)
    firstDay: 0,
    days: {
        names: ["domingo", "segunda-feira", "terça-feira", "quarta-feira", "quinta-feira", "sexta-feira", "sábado"],
        namesAbbr: ["dom", "seg", "ter", "qua", "qui", "sex", "sáb"],
        namesShort: ["D", "S", "T", "Q", "Q", "S", "S"]
    },
    months: {
        names: ["janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro", ""],
        namesAbbr: ["jan", "fev", "mar", "abr", "mai", "jun", "jul", "ago", "set", "out", "nov", "dez", ""]
    },
    // AM and PM designators in one of these forms:
    // The usual view, and the upper and lower case versions
    //      [standard,lowercase,uppercase]
    // The culture does not use AM or PM (likely all standard date formats use 24 hour time)
    //      null
    AM: ["AM", "am", "AM"],
    PM: ["PM", "pm", "PM"],
    eras: [{
        "name": "d.C.", "start": null, "offset": 0
    }],
    twoDigitYearMax: 2029,
    patterns: {
        d: "dd/MM/yyyy",
        D: "dddd, d' de 'MMMM' de 'yyyy",
        t: "HH:mm",
        T: "HH:mm:ss",
        f: "dddd, d' de 'MMMM' de 'yyyy HH:mm",
        F: "dddd, d' de 'MMMM' de 'yyyy HH:mm:ss",
        M: "dd' de 'MMMM",
        Y: "MMMM' de 'yyyy"
    },
    percentsymbol: "%",
    currencysymbol: "R$",
    currencysymbolposition: "before",
    decimalseparator: ',',
    thousandsseparator: '.',
    pagergotopagestring: "Go to page:",
    pagershowrowsstring: "Show rows:",
    pagerrangestring: " of ",
    pagerpreviousbuttonstring: "previous",
    pagernextbuttonstring: "next",
    groupsheaderstring: "Drag a column and drop it here to group by that column",
    sortascendingstring: "Sort Ascending",
    sortdescendingstring: "Sort Descending",
    sortremovestring: "Remove Sort",
    groupbystring: "Group By this column",
    groupremovestring: "Remove from groups",
    filterclearstring: "Clear",
    filterstring: "Filter",
    filtershowrowstring: "Show rows where:",
    filtershowrowdatestring: "Show rows where date:",
    filterorconditionstring: "Or",
    filterandconditionstring: "And",
    filterselectallstring: "(Select All)",
    filterchoosestring: "Please Choose:",
    filterstringcomparisonoperators: ['empty', 'not empty', 'contains', 'contains(match case)',
        'does not contain', 'does not contain(match case)', 'starts with', 'starts with(match case)',
        'ends with', 'ends with(match case)', 'equal', 'equal(match case)', 'null', 'not null'],
    filternumericcomparisonoperators: ['equal', 'not equal', 'less than', 'less than or equal', 'greater than', 'greater than or equal', 'null', 'not null'],
    filterdatecomparisonoperators: ['equal', 'not equal', 'less than', 'less than or equal', 'greater than', 'greater than or equal', 'null', 'not null'],
    filterbooleancomparisonoperators: ['equal', 'not equal'],
    validationstring: "Entered value is not valid",
    emptydatastring: "No data to display",
    filterselectstring: "Select Filter",
    loadtext: "Loading...",
    clearstring: "Clear",
    todaystring: "Today"
};


$.notify.addStyle("vd", {
    html: "<div> <span data-notify-text>  </span><div data-notify-html='mensagemHtml'> </div> </div>",
    classes: {
        base: {
            "background-repeat": "no-repeat",
            "background-position": "3px 7px",
            "width": "600px",
            "text-align": "center",
            "padding": "10px",
            "animation-name": "bounceInLeft",
            "webkit-animation-name": "bounceInLeft",
            "webkit-animation-duration": "1s",
            "animation-duration": "1s",
            "-webkit-animation-fill-mode": "both",
            "animation-fill-mode": "both",
            "border": "1px solid transparent",
            "border-radius": "3px",
        },
        error: {
            "color": "#fff",
            "background-color": "#EDA0A0",
            "border-color": "#F2633B"
        },
        success: {
            "color": "#fff",
            "background-color": "#9BDBB7",
            "border-color": "#D6E9C6"
        },
        info: {
            "color": "#3A87AD",
            "background-color": "#D9EDF7",
            "border-color": "#e5be56"
        },
        warn: {
            "color": "#666",
            "background-color": "#ffead0",
            "border-color": "#FBEED5"
        }
    }
});

$.notify.addStyle("vd-modal", {
    html: "<div> <span data-notify-text></span> <div data-notify-html='mensagemHtml'> </div></div>",
    classes: {
        base: {
            "background-repeat": "no-repeat",
            "background-position": "3px 7px",
            "width": "400px",
            "text-align": "center",
            "padding": "10px",
            "animation-name": "bounceInLeft",
            "webkit-animation-name": "bounceInLeft",
            "webkit-animation-duration": "1s",
            "animation-duration": "1s",
            "-webkit-animation-fill-mode": "both",
            "animation-fill-mode": "both",
            "border": "1px solid transparent",
            "border-radius": "3px",
        },
        error: {
            "color": "#fff",
            "background-color": "#EDA0A0",
            "border-color": "#F2633B"
        },
        success: {
            "color": "#fff",
            "background-color": "#9BDBB7",
            "border-color": "#D6E9C6"
        },
        info: {
            "color": "#3A87AD",
            "background-color": "#D9EDF7",
            "border-color": "#e5be56"
        },
        warn: {
            "color": "#666",
            "background-color": "#ffead0",
            "border-color": "#FBEED5"
        }
    }
});