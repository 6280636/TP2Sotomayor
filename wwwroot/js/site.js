
// Write your JavaScript code.

$(document).ready(function () {

    $('tr.trainer-item').hover(function () {

        $(this).toggleClass("highlight");
    });

    $('.summernote').summernote({
        placeholder: 'Description ...',
        height: 200,        
        toolbar: [
            ['style', ['bold', 'italic']],
            ['font', ['fontname', 'fontsize']],
            ['para', ['ul', 'ol']]  
        ]
    });
});
var noteBar = $('.note-toolbar');
noteBar.find('[data-toggle]').each(function () {
    $(this).attr('data-bs-toggle', $(this).attr('data-toggle')).removeAttr('data-toggle');
});
