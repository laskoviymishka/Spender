BillsController = function($scope, $http, $modal, broadcasterService) {
    var getBillsUri = 'api/Bills/getAll';

    $scope.init = function() {
        $http.get(getBillsUri).success(function(result) {
            $scope.bills = result;
            console.log("init bill cat", result);
        }).error(broadcasterService.error);
    };

    $scope.addBill = function() {
        $modal.open({
            templateUrl: 'MyInfo/AddBill',
            controller: addBillModalCntl,
            size: 'sm'
        });
    };

    $scope.$on('billModalInstanceClosed', function() {
        $http.get(getBillsUri).success(function(result) {
            $scope.bills = result;
        }).error(broadcasterService.error);
    });
};


addBillModalCntl = function($scope, $http, $modalInstance, $upload, broadcasterService) {
    $scope.model = {};
    var getCategories = 'api/Categories/GetExpenseCategories';
    var getReccuring = 'api/Bills/GetReccuring';

    $http.get(getReccuring).success(function(reccuring) {
        $scope.reccuring = [];
        for (var i = 0; i < reccuring.length; i++) {
            $scope.reccuring[i] = { id: i, name: reccuring[i] };
        }
        console.log("init bill", reccuring);
    }).error(broadcasterService.error);

    $http.get(getCategories).success(function(categries) {
        $scope.categories = categries;
        console.log("init bill", categries);
    }).error(broadcasterService.error);


    $scope.onFileSelect = function($files) {
        $scope.file = $files[0];
    };

    $scope.save = function() {
        var file = $scope.file;
        var uriTemplate = 'api/Bills/PostFormData/{name}&={note}&={categoryId}&={amount}&={deadline}&={reccuring}';
        var uriPost = uriTemplate.replace('{name}', $scope.model.Name)
            .replace('{note}', $scope.model.Note)
            .replace('{categoryId}', $scope.model.CategoryId)
            .replace('{amount}', $scope.model.Amount)
            .replace('{reccuring}', $scope.model.Reccuring)
            .replace('{deadline}', $scope.model.Deadline);
        console.log(uriPost);
        $scope.upload = $upload.upload({
            url: uriPost,
            file: file
        }).progress(function(evt) {
            console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
        }).success(function(data, status, headers, config) {
            console.log(data, status, headers, config);
        }).then(function() {
            $modalInstance.close();
            broadcasterService.broadcast({
                event: 'billModalInstanceClosed',
                msg: ''
            });
        });
    };

    $scope.cancel = function() {
        $modalInstance.dismiss('cancel');
    };
};