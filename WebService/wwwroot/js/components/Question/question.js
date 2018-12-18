define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {

    return function (params) {

        var currentPostAnswer = ko.observable();
        var currentPostComment = ko.observable();
         
        var currentComponent = ko.observable("question");
        var hasAnswers = ko.observable(false);
        var curLink = params.link;
        var curUser = params.userId;
        var curPostId = params.postId;
        var bodyAnnotation = ko.observable("")
   
        //using dto's for answers made it overly complicated in the forntend to gain access. needed to do comments.item in html foreach
        var getPostAnswers = function (url) {
            ds.getPost(url, function (data) {
                $.getJSON(data.answers, function (answers) {
                    hasAnswers(answers && answers.length > 0);
                    data.answers = answers;
                    currentPostAnswer(data);

                });
                $.getJSON(data.comments, function (comments) {
                    data.comments = comments;
                    currentPostComment(data)
                    
                });
            });
        }
        //need to fix mark
        var mark = function () {
        
            $.ajax({
                type: 'POST',
                url: 'api/mark/',
                // The key needs to match your method's input parameter (case-sensitive).
                data: JSON.stringify({ postId: curPostId , userId: curUser }),
                contentType: 'application/json',

            });
        }
        var annotate = function () {
            $.ajax({
                type: 'POST',
                url: 'api/annotations/',
                // The key needs to match your method's input parameter (case-sensitive).
                data: JSON.stringify({ body: bodyAnnotation(), userId: curUser, postId: curPostId }),
                contentType: 'application/json',

            });
        }

        getPostAnswers(curLink);
        


        var back = function () {
           // ds.getPosts("api/questions/name/"+ backTerm + "");
            postman.publish("selectedComponent", { item: "question-list", params: {back: params.back} });

        };



        return {
            getPostAnswers,
            //getPostComments,
            currentPostAnswer,
            currentPostComment,
            bodyAnnotation,
            hasAnswers,
            back,
            mark,
            currentComponent,
            annotate



        };
    };
});