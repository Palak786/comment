(function (app) {
    var DetailsController = function ($scope, $routeParams, commentService) {
        var id = $routeParams.id;
        commentService
            .getById(id)
            .success(function(data) {
                $scope.comment = data;
            });

        $scope.edit = function () {
        $scope.edit.comment = angular.copy($scope.comment);
        };


    };
    app.controller("DetailsController", DetailsController);
}(angular.module("theComment")));