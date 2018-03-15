
//mySite.js
(function () {


    //var ele = $("#username");
    //ele.text("My G.U.D");

    //var main1 = $("#main1");

    var $sidebarAndWrapper = $("#sidebar,#wrapper");

    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $(this).text("Show sidebar");
        }
        else {
            $(this).text("hide sidebar");
        }
    });

})();
