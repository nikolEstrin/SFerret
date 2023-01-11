import "./MoviePostItem.css"
import posts from "./posts";
import PostItem from "./PostItem";
function MoviePostItem({title, overview, index}){

    if(posts.length > index && posts[index]!==[]){
        const postsList = posts[index].map((post,key)=>{    
            return <PostItem name={post.name} date={post.date} comment={post.Comment} rating={post.rating} key={key}/>
        });
    
        return(
            <div className="postBlock">
                <h1>{title}</h1>
                <p>{overview}</p>
                <center>
                    <div className="listComments overflow-auto">
                        {postsList}
                    </div>
                </center>
                <div className="containerPost addP">
                    <img src="Images/addPost.png" alt="Snow"/>
                    <button type="button" className="btn btn-secondary post"/>
                </div>
                <div className="containerPost addW">
                    <img src="Images/addToWatchListButton.png" alt="Snow"/>
                    <button type="button" className="btn btn-secondary watch"/>
                </div>
            </div>
        );
    }
    else{
        return(
            <div className="postBlock">
                <h1>{title}</h1>
                <p>{overview}</p>
            </div>
        );
    }
    
}

export default MoviePostItem;
