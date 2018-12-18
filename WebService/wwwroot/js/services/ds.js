define(['jquery', 'knockout'], function ($, ko) {


    //get functions
    var getPosts = function (url, callback) {
        url = url === undefined ? "api/questions" : url;
        $.getJSON(url, callback);
    };


    var getPost = function (url, callback) {
        $.getJSON(url, callback);
    };
/*
    var getWords = function (callback) {
        $.getJSON('api/wordCloud', function (data) {
            callback(data);
        });
    };
    */

    var searchPosts = function (terms, callback) {
        $.getJSON("api/questions/name/" + terms, callback)

    };

    var getUser = function (userId, callback) {
        $.getJSON("api/users/" + userId, callback)
    };

    //var getSearchHistory = function (userId, callback) {
    //    $.getJSON("api/searchhistory/" + userId, callback);

    //};
    var getSearchHistory = function (url, callback) {
        $.getJSON(url, callback);

    };
    //var getAnnotations = function (userId, callback) {
    //    $.getJSON("api/annotations/" + userId, callback)

    //};
    var getAnnotations = function (url, callback) {
        $.getJSON(url, callback)

    };

    var getMarks = function (url, callback) {
        $.getJSON(url, callback)
    };

    //post functions maybe delete. would be nice to finish
    var postSearch = function (postData) {
        $.ajax({
            type: 'POST',
            url: 'api/searchhistory/add/',
            // The key needs to match your method's input parameter (case-sensitive).
            data: JSON.stringify(postData),
            contentType: 'application/json'
        }); 
    }

    var createcloud = function (term, callback) {
        $.getJSON("api/wordCloud/" + term + "", function (data) {
            callback(data)
        })
    };


    return {
        getPosts,
        getPost,
       // getWords,
        createcloud,
        searchPosts,
        getSearchHistory,
        getAnnotations,
        getUser,
        getMarks,
        postSearch,
        searchPosts,
        //createcloud
    };

});