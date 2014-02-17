angular.module('cpuApp').controller('CpuCtrl', function ($scope, cpu) {
    $scope.value1 = 0;

    cpu.client.updateCpuUtilization = function onUpdateCpuUtilization(value) {
        $scope.value1 = value;
        $scope.$apply();
    };
});