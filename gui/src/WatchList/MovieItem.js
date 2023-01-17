import "./MovieItem.css"
import { OverlayTrigger, Tooltip } from 'react-bootstrap';
import * as aj from "../ajax";
import { useState, useEffect, useRef } from 'react';
import { useNavigate } from "react-router-dom"


function MovieItem({adult, collection, id, language, overview, posterPath, releaseDate, runtime, title}){
    const comment = useRef(null);
    const [rating, setRating] = useState('');
    let navi = useNavigate();

    const removeFromList = function(){
        aj.deleteFromWatchList(localStorage.getItem('id'), id);
    }
    

    return (
        <>
            <div>
                <dt>{title}</dt>
                <dd>
                    <OverlayTrigger placement="bottom" overlay={(<Tooltip>{overview}</Tooltip>)}>
                        <div className="container">
                            <img src="Images/informationButton.png" alt="Snow" />
                            <button type="button" className="btn btn-secondary" />
                        </div>
                    </OverlayTrigger>
                    <div className="container add_post">
                        <img src="Images/addPost.png" alt="Snow" />
                        <button type="button" onClick={()=>{localStorage.setItem("title", title);localStorage.setItem("goBack", "/watchlist");localStorage.setItem("movieid", id);navi("/addpost")}} />
                    </div>
                    <div className="container watched">
                        <img src="Images/watched.png" alt="Snow" />
                        <button onClick={removeFromList} type="button" className="btn btn-secondary watched" />
                    </div>
                </dd>
                <br />
            </div>
        </>
    );
}

export default MovieItem;

