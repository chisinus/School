var customFilters = angular.module("customFilters", []);
customFilters.filter("unique", function () {
    return function (data, propertyName) {
        if (!angular.isArray(data) || !angular.isString(propertyName))
            return data;

        var results = [];
        var keys = [];

        for (var i = 0; i < data.length; i++) {
            var val = data[i][propertyName];
            if (angular.isUndefined(keys[val])) {
                keys[val] = true;
                results.push(val);
            }
        }

        return results;
    }
});

var sportsStore = angular.module("sportsStore", ["customFilters"]);

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


