// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })

    $('#ImagePath,#ImageFile').on('change', function () {
        var fileName = $(this).val();
        //replace the "Choose a file" label
        $(this).next('.custom-file-label').html(fileName);
    })

    $(".banner-title").fadeIn(3000);

    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#preview-img').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]); // convert to base64 string
        }
    }

    $("#ImagePath").change(function () {
        readURL(this);
    });
    


    //$('#ImageFile').on('change', function () {
    //    //get the file name
    //    var fileName = $(this).val();
    //    //replace the "Choose a file" label
    //    $(this).next('.custom-file-label').html(fileName);
    //})
});