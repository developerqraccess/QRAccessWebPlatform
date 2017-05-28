$(function () {
    $('#side-menu').metisMenu();
    if ($(window).width() < 768) { 
        setTimeout(function () {     
            $('.sidebar-nav').removeAttr('aria-expanded');
            $('.sidebar-nav').removeClass('in');
            $('.sidebar-nav').addClass('collapse');

        }, 100);
    }
    
});