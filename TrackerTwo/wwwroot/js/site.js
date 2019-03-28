﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('.done-checkbox').on('click', function (e) {
        DisableLicenceItem(e.target);
    });
});

function DisableLicenceItem(checkbox) {
    checkbox.disabled = true;
    var row = checkbox.closest('tr');
    $(row).addClass('done');
    var form = checkbox.closest('form');
    form.submit();
}
