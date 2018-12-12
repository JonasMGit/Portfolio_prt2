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
                    console.log(answers);
                    currentPostAnswer(data);

                });
                $.getJSON(data.comments, function (comments) {
                    data.comments = comments;
                    console.log(comments.items);
                    currentPostComment(data)
                    
                });
            });
        }

       

        getPostAnswers(curLink);

        var back = function (backTerm) {
           // ds.getPosts("api/questions/name/"+ backTerm + "");
            postman.publish("selectedComponent", { item: "question-list", params: {back: params.back} });

        };



        return {
            getPostAnswers,
            //getPostComments,
            currentPostAnswer,
            currentPostComment,
            hasAnswers,
            back,
            currentComponent



        };
    };
});