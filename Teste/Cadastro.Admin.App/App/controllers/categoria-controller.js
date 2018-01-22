'use strict';

var app = angular.module("categoriaApp", []);
app.controller("categoriaCtrl", function ($scope, $http) {
    $scope.title = "Categoria";

    $scope.AddCategoria = function (categoria) {

        $http({
            method: "POST",
            url: "/Categoria/IncluiCategoria",
            data: { novaCategoria: categoria }
        }).then(function mySuccess(data) {
            if (data.retorno === true) {
                alert("Cadastro Realizado com sucesso!");
                delete $scope.categoria;
            }
            else {
                alert("O cadastro não pdoe ser concluido!");
            }
        }, function myError(data) {
            alert("Erro durante processamento!" + data.error);
        });
    }


    $scope.ListaCategoria = function () {
        $http({
            method: "GET",
            url: "/Categoria/ListaCategoria"
        }).then(function mySuccess(response) {
       

            if (response.data == true) {
                var categorias = [];
                angular.forEach(response.data, function (item) {
                    categorias.push({ 'ca':item });
                });
                alert(categorias);
                $scope.categorias = categorias;
            } else
                alert("Erro durante processamento!" + data.error);

        }, function myError(response) {
            alert("Erro durante processamento!" + response.data);
        });
    }

    $scope.ListaCategoria();

    //.success(function (data, status, headers, config) {
    //            if (data.retorno === true) {
    //                alert("Cadastro Realizado com sucesso!");
    //                delete $scope.categoria;
    //            }
    //            else {
    //                alert("O cadastro não pdoe ser concluido!");
    //            }
    //        }).error(function (data, status, headers, config) {
    //            alert("Erro durante processamento!" + data.error);
    //        });
    //};

    //$http({
    //    method: "POST",
    //    url: "/Categoria/IncluirCategoria",
    //    data: { novaCategoria: categoria }
    //}).then(function mySuccess(response) {
    //    alert("Cadastro Realizado com sucesso!");
    //    delete $scope.categoria;
    //}, function myError(response) {
    //    $scope.error = "Ocorreu um erro durante o cadastro!"
    //});
    //}
});