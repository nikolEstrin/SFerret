import * as aj from "../ajax";
import { useState, useEffect, useRef } from 'react';

function AddPostPage(){
    const comment = useRef(null);
    const [rating, setRating] = useState('');
    const removeFromList = function(){
        aj.deleteFromWatchList(localStorage.getItem('id'), localStorage.getItem("movieid"));
    }

    const addPostModal = function(){
        console.log(localStorage.getItem("movieid"), localStorage.getItem("title"))
        if(comment.current != null)
            aj.CreatePost(localStorage.getItem('id'), localStorage.getItem("movieid"), rating, comment.current.value);
    }

    return(
        <div>
            <h5>Add Post About {localStorage.getItem("title")}</h5>
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

            <button onClick={()=>{addPostModal()}}>Add Post</button>
        </div>
    );

}

export default AddPostPage;