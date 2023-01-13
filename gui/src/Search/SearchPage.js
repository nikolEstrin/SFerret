import OptionsList from "../list/OptionsList";
import "./SearchPage.css";
import MovieSearchResultItem from "./MovieSearchResultItem";
import * as aj from "../ajax";
import { useState, useEffect, useRef } from 'react';
var pageNum = 1;
var searchFilter= 0 //0=regular, 1=title

function SearchPage() {
    const [movies, setMovies] = useState('');
    const searchBox = useRef(null);

    useEffect(() =>{
        aj.getMovies(1, setMovies)
    },[]);

    var moviesList;
    if (movies != '') {
        moviesList = movies.map((movie, key) => {
            return <MovieSearchResultItem adult={movie.adult} collection={movie.collection} id={movie.id} language={movie.language} overview={movie.overview} posterPath={movie.posterPath} releaseDate={movie.releaseDate} runtime={movie.runtime} title={movie.title} key={key} />
        });
    }

    const nextPage = function (event) {
        pageNum++;
        if (searchFilter==0)
            aj.getMovies(pageNum, setMovies);
        else if(searchFilter==1)
            aj.getMoviesByTitle(searchBox.current.value, pageNum, setMovies);
    }
    const prePage = function (event) {
        if (pageNum > 1) {
            pageNum--;
            if (searchFilter==0)
                aj.getMovies(pageNum, setMovies);
            else if(searchFilter==1)
                aj.getMoviesByTitle(searchBox.current.value, pageNum, setMovies);
        }
    }

    const search = function(event){
        pageNum=1;
        searchFilter = 1;
        aj.getMoviesByTitle(searchBox.current.value, pageNum, setMovies);
    }
    

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
                    <button className="oneLine" onClick={() => { prePage() }}>&lt;</button>
                    <h4 className="oneLine">{pageNum}</h4>
                    <button className="oneLine" onClick={() => { nextPage() }}>&gt;</button>
                    <form>
                        <label htmlFor="search">Search</label>
                        <input id="search" type="search" pattern=".*\S.*" ref={searchBox} onKeyUp={search} required/>
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
                        <div className="btn-group">
                            <button type="button" className="btn btn-lg btn-secondary dropdown-toggle dropdown-toggle-split" data-bs-toggle="dropdown" aria-expanded="false">
                                <span className="visually-hidden">Toggle Dropdown</span>
                            </button>
                            <ul className="dropdown-menu">
                                <label className="list-group-item dropdown-item">
                                    <div className="me-1">
                                    <input className="form-check-input " type="checkbox" value="" id="firstCheckboxStretched"/>
                                    <h3>First checkbox</h3>
                                    </div>
                                    </label>
                                <label className="list-group-item dropdown-item">
                                    <div className="me-1">
                                    <input className="form-check-input me-2" type="checkbox" value="" id="secondCheckboxStretched"/>
                                    <h3>Sec checkbox</h3>
                                    </div>
                                </label>
                                <label className="list-group-item dropdown-item">
                                    <div className="me-1">
                                    <input className="form-check-input me-1" type="checkbox" value="" id="thirdCheckboxStretched"/>
                                    <h3>The checkbox</h3>
                                    </div>
                                </label>
                            </ul>
                            <button className="btn btn-secondary btn-lg" type="button">
                                Filter
                            </button>
                        </div>
                    </form>
                    <div className="listDiv">
                        <dl className="searchDesign">
                            {moviesList}        
                        </dl>
                    </div>
                </div>
            </article>
        </div>
    );
}

export default SearchPage;
