import OptionsList from "./OptionsList";
import "./OptionsList.css";
import MovieItem from "./MovieItem";
import movies from "./movies";
import "./OptionsList.css"
function WatchListPage() {
    const moviesList = movies.map((movie,key)=>{    
        return <MovieItem title={movie.title} overview={movie.overview}  key={key}/>
        });

    return(
        <div>
            <div>
                <OptionsList/>
            </div>
            <article>
                <div>
                    <h1>WatchList</h1>
                    <dl>
                    {moviesList}        
                    </dl>
                </div>
            </article>
        </div>
    );
}

export default WatchListPage;