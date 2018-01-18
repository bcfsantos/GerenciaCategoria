'use strict';

var app = angular.module("categoriaApp", []);
app.controller("categoriaCtrl", function ($scope, $http) {
    $scope.title = "teste";

    $scope.AddCategoria = function (categoria) {
        $http.post('/Categoria/IncluirCategoria/', { novaCategoria: categoria })
        .success(function (result) {
            $scope.categoria = result;
            delete $scope.categoria;
        })
        .error(function (data) {
            console.log(data);
        });
    }

});