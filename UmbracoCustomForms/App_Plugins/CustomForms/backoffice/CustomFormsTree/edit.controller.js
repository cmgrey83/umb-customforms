
var app = angular.module("umbraco");

//This is my Angular module that I want to inject/require
app.requires.push('ngSanitize');
app.requires.push('ngCsv');


app.controller("CustomForms.FormEditController",
	function ($scope, $routeParams, customformResource, $filter) {

	    $scope.content = { tabs: [{ id: 1, label: "Form data" }] };

	    $scope.keys = function (obj) {
	        obj = angular.copy(obj);

	        if (!obj) {
	            return [];
	        }
	        return Object.keys(obj);
	    }

	    $scope.fixDate = function (obj, key) {
	        if (key.toLowerCase().indexOf("date") > -1 && Date.parse(obj)) {
	            return $filter('date')(new Date(obj), "dd/MM/yyyy");
	        }
	        else {
	            return obj;
	        }
	    };

	    customformResource.getAll($routeParams.id).then(function (response) {
	        $scope.records = response.data;
	        $scope.loaded = true;
	    });

	    var getFilename = function () {
	        var today = new Date();
	        var dd = today.getDate();
	        var mm = today.getMonth() + 1;
	        var yyyy = today.getFullYear();

	        return yyyy + "_" + mm + "_" + dd + "_" + $routeParams.id + ".csv";
	    }

	    $scope.filename = getFilename();
	}

);