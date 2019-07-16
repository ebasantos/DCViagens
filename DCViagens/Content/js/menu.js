$(document).ready(function () {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
        $('#sidebarCollapse').toggleClass('col-md-2');
        document.querySelector("#sidebar").style.class= ' col-md-12'
    });


    $('#sidebarCollapse').click();
});