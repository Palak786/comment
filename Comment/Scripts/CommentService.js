(function(app) {
    var commentService = function($http, commentApiUrl) {
        var getAll = function() {
            return $http.get(commentApiUrl);
        };

        var getById = function(id) {
            return $http.get(commentApiUrl + id);
        };

        var update = function(comment) {
            return $http.put(commentApiUrl + comment.Id, comment);
        };

        var create = function (comment) {
           console.log(JSON.stringify(comment));
            return $http.post(commentApiUrl, comment);
        };

        var destroy = function(id) {
            return $http.delete(commentApiUrl + id);
        };

        return {
            getAll: getAll,
            getById: getById,
            update: update,
            create: create,
            delete: destroy
        };
    };
    app.factory("commentService", commentService);
}(angular.module("theComment")));