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

customFilters.filter("range", function ($filter) {
    return function (data, page, size) {
        if (!angular.isArray(data) || !angular.isNumber(page) || !angular.isNumber(size))
            return data;

        var start_index = (page-1) * size;

        return (data.length < start_index)
                    ? []
                    : $filter("limitTo")(data.splice(start_index), size);
        }
});

customFilters.filter("pageCount", function () {
    return function(data, size)
    {
        if (!angular.isArray(data)) return data;

        var result = [];
        for (var i=0; i<Math.ceil(data.length/size); i++)
        {
            result.push(i);
        }

        return result;
    }
});