import "./MoviePostItem.css"
import posts from "./posts";
import PostItem from "./PostItem";
function MoviePostItem({title, overview, index}){

    if(posts.length > index && posts[index]!==[]){
        const postsList = posts[index].map((post,key)=>{    
            return <PostItem name={post.name} date={post.date} comment={post.Comment} rating={post.rating} key={key}/>
        });
    
        return(
            <div>
                <h1>{title}</h1>
                <p>{overview}</p>
                <div className="overflow-auto">
                    {postsList}
                </div>
            </div>
        );
    }
    else{
        return(
            <div>
                <h1>{title}</h1>
                <p>{overview}</p>
            </div>
        );
    }
    
}

export default MoviePostItem;
