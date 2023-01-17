import "./MoviePostItem.css"
import PostItem from "./PostItem";
import * as aj from "../ajax";
import { useState, useEffect, useRef } from 'react';
import { useNavigate } from "react-router-dom"

function MoviePostItem({adult, collection, id, language, overview, posterPath, releaseDate, runtime, title, posts, avgRating}){

    const comment = useRef(null);
    const [rating, setRating] = useState('');
    var navi = useNavigate();

    var postsList;
    if (posts!='' && posts!=undefined){
        postsList = posts.map((post,key)=>{    
            return <PostItem id={post.id} userid={post.userId} movieid={post.movieId} rating={post.rating} comment={post.comment} date={post.publishedDate} key={key}/>
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
        <>
            <div className="postBlock">
                <h1>{title}</h1>
                <p>{overview}</p>
                <div>
                    <b className="oneLine">Runtime: </b>
                    <p className="oneLine">{runtime} minutes,</p>
                    <b className="oneLine">Release Date: </b>
                    <p className="oneLine">{releaseDate},</p>
                    <b className="oneLine">For adults? </b>
                    <p className="oneLine"> {adult},</p>
                    <b className="oneLine">Average Rating:</b>
                    <p className="oneLine"> {avgRating}</p>
                </div>
                <center>
                    <div className="listComments overflow-auto">
                        {postsList}
                    </div>
                </center>
                <div className="containerPost addP">
                    <img src="Images/addPost.png" alt="Snow" />
                    <button type="button" className="btn btn-secondary postAdd" onClick={()=>{localStorage.setItem("title", title);localStorage.setItem("goBack", "/feed");localStorage.setItem("movieid", id);navi("/addpost")}}/>
                </div>
                <div className="containerPost addW">
                    <img src="Images/addToWatchListButton.png" alt="Snow" />
                    <button onClick={addMovieToWatchList} type="button" className="btn btn-secondary watch" />
                </div>
            </div>
        </>
    );
    
}

export default MoviePostItem;
