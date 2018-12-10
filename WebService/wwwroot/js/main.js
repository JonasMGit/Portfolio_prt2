
require.config({
    baseUrl: "js",
    paths: {
        jquery: "lib/jQuery/dist/jquery.min",
        knockout: "lib/knockout/dist/knockout.debug",
        dataService: "services/ds",
        text: "lib/text/text",
        postman: 'services/postman'

    }
});

require(['knockout', 'app/questions'], function (ko, questionVm) {
    ko.applyBindings(questionVm);
});