app.factory('broadcasterService', function ($rootScope, $http, $modal) {
    return {
        broadcast: function (info) {
            console.log('searchInfoSetted', info);
            $rootScope.$broadcast(info.event, info.msg);
        },
        error: function (error) {
            $modal.open({
                size: 'lg',
                template: error
            });
        }
    };
});