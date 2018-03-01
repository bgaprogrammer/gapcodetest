//ViewModel

var polizaViewModel = kendo.observable({
    usuario: "",
    contrasena: "",
    onShowLoginView: function () {
        //Attaches a kendoValidator to the login form
        $("#loginForm").kendoValidator().data("kendoValidator");
    },
    onBtnloginClick: function (e) {
        e.preventDefault();

        var loginValidator = $("#loginForm").kendoValidator().data("kendoValidator");

        if (loginValidator.validate()) {
            polizaViewModel.requestNewAuthToken();
        }
    },
    requestNewAuthToken: function () {
        kendo.ui.progress($("#loginForm"), true);

        $.ajax({
            type: "POST",
            url: "/api/account",
            contentType: "application/json",
            accepts: "application/json",
            cache: false,
            data: JSON.stringify({
                Email: polizaViewModel.get("usuario"),
                Password: polizaViewModel.get("contrasena")
            }),
            success: function (result, status, xhr) {
                kendo.ui.progress($("#loginForm"), false);

                polizaViewModel.setAuthToken(result);
                polizaViewModel.redirectToPolizasView();
            },
            error: function (xhr, status, error) {
                kendo.ui.progress($("#loginForm"), false);

                if(xhr.status == 400){
                    kendo.alert("Datos incorrectos. Intente nuevamente");
                    return;
                }

                kendo.alert("[" + xhr.status + "] " + status);
            }
        });
    },
    setAuthToken: function (token) {
        sessionStorage.setItem("AuthToken", token);
    },
    getAuthToken: function () {
        var token = sessionStorage.getItem("AuthToken");

        if(!token || token.toString().length == 0) {
            polizaViewModel.redirectToLoginView();
            return;

            //If an invalid token is setted in the storage, those cases will be handled by each ajax request;
        }

        return "Bearer " + token.toString();
    },
    redirectToLoginView: function () {
        router.navigate("/");
    },
    redirectToPolizasView: function () {
        router.navigate("/polizas");
    },
    polizasDS: new kendo.data.DataSource({
        pageSize: 10,
        transport: {
            read: {
                url: "/api/poliza",
                contentType: "application/json",
                accepts: "application/json",
                type: "GET",
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", polizaViewModel.getAuthToken());
                }
            },
            create: {
                url: "/api/poliza",
                contentType: "application/json",
                accepts: "application/json",
                type: "POST",
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", polizaViewModel.getAuthToken());
                }
            },
            update: {
                url: "/api/poliza",
                contentType: "application/json",
                accepts: "application/json",
                type: "PUT",
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", polizaViewModel.getAuthToken());
                }
            },
            destroy: {
                url: "/api/poliza",
                contentType: "application/json",
                accepts: "application/json",
                type: "DELETE",
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", polizaViewModel.getAuthToken());
                }
            },
            parameterMap: function (options, operation) {
                if (operation !== "read" && options) {
                    return kendo.stringify(options);
                }
            }
        },
        schema: {
            model: {
                id: "id",
                fields: {
                    id: {
                        type: "numeric"
                    },
                    agencia: {
                        defaultValue: {}
                    },
                    tipoCubrimiento: {
                        defaultValue: {}
                    },
                    tipoRiesgo: {
                        defaultValue: {}
                    },
                    clientes: {
                        defaultValue: []
                    },
                    nombre: {
                        type: "string"
                    },
                    descripcion: {
                        type: "string"
                    },
                    inicioVigencia: {
                        type: "date"
                    },
                    coberturaMeses: {
                        type: "numeric"
                    },
                    precio: {
                        type: "numeric"
                    },
                    porcentajeCubrimiento: {
                        type: "numeric"
                    }
                }
            }
        },
        requestStart: function (e) {
            kendo.ui.progress($("#polizasGrid"), true);
        },
        requestEnd: function (e) {
            kendo.ui.progress($("#polizasGrid"), false);
        },
        error: function (e) {
            console.log("polizasDS Error: " + kendo.stringify(e));
        }
    }),
    onShowPolizasView: function () {
        //Attaches a kendoValidator to the polizas form
        $("#polizasForm").kendoValidator().data("kendoValidator");
    },
    clientesPolizaGridTemplate: function (dataItem) {
        var clientes = [];

        $.each(dataItem.clientes, function (index, element) {
            clientes.push(element.nombre);
        });

        return kendo.htmlEncode(clientes.join(", "));
    },
    onEditPolizasGrid: function (e) {
        if (e.model.isNew()) {
            $(".k-window-title").text("Nueva Poliza");
            $(".k-grid-update").text("Agregar");
        } else {
            $(".k-window-title").text("Editar Poliza");
            $(".k-grid-update").text("Actualizar");
        }

        //Sets Inicio Vigencia min date
        var dpInicioVigenciaModal = $("#dpInicioVigenciaModal").data("kendoDatePicker");
        dpInicioVigenciaModal.min(new Date());

        //Attach change event to the 
        var ddlTipoRiesgoModal = $("#ddlTipoRiesgoModal").data("kendoDropDownList");
        ddlTipoRiesgoModal.bind("select", polizaViewModel.get("onSelectddlTipoRiesgoModal"));
    },
    agenciaDS: new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/poliza/agencia",
                contentType: "application/json",
                accepts: "application/json",
                type: "GET",
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", polizaViewModel.getAuthToken());
                }
            }
        }
    }),
    tipoCubrimientoDS: new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/poliza/tipocubrimiento",
                contentType: "application/json",
                accepts: "application/json",
                type: "GET",
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", polizaViewModel.getAuthToken());
                }
            }
        }
    }),
    tipoRiesgoDS: new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/poliza/tiporiesgo",
                contentType: "application/json",
                accepts: "application/json",
                type: "GET",
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", polizaViewModel.getAuthToken());
                }
            }
        }
    }),
    clienteDS: new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/poliza/cliente",
                contentType: "application/json",
                accepts: "application/json",
                type: "GET",
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", polizaViewModel.getAuthToken());
                }
            }
        }
    }),
    onSelectddlTipoRiesgoModal: function(e) {
        var selectedTipoRiesgo = e.sender.dataItem(e.item);

        if(selectedTipoRiesgo) {
            var ntxtPorcentajeCubrimientoModal = $("#ntxtPorcentajeCubrimientoModal").data("kendoNumericTextBox");
            ntxtPorcentajeCubrimientoModal.max(selectedTipoRiesgo.maxPorcentajeCubrimiento);

            var currentValue = ntxtPorcentajeCubrimientoModal.value();

            if (currentValue) {
                if(currentValue > selectedTipoRiesgo.maxPorcentajeCubrimiento) {
                    ntxtPorcentajeCubrimientoModal.value(selectedTipoRiesgo.maxPorcentajeCubrimiento);
                    ntxtPorcentajeCubrimientoModal.trigger("change");
                }
            }
        }
    }
});

//Layout and Views

var layout = new kendo.Layout("<div class='container-fluid'><section id='content'></section></div>");

var loginView = new kendo.View($("#login-view").html(), {
    model: polizaViewModel,
    show: polizaViewModel.onShowLoginView.bind(polizaViewModel)
});

var polizasView = new kendo.View($("#polizas-view").html(), {
    model: polizaViewModel,
    init: function() {
        polizaViewModel.getAuthToken();
    },
    show: polizaViewModel.onShowPolizasView.bind(polizaViewModel)
});

//Routing
var router = new kendo.Router();

router.bind("init", function() {
    layout.render($("#app"));
});

router.route("/", function() {
    layout.showIn("#content", loginView);
});

router.route("/polizas", function() {
    layout.showIn("#content", polizasView);
});

$(function() {
    router.start();
});