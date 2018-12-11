define(['jquery'], function ($) {







    var getWords = function (callback) {
        $.getJSON('api/words', function (data) {
            callback(data);
        });
    };
    return {
        getWords

    };
});