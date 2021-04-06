// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function () {



    var url = 'https://localhost:5001/api/album';

    fetch(url)
        .then(response => response.json())
        .then(data => console.log(data));





}());
