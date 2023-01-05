import OptionsList from "../list/OptionsList";
import "./SearchPage.css";
import movies from "../list/movies";
import MovieSearchResultItem from "./MovieSearchResultItem";

function SearchPage() {
    const moviesList = movies.map((movie,key)=>{    
        return <MovieSearchResultItem title={movie.title} overview={movie.overview}  key={key}/>
    });

    return (
        <div className="searchRoot">
            <img className='background' src="Images/popcorn_background.png"  alt="..."/>

            <div>
                <OptionsList/>
            </div>
            <article className="articleSearch">
                <div>
                    <div className="containerSearch">
                        <h1 className="list_title">Search A Movie</h1>
                        <img src="Images/searchIcon.png" alt="..."/>
                    </div>
                    <form>
                        <label htmlFor="search">Search</label>
                        <input id="search" type="search" pattern=".*\S.*" required/>
                        <span className="caret"></span>
                    </form>
                    <dl className="searchDesign">
                    {moviesList}        
                    </dl>
                </div>
            </article>
        </div>
    );
}

export default SearchPage;
