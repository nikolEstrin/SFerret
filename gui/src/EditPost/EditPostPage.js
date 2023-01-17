import * as aj from "../ajax";
import { useState, useEffect, useRef} from 'react';
import { useNavigate } from "react-router-dom"


function EditPostPage(){
    const comment = useRef(null);
    const [rating, setRating] = useState('');
    let navi = useNavigate();

    const editPostModal = function(){
        console.log(localStorage.getItem('id'), localStorage.getItem("movieid"), rating, comment.current.value)
        if(comment.current != null)
            aj.UpdatePost(localStorage.getItem('id'), localStorage.getItem("movieid"), rating, comment.current.value);
    }

    return(
        <div id="postPage">
            <center>
                <h2>Edit Post About "{localStorage.getItem("title")}"</h2>
                <br/>
                <textarea type="text" className="form-control inputComment" ref={comment} placeholder="Your Comment" aria-label="comment" aria-describedby="basic-addon1" id="usersComment" required>{localStorage.getItem("comment")}</textarea>
                <br/>
                <div className="dropdown">
                    <button className="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">{localStorage.getItem("rating")} Stars</button>
                    <ul className="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                        <li><button className="dropdown-item" onClick={() => { setRating(1); document.querySelector('#dropdownMenuButton1').innerHTML ="1 Star" }}>1 Star</button></li>
                        <li><button className="dropdown-item" onClick={() => { setRating(2); document.querySelector('#dropdownMenuButton1').innerHTML ="2 Stars" }}>2 Stars</button></li>
                        <li><button className="dropdown-item" onClick={() => { setRating(3); document.querySelector('#dropdownMenuButton1').innerHTML ="3 Stars" }}>3 Stars</button></li>
                        <li><button className="dropdown-item" onClick={() => { setRating(4); document.querySelector('#dropdownMenuButton1').innerHTML ="4 Stars" }}>4 Stars</button></li>
                        <li><button className="dropdown-item" onClick={() => { setRating(5); document.querySelector('#dropdownMenuButton1').innerHTML ="5 Stars" }}>5 Stars</button></li>
                    </ul>
                </div>
                <br/>
                <button onClick={()=>{navi("/feed")}}><h5>Go back</h5></button>
                <button className="addPostBtn" onClick={()=>{editPostModal();navi("/feed")}}><h3>Edit Post</h3></button>
                <br/>
            </center>
        </div>
    );

}

export default EditPostPage;