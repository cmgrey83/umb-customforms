angular.module("umbraco").controller("CustomForms.FormEditController",
	function ($scope, $routeParams, customformResource, $filter) {
	    $scope.content = { tabs: [{ id: 1, label: "Form data" }] };

	    $scope.keys = function (obj) {
	        return obj ? Object.keys(obj) : [];
	    }

	    $scope.cleanOutput = function (obj, key) {
	        if (key.toLowerCase().indexOf("date") > -1 && Date.parse(obj)) {
	            return $filter('date')(new Date(obj), "dd/MM/yyyy");
	        }
	        else if(key.indexOf("$$") > -1)
	        {
	            return "";
	        }
	        else {
	            return obj;
	        }
	    };

	    customformResource.getAll($routeParams.id).then(function (response) {
	        $scope.records = response.data;
	        $scope.loaded = true;
	    });
	}
	
);