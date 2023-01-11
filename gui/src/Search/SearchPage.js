import OptionsList from "../list/OptionsList";
import "./SearchPage.css";
import movies from "../list/movies";
import MovieSearchResultItem from "./MovieSearchResultItem";
import * as aj from "./ajax";

function SearchPage() {

    movies = aj.getMovies(1)
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
                        {/* 
                        <span class="dropdown">
                        <button class="btn btn-secondary dropdown-toggle filter" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                            Dropdown button
                        </button>
                        <ul class="list-group filter dropdown-menu">
                            <li class="list-group-item dropdown-item">
                                <input class="form-check-input me-1" type="checkbox" value="" id="firstCheckboxStretched"/>
                                <label class="form-check-label stretched-link" id="firstCheckboxStretched1" for="firstCheckboxStretched">Movie-Name</label>
                            </li>
                            <li class="list-group-item dropdown-item">
                                <input class="form-check-input me-1" type="checkbox" value="" id="secondCheckboxStretched"/>
                                <label class="form-check-label stretched-link" for="secondCheckboxStretched">User</label>
                            </li>
                            <li class="list-group-item dropdown-item">
                                <input class="form-check-input me-1" type="checkbox" value="" id="thirdCheckboxStretched"/>
                                <label class="form-check-label stretched-link" for="thirdCheckboxStretched">Date</label>
                            </li>
                        </ul>
                        </span>
                        */}
                        <div class="btn-group">
                            <button type="button" class="btn btn-lg btn-secondary dropdown-toggle dropdown-toggle-split" data-bs-toggle="dropdown" aria-expanded="false">
                                <span class="visually-hidden">Toggle Dropdown</span>
                            </button>
                            <ul class="dropdown-menu">
                                <label class="list-group-item dropdown-item">
                                    <div className="me-1">
                                    <input class="form-check-input " type="checkbox" value="" id="firstCheckboxStretched"/>
                                    <h3>First checkbox</h3>
                                    </div>
                                    </label>
                                <label class="list-group-item dropdown-item">
                                    <div className="me-1">
                                    <input class="form-check-input me-2" type="checkbox" value="" id="secondCheckboxStretched"/>
                                    <h3>Sec checkbox</h3>
                                    </div>
                                </label>
                                <label class="list-group-item dropdown-item">
                                    <div className="me-1">
                                    <input class="form-check-input me-1" type="checkbox" value="" id="thirdCheckboxStretched"/>
                                    <h3>The checkbox</h3>
                                    </div>
                                </label>
                            </ul>
                            <button class="btn btn-secondary btn-lg" type="button">
                                Filter
                            </button>
                        </div>
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
