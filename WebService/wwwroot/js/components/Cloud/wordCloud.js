define(['jquery', 'knockout', 'dataService', 'jqcloud'], function ($, ko, ds) {
    return function (params) {
        //var words = ko.observableArray([]);

        ds.getWords(function (data) {
            //words(data);
            $('#Cloud').jQCloud(data);
        });



        return {
        };
    };
});