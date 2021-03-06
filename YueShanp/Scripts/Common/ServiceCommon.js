var Customer = (function () {
    function Customer(id) {
        this.Id = id;
    }
    return Customer;
})();
var DeliveryOrderDetail = (function () {
    function DeliveryOrderDetail(qty, product) {
        this.Qty = qty;
        this.Product = product;
    }
    return DeliveryOrderDetail;
})();
var Product = (function () {
    function Product(id, productName, unitPrice) {
        this.Id = id;
        this.ProductName = productName;
        this.UnitPrice = unitPrice;
    }
    return Product;
})();
(function (angular) {
    angular.module('ServiceCommon', [])
        .constant('YSConfig', {
        HostUrl: 'http://localhost:11074'
    })
        .factory('YSService', ['$http', '$q', 'YSConfig',
        function ($http, $q, YSConfig) {
            var hostUrl = YSConfig.HostUrl;
            var addDeliveryOrderUrl = hostUrl + "/ajax/AddDeliveryOrder";
            var getCustomerListUrl = hostUrl + "/ajax/GetCustomerList";
            var getProductListUrl = hostUrl + "/ajax/GetProductList";
            function PostDeliveryOrder(config) {
                var deferred = $q.defer();
                var opts = {
                    url: addDeliveryOrderUrl,
                    method: 'POST'
                };
                angular.extend(opts, config);
                $http(opts).then(function (response) {
                    debugger;
                    var responseObj = response.data;
                    if (responseObj) {
                        if (responseObj.IsSuccess) {
                            deferred.resolve(responseObj);
                        }
                    }
                    deferred.reject('Data not found.');
                }, function (response) {
                    deferred.reject(response);
                });
                return deferred.promise;
            }
            ;
            function GetCustomerList() {
                var deferred = $q.defer();
                var opts = {
                    url: getCustomerListUrl,
                    method: 'GET'
                };
                $http(opts).then(function (response) {
                    var obj = response.data;
                    var customerList = [];
                    if (obj && obj.IsSuccess) {
                        angular.forEach(obj.Customers, function (value, key) {
                            customerList.push(value);
                        });
                        deferred.resolve(customerList);
                    }
                    else {
                        deferred.reject('Data not found.');
                    }
                }, function (response) {
                    deferred.reject(response);
                });
                return deferred.promise;
            }
            function GetProductList(customerId) {
                var deferred = $q.defer();
                var opts = {
                    url: getProductListUrl + '/' + customerId,
                    method: 'GET'
                };
                $http(opts).then(function (response) {
                    var obj = response.data;
                    var productList = [];
                    if (obj && obj.IsSuccess) {
                        angular.forEach(obj.Products, function (value, key) {
                            productList.push(value);
                        });
                        deferred.resolve(productList);
                    }
                    else {
                        deferred.reject('Data not found.');
                    }
                }, function (response) {
                    deferred.reject(response);
                });
                return deferred.promise;
            }
            return {
                PostDeliveryOrder: PostDeliveryOrder,
                GetCustomerList: GetCustomerList,
                GetProductList: GetProductList
            };
        }]);
})(angular);
//# sourceMappingURL=ServiceCommon.js.map