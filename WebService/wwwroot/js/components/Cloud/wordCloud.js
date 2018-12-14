define(['jquery', 'knockout', 'dataService', 'postman','jqcloud'], function ($, ko, ds,postman) {

    return function (params) {
        var words = ko.observableArray([
        { word: "A", weight: 13 },
            { word: "B", weight: 10.5 }
        ]);
        searchVal = ko.observable("");


        var getCloud = function (word) {
            ds.getWordCloud(word, function (data) {
                words(data);
                console.log(data);

            });
        }
        var generateCloud = function () {
            //console.log(words());
             getCloud(searchVal());
           //  $('#cloud').jQCloud(words());
            
           
            
        };
        getCloud("database");

        return {
            words,
            getCloud,
            generateCloud,
            searchVal
           
        };

    };
});