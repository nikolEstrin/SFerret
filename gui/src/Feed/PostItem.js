import "./PostItem.css"
import * as aj from "../ajax";
import { useState, useEffect } from 'react';

function PostItem({id, userid, movieid, rating, comment, date}){
 
    const [name, setName] = useState('');

    const getMoviesPerPage = function(){
        aj.getMovies(userid, setName)
    }
    getMoviesPerPage();
    return(
        <div>
            <div className="comment text-justify float-left">
                <h4>{name}</h4>
                <span>- {date}</span>
                <br/>
                <p>{comment}</p>
            </div>    
        </div>
    );

}

export default PostItem;
