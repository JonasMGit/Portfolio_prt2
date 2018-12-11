define(['jquery', 'knockout', 'postman'], function ($, ko, postman) {

    //var currentComponent = ko.observable("post-list")
    var selectedParams = ko.observable("");

    var title = "Stackinator";
    var menuItems = [
        { name: 'Home', component: 'question-list' },
        { name: 'Cloud', component: 'Cloud' }
    ];

    var selectedMenu = ko.observable(menuItems[0]);
    var selectedComponent = ko.observable("question-list");
    var isActive = function (menu) {
        return selectedMenu() === menu ? "active" : "";
    };

    var changeMenu = function (menu) {
        selectedMenu(menu);
        selectedComponent(menu.component);
    };

    postman.subscribe("changeMenu", function (menuName) {
        var menu = menuItems.find(function (m) {
            return m.name === menuName;
        });
        if (menu) changeMenu(menu);
    });

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
        selectedParams,
        menuItems,
        isActive,
        changeMenu

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