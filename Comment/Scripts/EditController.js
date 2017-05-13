(function(app) {
    var EditController = function ($scope, commentService) {

        $scope.isEditable = function () {
            return $scope.edit && $scope.edit.comment;
        };

        $scope.cancel = function() {
            $scope.edit.comment = null;
        };

        $scope.save = function () {
            if ($scope.edit.comment.Id) {
                updateComment();
            } else {
                createComment();
            }
        };
        $scope.comment = [];
        var updateComment = function() {
            commentService.update($scope.edit.comment)
                    .then(function () {
                    angular.extend($scope.comment, $scope.edit.comment);
                    $scope.edit.comment = null;
                });
        };

        var createComment = function () {
            commentService.create($scope.edit.comment)
                .then(function () {
                    $scope.comment.push($scope.edit.comment);
                    $scope.edit.comment= null;
                });
        };
    };
    app.controller("EditController", EditController);
}(angular.module("theComment")));