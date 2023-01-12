import "./MovieItem.css"
import { OverlayTrigger, Tooltip } from 'react-bootstrap';
import * as aj from "../ajax";
import { useState, useEffect } from 'react';

function MovieItem({adult, collection, id, language, overview, posterPath, releaseDate, runtime, title}){
    
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
                        <button type="button" className="btn btn-secondary postAdd" data-bs-toggle="modal" data-bs-target="#exampleModal" />
                    </div>
                    <div className="container watched">
                        <img src="Images/watched.png" alt="Snow" />
                        <button onClick={removeFromList} type="button" className="btn btn-secondary watched" />
                    </div>
                </dd>
                <br />
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
                                <input type="text" className="form-control" placeholder="Your Comment" aria-label="comment" aria-describedby="basic-addon1" id="usersComment" required></input>
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-success " id="addButton" data-bs-dismiss="modal">Add</button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}

export default MovieItem;

