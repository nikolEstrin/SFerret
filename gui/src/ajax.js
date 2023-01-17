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

export function getMovies(page, setMovies){
    $.ajax({
        url:"https://localhost:7144/Movies?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data)
        }, 
        error: function(){},
    });
}

export async function getMoviesNotWatched(id, page, setMovies){
    await $.ajax({
        url:"https://localhost:7144/Movies/"+id+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data);
        }, 
        error: function(){ },
    });
}

export async function getMoviesByCollection(coll, page, setMovies){
    await $.ajax({
        url:"https://localhost:7144/Movie/Collection/"+coll+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data);
        }, 
        error: function(){ },
    });
}

export async function getMoviesByLanguage(lang, page, setMovies){
    await $.ajax({
        url:"https://localhost:7144/Movie/Lang/"+lang+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data);
        }, 
        error: function(){},
    });
}

export async function getMoviesByTitle(title, page, setMovies){
    await $.ajax({
        url:"https://localhost:7144/Movie/Title/"+title+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data);
        }, 
        error: function(){ },
    });
}

export async function getMoviesByRuntime(time, flag, page, setMovies){
    await $.ajax({
        url:"https://localhost:7144/Movie/Time/"+time+"/Flag/"+flag+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data);
        }, 
        error: function(){},
    });
}

export async function getMoviesByDate(date, flag, page, setMovies){
    await $.ajax({
        url:"https://localhost:7144/Movie/Date/"+date+"/Flag/"+flag+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data);
        }, 
        error: function(){ },
    });
}

export async function getMoviesByGenre(gen, page, setMovies){
    await $.ajax({
        url:"https://localhost:7144/Movie/Genre/"+gen+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data);
        }, 
        error: function(){},
    });
}

export async function getMoviesByRating(rating, flag, page, setMovies){
    var d;
    await $.ajax({
        url:"https://localhost:7144/Movie/Rating/"+rating+"/Flag/"+flag+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data);
        }, 
        error: function(){},
    });
}

export async function getMoviesByPost(flag, page, setMovies){
    await $.ajax({
        url:"https://localhost:7144/Movie/Post/"+flag+"?page="+page,
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data);
        }, 
        error: function(){},
    });
}

export async function login(username, password, history){
    await $.ajax({
        url:"https://localhost:7144/User/Login",
        type:'POST',
        contentType:"application/json",
        data: JSON.stringify({id: 0, fullName: username, password: password}),
        success:function(data) {
            localStorage.setItem('id', data);
            localStorage.setItem('username', username);
			history("/feed");
        }, 
        error: function(data){
            document.getElementById('alert').style.visibility = "collapse";
            document.getElementById('alert').innerHTML = "Incorrect username and / or password";
            document.getElementById('alert').style.visibility = "visible";
        },
    });
}

export async function register(username, password, history){
    await $.ajax({
        url:"https://localhost:7144/User/Register",
        type:'POST',
        contentType:"application/json",
        data: JSON.stringify({id: 0, fullName: username, password: password}),
        success:function(data) {
            localStorage.setItem('id', data);
            localStorage.setItem('username', username);
			history("/feed");
        }, 
        error: function(data){
            document.getElementById('alert').style.visibility = "collapse";
            document.getElementById('alert').innerHTML = "This username is taken, try another one:)";
            document.getElementById('alert').style.visibility = "visible";

            document.getElementById("usernameR").value = "";
        },
    });
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

export async function getUserName(id, setName){
    await $.ajax({
        url:"https://localhost:7144/User/Name/"+id,
        type:'GET',
        data:{},
        success:function(data) {
            setName(data.fullName)
        }, 
        error: function(){},
    });
}

export async function getWatchList(id, setMovies){
    await $.ajax({
        url:"https://localhost:7144/WatchList/"+id,
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data);
        }, 
        error: function(){ },
    });
}

export async function AddToWatchList(user, movie){
    var d;
    await $.ajax({
        url:"https://localhost:7144/WatchList/"+user+"/Movie/"+movie,
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
        url:"https://localhost:7144/WatchList/"+user+"/Movie/"+movie,
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
        url:"https://localhost:7144/Post",
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
        url:"https://localhost:7144/Post",
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
        url:"https://localhost:7144/Post/"+user+"/"+movie,
        type:'DELETE',
        contentType:"application/json",
        success:function(){console.log("deleted")}, 
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

export async function getPosts(setPosts){
    await $.ajax({
        url:"https://localhost:7144/Posts",
        type:'GET',
        data:{},
        success:function(data) {
            setPosts(data)
        }, 
        error: function(){ },
    });
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

export async function getPostsByMovie(movie, setPosts){
    await $.ajax({
        url:"https://localhost:7144/Post/Movie/"+movie,
        type:'GET',
        data:{},
        success:function(data) {
            setPosts(data);
        }, 
        error: function(){},
    });
}

export async function getPostsByMovieTitle(title, setPosts){
    await $.ajax({
        url:"https://localhost:7144/Post/Movie/Title/"+title,
        type:'GET',
        data:{},
        success:function(data) {
            setPosts(data);
        }, 
        error: function(){},
    });
}

export async function getPostsByGenre(gen, setPosts){
    await $.ajax({
        url:"https://localhost:7144/Post/Genre/"+gen,
        type:'GET',
        data:{},
        success:function(data) {
            setPosts(data);
        }, 
        error: function(){ },
    });
}

export async function getPostsByRating(rating, flag, setPosts){
    await $.ajax({
        url:"https://localhost:7144/Post/Rating/"+rating+"/Flag/"+flag,
        type:'GET',
        data:{},
        success:function(data) {
            setPosts(data);
        }, 
        error: function(){},
    });
}

export async function getPostsByUser(user, setPosts){
    await $.ajax({
        url:"https://localhost:7144/Post/User/"+user,
        type:'GET',
        data:{},
        success:function(data) {
            setPosts(data);
        }, 
        error: function(){ },
    });
}

export async function getPosts_movies(setMovies){
    await $.ajax({
        url:"https://localhost:7144/Posts/Movies",
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data)
        }, 
        error: function(){ },
    });
}

export async function getPostsByGenre_movies(gen, setMovies){
    await $.ajax({
        url:"https://localhost:7144/Post/Genre/"+gen+"/Movies",
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data);
        }, 
        error: function(){ },
    });
}

export async function getPostsByRating_movies(rating, flag, setMovies){
    await $.ajax({
        url:"https://localhost:7144/Post/Rating/"+rating+"/Flag/"+flag+"/Movies",
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data);
        }, 
        error: function(){ },
    });
}

export async function getPostsByUser_movies(user, setMovies){
    await $.ajax({
        url:"https://localhost:7144/Post/User/"+user+"/Movies",
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data);
        }, 
        error: function(){ },
    });
}

export async function getPostsByMovieTitle_movies(title, setMovies){
    await $.ajax({
        url:"https://localhost:7144/Post/Movie/Title/"+title+"/Movies",
        type:'GET',
        data:{},
        success:function(data) {
            setMovies(data);
        }, 
        error: function(){ },
    });
}