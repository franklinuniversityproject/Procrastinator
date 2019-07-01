var index = 1;
var newRow = $("#courseContainer").clone(true, true);
newRow.show();
$('#subject', newRow).prop('id', 'subject' + index);
$('#course', newRow).attr('id', 'course' + index);
$('#remove', newRow).attr('id', 'remove' + index);

$(newRow).insertBefore('#end');

$(function () {
    $("[name='SelectedSubjectType']").on("change", function () {
        var index = jQuery(this).attr("id").replace("subject", "");
        var selectedSubject = $(this).find(":selected").val();

        $.ajax({
            type: 'POST',
            url: "/Home/GetCourses",
            dataType: "json",
            data: { subjectTypeId: selectedSubject },
            success: function (data) {
                var $dropdown = $("#course" + index);
                $dropdown.empty();
                $("#course" + index).append($("<option />").val('').text('Select a Course'));
                $.each(data, function () {
                    $dropdown.append($("<option />").val(this.Id).text(this.CourseCode + ' ' + this.Description));
                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("some error");
            }
        });
    });
});

$("#addCourse").click(function () {
    index++;
    var newRow = $("#courseContainer").clone(true, true);
    newRow.show();
    $('#subject', newRow).prop('id', 'subject' + index);
    $('#course', newRow).attr('id', 'course' + index);
    $('#remove', newRow).attr('id', 'remove' + index);

    $(newRow).insertBefore('#end');
});

$('body').on('click', '.glyphicon-trash', function () {
    $(this).parent().parent('div').remove();
});