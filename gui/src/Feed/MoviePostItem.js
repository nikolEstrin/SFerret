import "./MoviePostItem.css"
import PostItem from "./PostItem";
import * as aj from "../ajax";
import { useState, useEffect, useRef } from 'react';
function MoviePostItem({adult, collection, id, language, overview, posterPath, releaseDate, runtime, title, posts}){

    const comment = useRef(null);
    const [rating, setRating] = useState('');

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

    const addPostModal = function(){
        if(comment.current != null)
            aj.CreatePost(localStorage.getItem('id'), id, rating, comment.current.value);
    }

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
                    <p className="oneLine"> {adult}</p>

                </div>
                <center>
                    <div className="listComments overflow-auto">
                        {postsList}
                    </div>
                </center>
                <div className="containerPost addP">
                    <img src="Images/addPost.png" alt="Snow" />
                    <button type="button" className="btn btn-secondary postAdd" data-bs-toggle="modal" data-bs-target="#exampleModal" />
                </div>
                <div className="containerPost addW">
                    <img src="Images/addToWatchListButton.png" alt="Snow" />
                    <button onClick={addMovieToWatchList} type="button" className="btn btn-secondary watch" />
                </div>
            </div>
            <div className="modal fade" id="exampleModal" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id="exampleModalLabel">Add Post To: {title}</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                            <div className="input-group">
                                <input type="text" className="form-control" ref={comment} placeholder="Your Comment" aria-label="comment" aria-describedby="basic-addon1" id="usersComment" required></input>
                                <div className="dropdown">
                                    <button className="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">Your Rating</button>
                                    <ul className="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                                        <li><button className="dropdown-item" onClick={() => { setRating(1) }}>1 Star</button></li>
                                        <li><button className="dropdown-item" onClick={() => { setRating(2) }}>2 Stars</button></li>
                                        <li><button className="dropdown-item" onClick={() => { setRating(3) }}>3 Stars</button></li>
                                        <li><button className="dropdown-item" onClick={() => { setRating(4) }}>4 Stars</button></li>
                                        <li><button className="dropdown-item" onClick={() => { setRating(5) }}>5 Stars</button></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button type="button" onClick={addPostModal()} className="btn btn-success " id="addButton" data-bs-dismiss="modal">Add Post</button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
    
}

export default MoviePostItem;
