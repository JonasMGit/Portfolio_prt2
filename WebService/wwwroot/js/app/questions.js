define(['jquery', 'knockout', 'postman'], function ($, ko, postman) {

    //var currentComponent = ko.observable("post-list")
    var selectedComponent = ko.observable("question-list")
    var title = ko.observable("Question")
    var selectedParams = ko.observable("");



    //var selectedComponent = function (comp) {
    //     currentComponent(comp)
    // }

    postman.subscribe("selectedComponent", function (data) {
        selectedParams(data.params);
        selectedComponent(data.item);
    })




    //var selectedComponent = function ()
    //var posts = ko.observableArray([]);
    /*   var canPrev = ko.observable(false);
       var prevUrl = "";
       var curUrl = "";
       var canNext = ko.observable(false);
       var nextUrl = "";*/
    //  var currentTemplate = ko.observable("post-list");
    //var currentPost = ko.observable();
    //var hasAnswers = ko.observable(false);

    /* var getPost = function(url) {
         $.getJSON(url, function (data) {
             $.getJSON(data.answers, function (answers) {
                 hasAnswers(answers && answers.length > 0);
                 data.answers = answers;
                 currentPost(data);
             });
         });
     };
 
     var showPost = function(post) {
         getPost(post.link);
         currentView("post");
     };*/

    /*  var getPosts = function (url) {
          url = url === undefined ? "api/posts" : url;
          $.getJSON(url, function (data) {
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
  
      var next = function() {
          getPosts(nextUrl);
      };
  
      var prev = function() {
          getPosts(prevUrl);
      };
  
      var back = function() {
          getPosts(curUrl);
          currentView("posts");
      };
  
      getPosts();*/

    return {
        // currentComponent,
        title,
        selectedComponent,
        selectedParams
        // posts,
        // prev,
        //canPrev,
        // next,
        // canNext,
        // currentView,
        // currentPost,
        //showPost,
        //back,
        //hasAnswers
    };
});