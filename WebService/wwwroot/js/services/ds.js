define(['jquery', 'knockout'], function ($, ko) {


    var getPosts = function (url, callback) {
        url = url === undefined ? "api/questions" : url;
        $.getJSON(url, callback);
    };


    var getPost = function (url, callback) {
        $.getJSON(url, callback);
    };

//need a search function here
    var searchPosts = function (terms, callback){
        $.getJSON("api/questions/name" + terms +"", callback)

    };

    var getWords = function (callback) {
        $.getJSON('api/words', function (data) {
            callback(data);
        });
    };
    return {
        getPosts,
        getPost,
        searchPosts,
        getWords
    };

});