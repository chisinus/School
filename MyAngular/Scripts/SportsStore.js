var sportsStore = angular.module("sportsStore", ["ngRoute", "customFilters", "cart"]);

sportsStore.config(['$routeProvider', function ($routerProvider) {
    $routerProvider.when("/checkout", { templateUrl: "/Views/SportsStore/CheckoutSummary.html" });
    $routerProvider.when("/products", { templateUrl: "/Views/SportsStore/ProductList.html" });
    $routerProvider.when("/placeoorder", { templateUrl: "/Views/SportsStore/PlaceOrder.html" });
    $routerProvider.when("/complete", { templateUrl: "/Views/SportsStore/ThankYou.html" });
    $routerProvider.otherwise({ templateUrl: "/Views/SportsStore/ProductList.html" });
}]);

/* Hard coded
sportsStore.controller("sportsStoreCtrl", function ($scope) {
    $scope.data = {
        products: [
                    {
                        name: "Product #1", description: "A product",
                        category: "Category #1", price: 100
                    },
                    {
                        name: "Product #2", description: "A product",
                        category: "Category #1", price: 110
                    },
                    {
                        name: "Product #3", description: "A product",
                        category: "Category #2", price: 210
                    },
                    {
                        name: "Product #4", description: "A product",
                        category: "Category #3", price: 202
                    }]
    }
});
*/

/* Web api*/
sportsStore.controller("sportsStoreCtrl", function ($scope, $http) {
    $scope.data = {};

    $http.get("http://localhost:20003/api/SportsStoreWebAPI/aaa")
         .success(function(data, status, headers, config)
         {
             console.log(data.length);
             $scope.data.products = data;
             $scope.data.error = false;
         })
         .error(function(data, status, headers, config)
         {
             $scope.data.error = true;
         });
});


// does not work. how to call a controller method for web form?
//sportsStore.constant("dataUrl", "/SportsStore/GetProducts")
//    .controller("sportsStoreCtrl", function ($scope, $http, dataUrl) {
//        $http.get(dataUrl)
//         .success(function (data, status, headers, config) {
//             $scope.products = [];
//             console.log($scope.products.length);
//             $scope.products.push(data);
//             console.log($scope.products.length);
//             console.log($scope.products);
//         })
//         .error(function (data, status, headers, config) {
//             alert("error");
//         });
//    });
