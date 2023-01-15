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

    const addPostModal = function(){
        if(comment.current != null)
            aj.CreatePost(localStorage.getItem('id'), id, rating, comment.current.value);
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
                        <button type="button" onClick={()=>{localStorage.setItem("title", title);localStorage.setItem("movieid", id);navi("/addpost")}} />
                    </div>
                    <div className="container watched">
                        <img src="Images/watched.png" alt="Snow" />
                        <button onClick={removeFromList} type="button" className="btn btn-secondary watched" />
                    </div>
                </dd>
                <br />
            </div>
            {/* <div className="modal fade" id="exampleModal" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
                                        <li><button className="dropdown-item" onClick={()=>{setRating(1)}}>1 Star</button></li>
                                        <li><button className="dropdown-item" onClick={()=>{setRating(2)}}>2 Stars</button></li>
                                        <li><button className="dropdown-item" onClick={()=>{setRating(3)}}>3 Stars</button></li>
                                        <li><button className="dropdown-item" onClick={()=>{setRating(4)}}>4 Stars</button></li>
                                        <li><button className="dropdown-item" onClick={()=>{setRating(5)}}>5 Stars</button></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button type="button" onClick={addPostModal()} className="btn btn-success " id="addButton" data-bs-dismiss="modal">Add Post</button>
                        </div>
                    </div>
                </div>
            </div> */}
        </>
    );
}

export default MovieItem;

