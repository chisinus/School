var services = angular.module("Services", []);
Services.service("Chapter2Service", function ()
{

});

var controllers = anguler.module("Controllers", ["services"]);
Controllers.controller("Chapter2Controller", function ($scope, Chapter2Service) {

});

var MyAngularJSApp = angular.module("MyAngularJS", ["controllers", "services"]);