(function () {
    var app = angular.module("theComment", ["ngRoute"]);
    var config = function ($routeProvider) {
            $routeProvider
            .when("/list",
                { templateUrl: "/CommentApp/Views/list.html", controller: "ListController" })
            .when("/details/:id",
                { templateUrl: "/CommentApp/Views/details.html", controller: "DetailsController" })
            .otherwise(
                { redirectTo: "/list", controller: "ListController" });
           };

    app.config(config);
    app.constant("commentApiUrl", "/api/comment/");
}());


