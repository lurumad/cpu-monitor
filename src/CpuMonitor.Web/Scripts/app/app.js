(function() {
    var cpuApp = angular.module('cpuApp', []);

    $(function () {
        $.connection.hub.logging = true;
        $.connection.hub.start();
    });

    cpuApp.value('cpu', $.connection.cpu);
})();

