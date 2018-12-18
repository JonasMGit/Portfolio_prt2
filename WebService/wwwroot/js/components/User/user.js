define(['knockout', 'dataService', "jquery", "postman"], function (ko, ds, $, postman) {

    return function (params) {
        var userInfo = ko.observable();
        var annotationInfo = ko.observableArray([]);
        var searchInfo = ko.observableArray([]);
        var userName = ko.observable();
        var markInfo = ko.observableArray([]);
        //these declarations for mark annotate and search history could probably be made in a smarter with less hard coding
        //mark declartion
        var prevUrlMark = "";
        var nextUrlMark = "";
        var canPrevMark = ko.observable(false);
        var canNextMark = ko.observable(false);

        //searchhistory url
        var prevUrlSearch = "";
        var nextUrlSearch = "";
        var canPrevSearch = ko.observable(false);
        var canNextSearch = ko.observable(false);

        //annotation declaration
        var prevUrlAnnotation = "";
        var nextUrlAnnotation = "";
        var canPrevAnnotation = ko.observable(false);
        var canNextAnnotation = ko.observable(false);

        //set userid to value in database. Also set id value in question list to same as here
        var userid = "54";


        var markUrl = "api/mark/" + userid;
        var annotationUrl = "api/annotations/" + userid;
        var searchHistoryUrl = "api/searchhistory/" + userid;

        var getUser = function (userid) {
            ds.getUser(userid, function (data) {
                userInfo(data);
                userName(data.userName);

            })
        }
        var getAnnotations = function (url) {
            ds.getAnnotations(url, function (data) {
                console.log(data.items);
                prevUrlAnnotation = data.prev;
                canPrevAnnotation(false);
                data.prev !== null && canPrevAnnotation(true);
                nextUrlAnnotation = data.next;
                canNextAnnotation(false);
                data.next !== null && canNextAnnotation(true);
                annotationInfo(data.items);
               

            })
        }

        var getSearchHistory = function (userid) {
            ds.getSearchHistory(userid, function (data) {
                console.log(data);
                prevUrlSearch = data.prev;
                canPrevSearch(false);
                data.prev !== null && canPrevSearch(true);
                nextUrlSearch = data.next;
                canNextSearch(false);
                data.next !== null && canNextSearch(true);
                searchInfo(data.searchh);

            })
        }

        var getMarks = function (url) {
            ds.getMarks(url, function (data) {
                console.log(data.items)
                total = data.total;
                // curUrl = data.cur;
                prevUrlMark = data.prev;
                canPrevMark(false);
                data.prev !== null && canPrevMark(true);
                nextUrlMark = data.next;
                canNextMark(false);
                data.next !== null && canNextMark(true);
                markInfo(data.items);
            })
        }
        //buttons
        var nextMark = function () {
          
            getMarks(nextUrlMark);
        };

        var prevMark = function () {
            getMarks(prevUrlMark);
        };

        var nextAnnotation = function () {

            getAnnotations(nextUrlAnnotation);
        };

        var prevAnnotation = function () {
            getAnnotations(prevUrlAnnotation);
        };

        var nextSearch = function () {

            getSearchHistory(nextUrlSearch);
        };

        var prevSearch = function () {
            getSearchHistory(prevUrlSearch);
        };

        

        var deleteAnno = function (data, id) {
            
            console.log(id)
            $.ajax({
                url: 'api/annotations/' + id,
                type: 'DELETE',
                data: JSON.stringify({ id: id }),
                contentType: 'application/json'

            });
            annotationInfo.remove(data);   
        }

        var deleteMark = function (data, postid, userid) {
            $.ajax({
                url: 'api/mark/',
                type: 'DELETE',
                data: JSON.stringify({ postId: postid, userId: userid  }),
                contentType: 'application/json'

            });
            markInfo.remove(data)
        }

        var deleteSearch = function (data, search, userid) {
            $.ajax({
                url: 'api/searchhistory/',
                type: 'DELETE',
                data: JSON.stringify({ search: search, userId: userid }),
                contentType: 'application/json'

            });
            searchInfo.remove(data);
        }

        var showPost = function (post) {

            postman.publish("selectedComponent", {
                item: "question", params: {
                    link: post.link,
                    userId: post.userId,
                    postId: post.postId
                }
            });
        };


        
        getUser(userid);

        getAnnotations(annotationUrl);

        getSearchHistory(searchHistoryUrl);

        //getMarks(staticUser);
        getMarks(markUrl);




        return {
            userInfo,
            userName,
            getUser,
            getAnnotations,
            getSearchHistory,
            getMarks,
            annotationInfo,
            searchInfo,
            markInfo,
            nextMark,
            prevMark,
            canPrevAnnotation,
            canNextAnnotation,
            canPrevMark,
            nextAnnotation,
            prevAnnotation,
            canNextMark,
            nextSearch,
            prevSearch,
            canNextSearch,
            canPrevSearch,
            deleteAnno,
            deleteMark,
            deleteSearch,
            showPost


        };
    };
});