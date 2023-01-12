import "./PostItem.css"

function PostItem({name, date, comment, rating}){
 
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
