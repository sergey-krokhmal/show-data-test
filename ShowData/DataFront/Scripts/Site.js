$(document).ready(()=>{
    loadFromCoockie();

    $('.error-modal').on('hidden.bs.modal', function (e) {
        $('.error-modal .error-code').html('');
        $('.error-modal .error-message').html('');
    });
});

var mainDateTimeFormat = "DD.MM.YYYY HH:mm:ss";
var mainDateFormat = "DD.MM.YYYY";

function showData()
{
    var color = $('#inputColorpicker1').val();
    var font = $('#fontSelect1').val();
    
    var dateFrom = $('#dateFromPicker1').val();
    var momentDateFrom = moment(dateFrom + ' 00:00:00', mainDateTimeFormat);
    momentDateFrom.utc();

    var dateTo = $('#dateToPicker1').val();
    var momentDateTo = moment(dateTo + ' 23:59:59', mainDateTimeFormat);
    momentDateTo.utc();

    saveToCoockies(color, font, dateFrom, dateTo);

    var query = $('.get-data-form').serialize();
    $.ajax({
        url: 'http://localhost:25136/DataService.svc/GetDataRecords',
        data: { "from": momentDateFrom.format(mainDateTimeFormat), "to": momentDateTo.format(mainDateTimeFormat)},
        success: function (data) {
            $('.table-panel').css('color', color);
            $('.table-panel').css('font-family', font);
            if (data !== undefined) {
                if (data.sc == true && data.val != null) {
                    $('.table-container').html('');
                    if (data.val.length > 0) {
                        var table = makeHtmlDataTable(data.val);
                        $('.table-container').html(table);
                        $('.no-data-mark').hide();
                        $('.table-panel').removeClass('hide');
                    } else {
                        $('.no-data-mark').show();
                    }
                    $('table-panel').show();
                } else {
                    $('.error-modal .error-code').html(data.cd);
                    $('.error-modal .error-message').html(data.er);
                    $('.error-modal').modal();
                }
            }
        },
        dataType: 'json'
    });
}

function saveToCoockies(color, font, dateFrom, dateTo) {
    var exp = 1;
    $.cookie('text_color', color, {
        expires: exp
    });
    $.cookie('text_font', font, {
        expires: exp
    });
    $.cookie('date_from', dateFrom, {
        expires: exp
    });
    $.cookie('date_to', dateTo, {
        expires: exp
    });
}

function loadFromCoockie() {
    var color = $.cookie('text_color');
    if (color !== undefined) {
        $('#inputColorpicker1').val(color);
    }
    var font = $.cookie('text_font');
    if (font !== undefined) {
        $('#fontSelect1').val(font);
    }
    var dateFrom = $.cookie('date_from');
    if (dateFrom !== undefined) {
        $('#dateFromPicker1').val(dateFrom);
    }
    var dateTo = $.cookie('date_to')
    if (dateTo !== undefined) {
        $('#dateToPicker1').val(dateTo);
    }
}

function makeHtmlDataTable(dataArray) {
    var table = '<div class="table-responsive"><table class="table">';
    table += '<tr>' +
            '<th class="id">Id</th>' +
            '<th class="date">Date</th>' +
            '<th class="text">Text</th>' +
        '</tr>';
    for (i = 0; i < dataArray.length; i++) {
        var dtMoment = moment(dataArray[i].dt, mainDateTimeFormat);
        dtMoment.local();
        var dtFormated = dtMoment.format(mainDateFormat);
        var row =
            '<tr>' +
                '<td class="id">' + dataArray[i].id + '</td>' +
            '<td class="date">' + dtFormated + '</td>' +
                '<td class="text">' + dataArray[i].txt + '</td>' +
            '</tr>';
        table += row;
    }
    table += '</table></div>';
    return table;
}