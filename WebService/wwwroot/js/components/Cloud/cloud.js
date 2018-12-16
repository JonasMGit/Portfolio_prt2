define(['jquery', 'knockout', 'dataService', 'postman','jqcloud'], function ($, ko, ds,postman) {

    return function (params) {
        var words = ko.observableArray([]);
        var searchTerm = ko.observable();

        
        var generateCloud = function () {
           
            ds.createcloud(searchTerm(), function (data) {
                words(data);
            });
        };
        getCloud("database");

        return {
            words,
            generateCloud,
            searchTerm
           
        };

    };
});