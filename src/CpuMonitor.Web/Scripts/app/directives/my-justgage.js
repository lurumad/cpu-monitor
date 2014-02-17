angular.module('cpuApp').directive('myJustgage', ['$timeout', function($timeout) {
    return {
        restrict: 'EA',
        scope: {
            id: '@',
            value: '='
        },
        template: '<div id="{{id}}-justgage"></div>',
        link: function (scope) {
            $timeout(function() {
                var justGage = new JustGage({
                    id: scope.id + '-justgage',
                    value: scope.value,
                    min: 0,
                    max: 100,
                    title: "CPU",
                    label: "%",
                });

                scope.$watch('value', function (newValue) {
                    justGage.refresh(newValue);
                }, 0);
            });
        }
    };
}]);