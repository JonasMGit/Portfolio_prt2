define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {

    return function (params) {
        var posts = ko.observableArray([]);
        var currentComponent = ko.observable("question")
        var canPrev = ko.observable(false);
        var prevUrl = "";
        var canNext = ko.observable(false);
        var nextUrl = "";
        var searchVal = "";



        var getPosts = function (url) {

            ds.getPosts(url, function (data) {
                curUrl = data.cur;
                prevUrl = data.prev;
                canPrev(false);
                data.prev !== null && canPrev(true);
                nextUrl = data.next;
                canNext(false);
                data.next !== null && canNext(true);
                posts(data.items);
            });
        };

        var getSearch = function (terms) {
            ds.searchPosts(terms, function (data) {
                searchVal = data.terms
                posts(data.items);
            })

        }

        

        var next = function () {
            getPosts(nextUrl);
        };

        var prev = function () {
            getPosts(prevUrl);
        };

        var searchPost = function () {
            getSearch(searchVal)

        }

        var showPost = function (post) {

            postman.publish("selectedComponent", { item: "question", params: { link: post.link } });
        };

        getPosts();

        return {
            posts,
            prev,
            canPrev,
            searchPost,
            next,
            canNext,


            // selectComponent,
            showPost,
            currentComponent


        };

    };

});