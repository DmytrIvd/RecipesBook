// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function readURL(input,updateDisplay) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            console.log($(`#${updateDisplay}`));
            $(`#${updateDisplay}`).attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}