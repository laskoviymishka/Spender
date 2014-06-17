IncomesController = function($scope, $http, $modal, broadcasterService) {
    var getExpensesUri = 'api/Income/GetIncomes';
    $scope.init = function() {
        $http.get(getExpensesUri).success(function(result) {
            $scope.incomes = result;
            console.log("init bill inc", result);
        }).error(broadcasterService.error);
    };

    $scope.addIncome = function() {
        $modal.open({
            templateUrl: 'MyInfo/AddIncome',
            controller: addIncomeModalCntl,
            size: 'lg'
        });
    };

    $scope.$on('incomeModalInstanceClosed', function() {
        $http.get(getExpensesUri).success(function(result) {
            $scope.incomes = result;
        }).error(broadcasterService.error);
    });
};


addIncomeModalCntl = function($scope, $http, $modalInstance, $upload, broadcasterService) {
    $scope.model = {};
    $scope.model.Date = new Date;
    var getCategories = 'api/Categories/GetIncomeCategories';
    $http.get(getCategories).success(function(categries) {
        $scope.categories = categries;
    }).error(broadcasterService.error);
    $scope.onFileSelect = function($files) {
        $scope.file = $files[0];

    };

    $scope.save = function() {
        var file = $scope.file;
        var uriTemplate = 'api/Incomes/PostFormData/{name}&={note}&={categoryId}&={amount}&={date}';
        var uriPost = uriTemplate.replace('{name}', $scope.model.Name)
            .replace('{note}', $scope.model.Note)
            .replace('{categoryId}', $scope.model.CategoryId)
            .replace('{amount}', $scope.model.Amount)
            .replace('{date}', $scope.model.Date);
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
                event: 'incomeModalInstanceClosed',
                msg: ''
            });
        });
    };

    $scope.cancel = function() {
        $modalInstance.dismiss('cancel');
    };
};