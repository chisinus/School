var sportsStore = angular.module("sportsStore", ["customFilters"]);

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
    $http.get("http://localhost:20003/api/SportsStoreWebAPI/GetProducts")
         .success(function(data, status, headers, config)
         {
             $scope.products = data;
         })
         .error(function(data, status, headers, config)
         {
             alert("error");
         });
});


// does not work. how to call a controller method?
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
