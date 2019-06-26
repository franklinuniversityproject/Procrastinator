
var index = 1;
initialize();


/*initialize and defaults*/
function initialize(item) {
    model.DefaultEvents.forEach(createDefault);
    cloneRow();
}

function createDefault(item) {
    cloneRow();
    $('#eventSelector' + index).val(item.EventDescription);
    $('#hourSelector' + index).val(item.Hours);
    $('#minuteSelector' + index).val(item.Minutes);
    $('#weekday-mon' + index).attr('checked', item.Weekdays[0]);
    $('#weekday-tue' + index).attr('checked', item.Weekdays[1]);
    $('#weekday-wed' + index).attr('checked', item.Weekdays[2]);
    $('#weekday-thu' + index).attr('checked', item.Weekdays[3]);
    $('#weekday-fri' + index).attr('checked', item.Weekdays[4]);
    $('#weekday-sat' + index).attr('checked', item.Weekdays[5]);
    $('#weekday-sun' + index).attr('checked', item.Weekdays[6]);
}



/*clone*/
$("#addEvent").click(function () {
    cloneRow();
});

$('body').on('click', '.glyphicon-trash', function () {
    $(this).parent().parent('div').remove();
});


function cloneRow() {
    index++;
    var newRow = $("#eventContainer").clone(true, true);

    newRow.find("input").each(function () {
        $(this).attr('id', $(this).attr('id') + index);
    });

    newRow.find("label").each(function () {
        $(this).attr('for', $(this).attr('for') + index);
    });

    $(newRow).insertBefore('#end');
    newRow.show();
}

