(function (app) {
    var ListController = function ($scope, commentService) {

        commentService
            .getAll()
            .success(function (data) {
                $scope.comment = data;
            });

        $scope.create = function () {
         $scope.edit = {
                comment: {
                    Title: "",
                    Description: "",
                   
                }
            };
        };

        $scope.delete = function (comment) {
            commentService.delete(comment.Id)
                .success(function () {
                    removeCommentById(comment.Id);
                });
        };

        var removeCommentById = function (id) {
            for (var i = 0; i < $scope.comment.length; i++) {
                if ($scope.comment[i].Id == id) {
                    $scope.comment.splice(i, 1);
                    break;
                }
            }
        };
    };
    app.controller("ListController", ListController);
}(angular.module("theComment")));
