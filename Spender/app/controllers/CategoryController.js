CategoryController = function ($scope, $http, $modal, broadcasterService) {
    var getCategiriesUri = 'api/Categories/GetUserCategories';

    $scope.categories = [];

    $scope.init = function () {
        $http.get(getCategiriesUri).success(function (result) {
            console.log(getCategiriesUri, result);
            $scope.categories = result;
        }).error(broadcasterService.error);
    };

    $scope.addCategory = function () {
        $modal.open({
            templateUrl: 'MyInfo/AddCategory',
            controller: addCategoryModalCntl,
            size: 'lg'
        });
    };

    $scope.$on('categoryModalInstanceClosed', function (event, data) {
        $scope.categories = [];
        $http.get(getCategiriesUri).success(function (result) {
            console.log(getCategiriesUri, result);
            $scope.categories = result;
        }).error(broadcasterService.error);
    });
};

addCategoryModalCntl = function ($scope, $http, $modalInstance, $upload, broadcasterService) {
    $scope.model = { Name: 'Category Name', Type: 0 };
    $scope.types = [{ Id: 1, Name: "income" }, { Id: 0, Name: "Expense" }];
    $scope.onFileSelect = function ($files) {
        $scope.file = $files[0];

    };

    $scope.save = function () {
        var file = $scope.file;
        var uriPost = 'api/Categories/PostFormData/' + $scope.model.Name + '/' + $scope.model.Type;
        $scope.upload = $upload.upload({
            url: uriPost,
            file: file
        }).progress(function (evt) {
            console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
        }).success(function (data, status, headers, config) {
            console.log(data);
        }).then(function () {
            $modalInstance.close();
            broadcasterService.broadcast({
                event: 'categoryModalInstanceClosed',
                msg: ''
            });
        });
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
};