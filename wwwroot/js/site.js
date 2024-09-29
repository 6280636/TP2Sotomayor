// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

$(document).ready(function () {

    $('tr.trainer-item').hover(function () {

        $(this).toggleClass("highlight");
    });


    // summernote

    $('.summernote').summernote({
        placeholder: 'Description ...',
        tabsize: 200,
        //height: 120,
        toolbar: [
            // Limiter les outils visibles
            ['style', ['bold', 'italic']],
            ['font', ['fontname']],
            ['para', ['ul', 'ol']]
        ]

    });
   
    var noteBar = $('.note-toolbar');
    noteBar.find('[data-toggle]').each(function () {
        $(this).attr('data-bs-toggle', $(this).attr('data-toggle')).removeAttr('data-toggle');
    });

});
