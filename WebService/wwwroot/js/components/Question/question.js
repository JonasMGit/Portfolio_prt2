define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {

    return function (params) {

        var currentPost = ko.observable();
        var currentComponent = ko.observable("question");
        var hasAnswers = ko.observable(false);
        var curLink = params.link;
   

        var getPost = function (url) {
            ds.getPost(url, function (data) {
                $.getJSON(data.answers, function (answers) {
                    hasAnswers(answers && answers.length > 0);
                    data.answers = answers;
                    currentPost(data)

                });
            });
        }

        getPost(curLink);

        var back = function () {
            ds.getPosts("api/questions");
            postman.publish("selectedComponent", { item: "question-list", params: {} });

        };



        return {
            getPost,
            currentPost,
            hasAnswers,
            back,
            currentComponent



        };
    };
});