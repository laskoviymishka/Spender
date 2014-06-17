ExpensesController = function($scope, $http, $modal, broadcasterService) {
    var getExpensesUri = 'api/Expenses/GetExpenses';
    $scope.init = function() {
        $http.get(getExpensesUri).success(function(result) {
            $scope.expenses = result;
            console.log("init bill exp", result);
        }).error(broadcasterService.error);
    };

    $scope.addExpense = function() {
        $modal.open({
            templateUrl: 'MyInfo/AddExpense',
            controller: addExpenseModalCntl,
            size: 'lg'
        });
    };

    $scope.$on('expenseModalInstanceClosed', function() {
        $http.get(getExpensesUri).success(function(result) {
            $scope.expenses = result;
        }).error(broadcasterService.error);
    });
};

addExpenseModalCntl = function($scope, $http, $modalInstance, $upload, broadcasterService) {
    $scope.model = {};
    $scope.model.Date = new Date;
    var getCategories = 'api/Categories/GetExpenseCategories';
    $http.get(getCategories).success(function(categries) {
        $scope.categories = categries;
    }).error(broadcasterService.error);
    $scope.onFileSelect = function($files) {
        $scope.file = $files[0];

    };

    $scope.save = function() {
        var file = $scope.file;
        var uriTemplate = 'api/Expenses/PostFormData/{name}&={note}&={categoryId}&={amount}&={date}';
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
                event: 'expenseModalInstanceClosed',
                msg: ''
            });
        });
    };

    $scope.cancel = function() {
        $modalInstance.dismiss('cancel');
    };
};