sportsStore.constant("productListActiveClass", "btn-primary")
           .constant("productListPageCount", 3);

sportsStore.controller("productListCtrl", function ($scope, $filter, productListActiveClass, productListPageCount) {
    var selectedCategory = null;
    $scope.selectedPage = 1;
    $scope.pageSize = productListPageCount;

    $scope.selectCategory = function (newCategory) {
        selectedCategory = newCategory;
        $scope.selectedPage = 1;
    }

    $scope.categoryFilter = function (product) {
        return selectedCategory == null ||
               product.category == selectedCategory;
    }

    $scope.getCategoryClass = function(category)
    {
        return selectedCategory == category ? productListActiveClass : "";
    }

    $scope.selectPage = function(newPage)
    {
        $scope.selectedPage = newPage;
    }

    $scope.getPageClass = function(page)
    {
        return $scope.selectedPage == page ? productListActiveClass : "";
    }
});
