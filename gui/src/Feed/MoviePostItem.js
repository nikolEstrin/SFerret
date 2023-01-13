import "./MoviePostItem.css"
import PostItem from "./PostItem";
import * as aj from "../ajax";
import { useState, useEffect } from 'react';
function MoviePostItem({adult, collection, id, language, overview, posterPath, releaseDate, runtime, title}){

    const [posts, setMovies] = useState('');

    const getPostsPerMovieId = function(){
        aj.getPostsByMovie(id)
    }
    getPostsPerMovieId();
    console.log(posts);
    var postsList;
    if (posts!=''){
        postsList = posts.map((post,key)=>{    
            return <PostItem id={post.Id} userid={post.UserId} movieid={post.MovieId} rating={post.Rating} comment={post.Comment} date={post.PublishedDate} key={key}/>
        });
    }

    const addMovieToWatchList = function(){
        aj.AddToWatchList(localStorage.getItem('id'), id);    
    }

    releaseDate = releaseDate.substring(0,10);
    if (adult)
        adult = "Yes"
    else
        adult = "No"

    return(
        <div className="postBlock">
            <h1>{title}</h1>
            <p>{overview}</p>
            <div>
                <b className="oneLine">Runtime: </b>
                <p className="oneLine">{runtime} minutes,</p>
                <b className="oneLine">Release Date: </b>
                <p className="oneLine">{releaseDate},</p>
                <b className="oneLine">For adults? </b>
                <p className="oneLine"> {adult}</p>

            </div>
            <center>
                {/* <div className="listComments overflow-auto">
                    {postsList}
                </div> */}
            </center>
            <div className="containerPost addP">
                <img src="Images/addPost.png" alt="Snow"/>
                <button type="button" className="btn btn-secondary post"/>
            </div>
            <div className="containerPost addW">
                <img src="Images/addToWatchListButton.png" alt="Snow"/>
                <button onClick={addMovieToWatchList} type="button" className="btn btn-secondary watch"/>
            </div>
        </div>
    );
    
}

export default MoviePostItem;
