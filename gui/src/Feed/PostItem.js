import "./PostItem.css"
import * as aj from "../ajax";
import { useState, useEffect } from 'react';
import { useNavigate } from "react-router-dom"

function PostItem({id, userid, movieid, rating, comment, date}){
 
    const [name, setName] = useState('');
    date = date.substring(0,10);
    var navi = useNavigate();

    const getUserName = function(){
        aj.getUserName(userid, setName)
    }
    getUserName();
    return(
        <div>
            <div className="comment text-justify float-left">
                <h4>{name}</h4>
                <span>- {date}</span>
                <br/>
                <p>{comment}</p>
                <p className="stars">{rating} Stars</p>
                {userid==localStorage.getItem('id')?
                (<>
                    <button className="oneLine" id="btnDelete" onClick={()=>{aj.DeletePost(userid, movieid); window.location.reload();}}>Delete</button>
                    <button className="oneLine" id="btnEdit" onClick={()=>{localStorage.setItem("movieid", movieid);localStorage.setItem("comment", comment);localStorage.setItem("rating", rating) ;navi("/editpost")}}>Edit</button>
                </>)
                :("")}
                
            </div>    
        </div>
    );

}

export default PostItem;
