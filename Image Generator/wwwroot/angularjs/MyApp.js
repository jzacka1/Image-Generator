
var app = angular.module('myApp', []);

// Define the controller for this app module
app.controller('myCtrl', ['$scope', '$http', function ($scope, $http) {   // Using Inline Array Annotation for DI

	$scope.Search = function (e) {
		if (e === null)
			return;
			
		$http.get("api/APIReaderSplashImage/GetImageList/" + e, {
			cache: true
		})
		.then(function mySuccess(response) {
			$scope.images = response.data;
		}, function myError(response) {
			$scope.status = response.statusText;
		});
	};
}]);