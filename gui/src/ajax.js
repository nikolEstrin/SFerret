import $ from "jquery";

export async function getMovieById(id){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Movie/"+id,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = {}; },
    });
    return d;
}

export async function getMovies(page){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Movies?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function getMoviesNotWatched(id){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Movies/"+id,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function getMoviesByCollection(coll, page){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Movie/Collection/"+coll+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function getMoviesByLanguage(lang, page){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Movie/Lang/"+lang+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function getMoviesByTitle(title, page){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Movie/Title/"+title+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function getMoviesByRuntime(time, flag, page){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Movie/Time/"+time+"/Flag/"+flag+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function getMoviesByDate(date, flag, page){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Movie/Date/"+date+"/Flag/"+flag+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function getMoviesByGenre(gen, page){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Movie/Genre/"+gen+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function getMoviesByRating(rating, flag, page){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Movie/Rating/"+rating+"/Flag/"+flag+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function getMoviesByPost(flag, page){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Movie/Post/"+flag+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function login(username, password){
    var d;
    await $.ajax({
        url:"http://localhost:7144/User/Login",
        type:'POST',
        contentType:"application/json",
        data: JSON.stringify({id: 0, fullName: username, password: password}),
        success:function(data) {
            d=data;
        }, 
        error: function(data){
          console.log(data);
        },
    });
    return d;
}

export async function register(username, password){
    var d;
    await $.ajax({
        url:"http://localhost:7144/User/Register",
        type:'POST',
        contentType:"application/json",
        data: JSON.stringify({id: 0, fullName: username, password: password}),
        success:function(data) {
            d=data;
        }, 
        error: function(data){
          console.log(data);
        },
    });
    return d;
}

export async function getUserById(id){
    var d;
    await $.ajax({
        url:"https://localhost:7144/User/"+id,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = {}; },
    });
    return d;
}

export async function getMovieByName(id){
    var d;
    await $.ajax({
        url:"https://localhost:7144/User/Name/"+id,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = {}; },
    });
    return d;
}

export async function getWatchList(id){
    var d;
    await $.ajax({
        url:"https://localhost:7144/WatchList/"+id,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function AddToWatchList(user, movie){
    var d;
    await $.ajax({
        url:"http://localhost:7144/WatchList/"+user+"/Movie/"+movie,
        type:'POST',
        success:function(data) {
            d=data;
        }, 
        error: function(data){
          d = [];
        },
    });
    return d;
}

export async function deleteFromWatchList(user, movie){
    var d;
    await $.ajax({
        url:"http://localhost:7144/WatchList/"+user+"/Movie/"+movie,
        type:'DELETE',
        success:function(data) {
            d=data;
        }, 
        error: function(data){
          d = [];
        },
    });
    return d;
}

export async function CreatePost(user, movie, rating, comment){
    var d;
    await $.ajax({
        url:"http://localhost:7144/Post",
        type:'POST',
        contentType:"application/json",
        data: JSON.stringify({id: 0, userId: user, movieId: movie, rating: rating, comment: comment, publishedDate: "2023-01-18"}),
        success:function(){}, 
        error: function(data){
          console.log(data);
        },
    });
    return d;
}

export async function UpdatePost(user, movie, rating, comment){
    var d;
    await $.ajax({
        url:"http://localhost:7144/Post",
        type:'PUT',
        contentType:"application/json",
        data: JSON.stringify({id: 0, userId: user, movieId: movie, rating: rating, comment: comment, publishedDate: "2023-01-18"}),
        success:function(){}, 
        error: function(data){
          console.log(data);
        },
    });
    return d;
}

export async function DeletePost(user, movie){
    var d;
    await $.ajax({
        url:"http://localhost:7144/Post",
        type:'DELETE',
        contentType:"application/json",
        data: JSON.stringify({id: 0, userId: user, movieId: movie, rating: 0, comment: "delete me", publishedDate: "2023-01-18"}),
        success:function(){}, 
        error: function(data){
          console.log(data);
        },
    });
    return d;
}

export async function getPostById(id){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Post/"+id,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = {}; },
    });
    return d;
}

export async function getPosts(){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Posts",
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function getPostByMovieAndUser(movie, user){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Post/"+user+"/Movie/"+movie,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function getPostsByMovie(movie){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Post/Movie/"+movie,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function getPostsByGenre(gen){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Post/Genre/"+gen,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function getPostsByRating(rating, flag){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Post/Rating/"+rating+"/Flag/"+flag,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}

export async function getPostsByUser(user){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Post/User"+user,
        type:'GET',
        data:{},
        success:function(data) {
            d = data;
        }, 
        error: function(){ d = []; },
    });
    return d;
}
