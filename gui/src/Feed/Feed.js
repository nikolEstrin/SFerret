import OptionsList from "../list/OptionsList";
import movies from "../list/movies";
import MoviePostItem from "./MoviePostItem";
import "./Feed.css"
function Feed() {
    const moviesList = movies.map((movie,key)=>{    
        return <MoviePostItem title={movie.title} overview={movie.overview} index={key}  key={key}/>
    });

    return (
        <div className="FeedBackground">
            <div>
                <OptionsList/>
            </div>
            <div>
                <br/>
                <center>
                    <h1>Feed</h1>
                    <br/>
                    {moviesList}
                </center>
            </div>
        </div>
    );
}

export default Feed;