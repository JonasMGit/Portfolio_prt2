define(['knockout', 'dataService', "jquery", "postman"], function (ko, ds, $, postman) {

    return function (params) {
        var userInfo = ko.observable();
        var annotationInfo = ko.observableArray([]);
        var searchInfo = ko.observableArray([]);
        var userName = ko.observable();
        var markInfo = ko.observableArray([]);
        var annoId = ko.observableArray([params.id])
        //need to transfer this between components. questionList, and question. needs to be used multiple places
        var staticUser = "13";

        var getUser = function (userid) {
            ds.getUser(userid, function (data) {
                userInfo(data);
                userName(data.userName);

            })
        }
        var getAnnotations = function (userid) {
            ds.getAnnotations(userid, function (data) {
                console.log(data.items);
                annotationInfo(data.items);
               

            })
        }

        var getSearchHistory = function (userid) {
            ds.getSearchHistory(userid, function (data) {
                console.log(data);

                searchInfo(data);

            })
        }

        var getMarks = function (userid) {
            ds.getMarks(userid, function (data) {
                console.log(data.items)
                markInfo(data.items);
            })
        }
        

        var deleteAnno = function (id) {
            console.log(id)

          /*  $.ajax({
                url: 'api/annotations/'+ id,
                type: 'DELETE',
                data: JSON.stringify({id: id}),
                contentType: 'application/json'
                
            });*/
        }


        
        getUser(staticUser);

        getAnnotations(staticUser);

        getSearchHistory(staticUser);

        getMarks(staticUser);



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
            deleteAnno


        };
    };
});