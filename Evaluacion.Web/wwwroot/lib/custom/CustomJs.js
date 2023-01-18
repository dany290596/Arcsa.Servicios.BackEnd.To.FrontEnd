var m_timeOut;
//habilita o deshabilita la funcionalidad para mostrar "loading" mientras se ejecuta una solicitud Ajax
var m_enable_ajax_loader = false;
var m_current_obj = '';

if (!String.prototype.startsWith) {
    String.prototype.startsWith = function (searchString, position) {
        position = position || 0;
        return this.indexOf(searchString, position) === position;
    };
}


/****No permite escribir dentro de textbox****/
jQuery.fn.textBoxReadMode =
    function () {
        return this.each(function () {
            $(this).keydown(function (event) {
                event.preventDefault();
            });
        });
    };

function _fail_ajax_form(xhr, status) {
    semg_error(msg_err_gral);
}


//Coloca el scroll al inicio de la página
function scrollToTop() {
    $("html, body").animate({ scrollTop: 0 }, "slow");
}



//Mustra la animación de carga de página Esta función se puede llamar directo en un onclick.
function showLoading() {
    m_current_obj = $(event.target.activeElement);
    m_current_obj.hide();
    $('<button class="btn btn-default btn-xs">. . .</div>').insertBefore(m_current_obj)
    $("#divLoading").show();
}

//Oculta la animación de carga de página. Esta función se puede llamar directo en un onclick.
function hideLoading() {
    m_current_obj.prev().remove();
    m_current_obj.show();
    $("#divLoading").hide();
}



function _init_ajx() {
    $(document).ajaxStart(function (event) {
        if (m_enable_ajax_loader) {
            //m_current_obj = $(event.target.activeElement);
            //m_current_obj.hide();
            $('<button class="btn btn-default btn-xs">. . .</div>').insertBefore(m_current_obj)

            m_timeOut = setTimeout(function () {
                $("#divLoading").show();
            }, 1000);
        }
    });
    $(document).ajaxStop(function () {
        //m_current_obj.prev().remove();
        //m_current_obj.show();

        $("#divLoading").hide();
    });
}
//Busca dentro del DOM todos los controles que tengan el atributo para asignarles 
//la funcionalidad de copiar un texto a otro (JQuery.CopyToLabel)
function _init_copytolabel() {
    $('input[setlbl]').keyup(function () {
        var ctrl = $(this).attr('setlbl');
        var data = $(this).val();
        $('#' + ctrl).text(data);
    });
}

//Busca dentro del DOM todos los controles que tengan el atributo para asignarles 
//la funcionalidad de copiar un texto a otro (JQuery.CopyToLabel)
function _set_textbox_readonly() {
    $('input[class*="set_read"]').textBoxReadMode();
}

function _set_textbox_maxlen(len) {
    if (len == undefined)
        len = 400;
    $('textarea').attr("maxlength", len);
}


function _set_combo_catalog(catalog, parameter, htmlName, isRequired, container, functionName, multiple = "false") {
    
    $.ajax({
        type: "POST",
        url: '/Components/GetComboByCatalog',
        data: {
            "htmlName": htmlName,
            "isRequired": isRequired,
            "catalog": catalog + ",",
            "parameter": parameter + ",",
            "functionName": functionName,
            "multiple": multiple
        },
        success: function (data) {
            $("#" + container).html(data);
        },
        error: function (xhr, status) {
            var errmsg = msg_err_gral;
            semg_error(errmsg);
        }
    });
}

function _set_datepicker(obj, objsetdate) {
    var dp = $('#' + obj + ' .input-group.date');

    dp.datepicker({
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        calendarWeeks: true,
        autoclose: true,
        format: "yyyy-mm-dd"
    });

    if (objsetdate) {
        dp.datepicker("update", new Date());
    }
}

//-----Mensajes de aviso------
function _window_confirm(callback, args, msg) {
    swal({
        title: msg_01,
        text: msg,
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        closeOnConfirm: false,
        animation: false,
        confirmButtonText: "Aceptar",
        cancelButtonText: "Cancelar"
    }, function (isConfirm) {
        if (isConfirm) {
            if (args == undefined)
                callback();
            else
                callback.apply(this, args);
            swal.close();
            return false;
        }
    });
}

function _window_alert(msg) {
    swal({
        type: "info",
        title: msg_title_info,
        text: msg,
        animation: false
    });
}
//Opciones del mensaje de aviso
function set_toastr_options(timeout) {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "onclick": null,
        "timeOut": timeout,
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
}
function semg_info(msg) {
    set_toastr_options(2500);
    toastr.info(msg, msg_title_info);
}
function semg_alert(msg) {
    set_toastr_options(2500);
    toastr.success(msg, msg_title_info);
}
function semg_error(msg) {
    set_toastr_options(2000);
    toastr.error(msg, msg_title_error);
}
function semg_warning(msg) {
    set_toastr_options(2000);
    toastr.warning(msg, msg_title_error);
}
//-----Fin mensajes de aviso------

