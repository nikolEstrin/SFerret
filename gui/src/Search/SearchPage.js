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
                        {/*} <ul class="list-group filter">
                            <li class="list-group-item">
                                <input class="form-check-input me-1" type="checkbox" value="" id="firstCheckboxStretched"/>
                                <label class="form-check-label stretched-link" for="firstCheckboxStretched">First checkbox</label>
                            </li>
                            <li class="list-group-item">
                                <input class="form-check-input me-1" type="checkbox" value="" id="secondCheckboxStretched"/>
                                <label class="form-check-label stretched-link" for="secondCheckboxStretched">Second checkbox</label>
                            </li>
                            <li class="list-group-item">
                                <input class="form-check-input me-1" type="checkbox" value="" id="thirdCheckboxStretched"/>
                                <label class="form-check-label stretched-link" for="thirdCheckboxStretched">Third checkbox</label>
                            </li>
                        </ul>*/}
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
