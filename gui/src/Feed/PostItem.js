import "./PostItem.css"

function PostItem({id, userid, movieid, rating, comment, date}){
 
    return(
        <div>
            <div className="comment text-justify float-left">
                <h4>{userid}</h4>
                <span>- {date}</span>
                <br/>
                <p>{comment}</p>
            </div>    
        </div>
    );

}

export default PostItem;
