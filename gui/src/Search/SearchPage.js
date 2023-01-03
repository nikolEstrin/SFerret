import OptionsList from "./OptionsList";
import "./SearchPage.css";
import movies from "./movies";
import MovieSearchResultItem from "./MovieSearchResultItem";

function SearchPage() {
    const moviesList = movies.map((movie,key)=>{    
        return <MovieSearchResultItem title={movie.title} overview={movie.overview}  key={key}/>
    });


    return (
        <div>
            <div>
                <OptionsList/>
            </div>
            <article>
                <div>
                    <div className="container">
                        <h1 className="list_title">Search A Movie</h1>
                        <img src="Images/searchIcon.png" alt="..."/>
                    </div>
                    <form>
                        <label htmlFor="search">Search</label>
                        <input id="search" type="search" pattern=".*\S.*" required/>
                        <span className="caret"></span>
                    </form>
                    <dl>
                    {moviesList}        
                    </dl>
                </div>
            </article>
        </div>
    );
}

export default SearchPage;
