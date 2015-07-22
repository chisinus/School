sportsStore.controller("cartSummaryController", function ($scope, cart) {
    $scope.cartData = cart.getCartItems();

    $scope.total = function()
    {
        var total = 0.0;
        for (var i=0; i<$scope.cartData.length; i++)
        {
            total += ($scope.cartData[i].price * $scope.cartData[i].count);
        }

        return total;
    }

    $scope.remove = function(id)
    {
        cart.removeProduct(id);
    }
});