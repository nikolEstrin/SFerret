import "./MovieSearchResultItem.css"
import { OverlayTrigger, Tooltip } from 'react-bootstrap';
import * as aj from "../ajax";
import { useState, useEffect, useRef } from 'react';
function MovieSearchResultItem({adult, collection, id, language, overview, posterPath, releaseDate, runtime, title}) {
    const comment = useRef(null);
    const [rating, setRating] = useState('');

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
                    <p className="oneLine">{releaseDate},</p>
                    <b className="oneLine">Collection: </b>
                    <p className="oneLine">{collection}</p>
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
                        <button type="button" className="btn btn-secondary postAdd" data-bs-toggle="modal" data-bs-target="#exampleModal" />
                    </div>
                    <div className="containerdd addWatchList">
                        <img src="Images/addToWatchListButton.png" alt="Snow" />
                        <button onClick={addMovieToWatchList} type="button" className="btn btn-secondary watch" />
                    </div>
                </dd>
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

export default MovieSearchResultItem;