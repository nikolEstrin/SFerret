import "./MovieSearchResultItem.css"
import { OverlayTrigger, Tooltip } from 'react-bootstrap';
import * as aj from "../ajax";
import { useState, useEffect, useRef } from 'react';
import { useNavigate } from "react-router-dom";

function MovieSearchResultItem({adult, collection, id, language, overview, posterPath, releaseDate, runtime, title}) {
    const comment = useRef(null);
    const [rating, setRating] = useState('');
    var navi = useNavigate();

    const addMovieToWatchList = function(){
        aj.AddToWatchList(localStorage.getItem('id'), id);    
    }
    releaseDate = releaseDate.substring(0,10);
    const addPostModal = function(){
        if(comment.current != null)
            aj.CreatePost(localStorage.getItem('id'), id, rating, comment.current.value);
    }

    return (
        <>
            <div className="bodySearch">
                <dt className="searchDesign">
                <p>{title}</p>
                <div className="detailsMovie">
                    <b className="oneLine">Runtime: </b>
                    <p className="oneLine">{runtime} minutes,</p>
                    <b className="oneLine">Release Date: </b>
                    <p className="oneLine">{releaseDate}</p>
                    
                    {  collection!="" ?
                    (<><b className="oneLine">, Collection: </b>
                    <p className="oneLine">{collection}</p></>) : ("")
                    }
                    
                </div>
                </dt>
                <dd className="searchDesign">
                    <OverlayTrigger placement="bottom" overlay={(<Tooltip>{overview}</Tooltip>)}>
                        <div className="containerdd">
                            <img src="Images/informationButton.png" alt="Snow" />
                            <button type="button" className="btn btn-secondary" />
                        </div>
                    </OverlayTrigger>
                    <div className="containerdd addPostSearch">
                        <img src="Images/addPost.png" alt="Snow" />
                        <button type="button" className="btn btn-secondary postAdd" onClick={()=>{localStorage.setItem("title", title);localStorage.setItem("goBack", "/search");localStorage.setItem("movieid", id);navi("/addpost")}} />
                    </div>
                    <div className="containerdd addWatchList">
                        <img src="Images/addToWatchListButton.png" alt="Snow" />
                        <button onClick={addMovieToWatchList} type="button" className="btn btn-secondary watch" />
                    </div>
                </dd>
            </div>
        </>
    );
}

export default MovieSearchResultItem;