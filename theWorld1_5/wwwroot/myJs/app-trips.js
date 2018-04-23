// app-trips.js

(function () {
    "use strict";
    //creatting the module
    //missing "SimpleControls" (last angular Video)
    angular.module("app-trips", ["simpleControls", "ngRoute"])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                controller: "tripsController",
                controllerAs: "vm",
                templateUrl:"/views/tripsView.html"
            });

            $routeProvider.otherwise({ redirectTo:"/" });
        });




    //.config(function ($routeProvider) {

    //    $routeProvider.when("/", {
    //        controller: "tripsController",
    //        controllerAs: "vm",
    //        templateUrl: "/views/tripsView.html"
    //    });
    //    $routeProvider.otherwise({ redirectTo: "/" });
    //});
})(); 