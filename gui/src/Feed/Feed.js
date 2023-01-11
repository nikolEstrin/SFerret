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

                <div className="row">
                    <div className="col-9">
                        <br/>
                        <div>
                            <center>
                                <h1>Feed</h1>
                                <br/>
                                {moviesList}
                            </center>
                        </div>
                    </div>
                    <div className="col-3">
                        <form>
                            <label htmlFor="search">Search</label>
                            <input id="search" type="search" pattern=".*\S.*" required/>
                            <span className="caret"></span>
                        </form>
                    </div>
                </div>

        </div>
    );
}

export default Feed;