//Valida si está vacío un elemento
function isEmpty(value) {
    return (value == null || value.length === 0);
}

//Agrega los íconos de filtrado del grid en base a la columna seleccionada
function addCssGridSorting(grid_id, col, dir) {
    console.log("GRID_ID => ", grid_id);
    console.log("COL => ", col);
    console.log("DIR => ", dir);

    var col = $('#SortOrder').val();
    var dir = $('#SortDir').val();
    var countTh = $('#' + grid_id).find(".trHead:first th").length - 1;

    for (var i = 1; i <= countTh; i++) {
        var oth = $('#' + grid_id + ' table thead .trHead th:nth-child(' + i + ')');
        var c_col = oth.attr("sortcol");

        if (!isEmpty(oth)) {
            oth.removeClass();
            oth.addClass("sorting");

            if (c_col.trim() == col) {
                oth.removeClass();
                if (dir == 'ASC')
                    oth.addClass("sorting_asc");
                else
                    oth.addClass("sorting_desc");
            }
        }
    }
}

//Agrega los íconos de filtrado del grid en base a la columna seleccionada solo para modulo reportes
function addCssGridSorting_report(grid_id, col, dir) {
    var col = $('#SortOrder').val();
    var dir = $('#SortDir').val();
    var countTh = $('#' + grid_id).find(".trHead:first th").length;

    for (var i = 1; i <= countTh; i++) {
        var oth = $('#' + grid_id + ' table thead .trHead th:nth-child(' + i + ')');
        var c_col = oth.attr("sortcol");

        if (!isEmpty(oth)) {
            oth.removeClass();
            oth.addClass("sorting");

            if (c_col.trim() == col) {
                oth.removeClass();
                if (dir == 'ASC')
                    oth.addClass("sorting_asc");
                else
                    oth.addClass("sorting_desc");
            }
        }
    }
}

//Asigna el estilo (css) a los checkboxes de la vista actual
function _set_checkbox_style() {
    $('.i-checks').iCheck({
        checkboxClass: 'icheckbox_square-green',
        radioClass: 'iradio_square-green',
    });
}

function _set_message_invalid_form(frm) {
    var form = $("#" + frm);
    form.on("submit", function (event) {
        if (!form.valid()) {
            semg_error(msg_04);
        }
    });
}

//=======BEGIN funciones GRID ===============
//Asigna al número de la página seleccionado
function setPage(p) {
    $('#PageNumber').val(p);
    $("#btnSubmit").submit();
}

function setPageClients(p) {
    $('#PageNumberClients').val(p);
    $("#btnSubmitClients").submit();
}

function setPageMultiple(p, PageNumberId, btnSubmitId) {
    $('#' + PageNumberId).val(p);
    $("#" + btnSubmitId).submit();
}

//Asigna la columna seleccionada para ordenar
function sortby(sort) {
    var col = $('#SortOrder').val();
    var dir = $('#SortDir').val();

    if (col == sort) {
        dir = (dir == 'ASC') ? 'DESC' : 'ASC';
    }
    else {
        dir = 'ASC';
    }

    $('#SortDir').val(dir);
    $('#SortOrder').val(sort);
    $("#btnSubmit").submit();
}

function searchByMultiple(PageNumberId, btnSubmitId) {
    if (($('#' + PageNumberId).length) && ($('#' + PageNumberId).length)) {
        $('#' + PageNumberId).val(1);
        $("#" + btnSubmitId).submit();
    }
}

function searchBy() {
    if (($('#PageNumber').length) && ($('#PageNumber').length)) {
        $('#PageNumber').val(1);
        $("#btnSubmit").submit();
    }
}

function searchByClients() {
    if (($('#PageNumberClients').length) && ($('#PageNumberClients').length)) {
        $('#PageNumberClients').val(1);
        $("#btnSubmitClients").submit();
    }
}

function _ajax_delete_from_grid(id, controller) {

    var url1 = '/' + controller + '/ajax_delete';

    $.ajax({

        type: 'POST',
        url: url1,
        data: { "id": id },
        success: function (data) {
            if (data) {
                $("#btnSubmit").submit();
                semg_alert(msg_02);
            }
            else {
                semg_error(msg_err_gral);
            }
        },
        error: function (result) {
            semg_error(msg_err_gral);
        }
    });
}



//id = Id del objeto
//g = Objeto Grid (id)
//d = Objeto dropdown id (tamaño página)
//controller = nombre del controlador
function _ajax_restore_from_grid(id, g, d, controller) {

    var url1 = '/' + controller + '/ajax_restore';
    var url2 = '/' + controller + '/ajax_pager_get_all';

    $.ajax({

        type: 'POST',
        url: url1,
        dataType: "html",
        data: { "id": id },
        success: function (data) {
            _ajax_grid_page_size(controller, g, d);
            semg_alert(msg_06);
        },
        error: function (result) {
            semg_error(msg_err_gral);
        }
    });
}

//=======END funciones GRID ===============