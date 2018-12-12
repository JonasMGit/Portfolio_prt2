define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {

    return function (params) {

        var currentPostAnswer = ko.observable();
        var currentPostComment = ko.observable();
         
        var currentComponent = ko.observable("question");
        var hasAnswers = ko.observable(false);
        var curLink = params.link;
   

        var getPostAnswers = function (url) {
            ds.getPost(url, function (data) {
                $.getJSON(data.answers, function (answers) {
                    hasAnswers(answers && answers.length > 0);
                    data.answers = answers;

                    $.getJSON(data.comments, function (comments) {
                        data.comments = comments;
                        console.log(comments);
                        //currentPostComment(comments)
                    });
                    currentPostAnswer(data);

                });
                

            });
        }

        //var getPostComments = function (url) {

        //    ds.getPost(url, function (data) {
        //        $.getJSON(data.comments, function (comments) {
        //            data.comments = comments;
        //            currentPostComment(data.comments);
        //        });
        //    });
        //}

        getPostAnswers(curLink);
       // getPostComments(curLink);

        var back = function () {
            //ds.getPosts("api/questions");
            postman.publish("selectedComponent", { item: "question-list", params: {} });

        };



        return {
            getPostAnswers,
            
            currentPostAnswer,
            currentPostComment,
            hasAnswers,
            back,
            currentComponent



        };
    };
});