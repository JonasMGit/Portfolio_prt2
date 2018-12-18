define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {

    return function (params) {
        var posts = ko.observableArray([]);
        var currentComponent = ko.observable("question")
        var canPrev = ko.observable(false);
        var prevUrl = "";
        var canNext = ko.observable(false);
        var nextUrl = "";
        var searchVal = ko.observable(params.back);
        
       // var postData = { search: searchVal(), userId: id };

        //set this id to database user value. Also set id in user viewModel staticUser()
        var userName = "Guest"
        var password = "Guest"

        //set id to the id in database under users here also set id in user.js to the same id.
        var userid = "54"

        //set up a user with post and then get the info elsewhere
        //First start of program press button generate user on the first page to make a user
        //Then write the id in the database for that user in the variable id on line 19
        var generateUser = function () {
            $.ajax({
                type: 'POST',
                url: 'api/users/',
                // The key needs to match your method's input parameter (case-sensitive).
                data: JSON.stringify({ userName: userName, password: password }),
                contentType: 'application/json',

            });
        }
       

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
                postId = data.id;
                total = data.total;
                curUrl = data.cur;
                prevUrl = data.prev;
                canPrev(false);
                data.prev !== null && canPrev(true);
                nextUrl = data.next;
                canNext(false);
                data.next !== null && canNext(true);
                posts(data.items);
            })

        }
        if (searchVal() === undefined) searchVal("")
        else getSearch(searchVal());

        

        var next = function () {
            getPosts(nextUrl);
        };

        var prev = function () {
            getPosts(prevUrl);
        };

        var searchPost = function () {

            $.ajax({
                type: 'POST',
                url: 'api/searchhistory/add/',
                // The key needs to match your method's input parameter (case-sensitive).
                data: JSON.stringify({ search: searchVal(), userId: userid }),
                contentType: 'application/json',

            });

            getSearch(searchVal())

        };

     
        var showPost = function (post) {
          
            postman.publish("selectedComponent", {
                item: "question", params: {
                    link: post.link,
                    back: searchVal(),
                    userId: userid,
                    postId: post.id
                }
            });
        };
        
       

        return {
            posts,
            prev,
            canPrev,
            searchPost,
            next,
            canNext,
            searchVal,
            showPost,
            currentComponent,
            userid,
            generateUser
            //postId


        };

    };

});