
angular.module("umbraco.resources")
	.factory("customformResource", function ($http) {
	    return {
	        getAll: function (formname) {
	            return $http.get("backoffice/CustomForms/CustomFormApi/GetAll?formname=" + formname);
	        }
	    };
	});