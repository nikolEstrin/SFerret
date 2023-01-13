import "./PostItem.css"
import * as aj from "../ajax";
import { useState, useEffect } from 'react';

function PostItem({id, userid, movieid, rating, comment, date}){
 
    const [name, setName] = useState('');
    date = date.substring(0,10);

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
            </div>    
        </div>
    );

}

export default PostItem;
