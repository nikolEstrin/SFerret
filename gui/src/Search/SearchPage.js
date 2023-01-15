import OptionsList from "../list/OptionsList";
import "./SearchPage.css";
import MovieSearchResultItem from "./MovieSearchResultItem";
import * as aj from "../ajax";
import { useState, useEffect, useRef } from 'react';
var pageNum = 1;

function SearchPage() {
    const [movies, setMovies] = useState('');
    const searchBox = useRef(null);
    const [searchFilter, setSearchFilter] = useState('') //0=regular, 1=regularSearch, 2=collection, 3=language, 4=runtime, 5=date, 6=genre, 7=rating, 8=post
    const [flagFilter, setFlagFilter] = useState('')
    //setSearchFilter(0);

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
        setSearchFilter(1);
        aj.getMoviesByTitle(searchBox.current.value, pageNum, setMovies);
    }
    

    return (
        <div className="searchRoot">
            <img className='background' src="Images/popcorn_background.png" alt="..." />

            <div>
                <OptionsList />
            </div>
            <article className="articleSearch">
                <div>
                    <div className="containerSearch">
                        <h1 className="list_title">Search A Movie</h1>
                        <img src="Images/searchIcon.png" alt="..." />
                    </div>
                    <button className="oneLine" onClick={() => { prePage() }}>&lt;</button>
                    <h4 className="oneLine">{pageNum}</h4>
                    <button className="oneLine" onClick={() => { nextPage() }}>&gt;</button>
                   
                    <div className="dropdown dropMenu">
                        <button className="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false"> Filter</button>
                        <ul className="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                            <li><button className="dropdown-item" onClick={() => { setSearchFilter(2); document.querySelector('#dropdownMenuButton1').innerHTML = 'Title' }}>Title</button></li>
                            <li><button className="dropdown-item" onClick={() => { setSearchFilter(2); document.querySelector('#dropdownMenuButton1').innerHTML = 'Collection' }}>Collection</button></li>
                            <li><button className="dropdown-item" onClick={() => { setSearchFilter(3); document.querySelector('#dropdownMenuButton1').innerHTML = 'Language' }}>Language</button></li>
                            <li><button className="dropdown-item" onClick={() => { setSearchFilter(4); document.querySelector('#dropdownMenuButton1').innerHTML = 'Runtime' }}>Runtime</button></li>
                            <li><button className="dropdown-item" onClick={() => { setSearchFilter(6); document.querySelector('#dropdownMenuButton1').innerHTML = 'Genre' }}>Genre</button></li>
                            <li><button className="dropdown-item" onClick={() => { setSearchFilter(8); setFlagFilter(true); document.querySelector('#dropdownMenuButton1').innerHTML = 'Most Posts' }}>Most Posts</button></li>
                            <li><button className="dropdown-item" onClick={() => { setSearchFilter(8); setFlagFilter(false); document.querySelector('#dropdownMenuButton1').innerHTML = 'Least Posts' }}>Least Posts</button></li>
                            <li><button className="dropdown-item" onClick={() => { setSearchFilter(7); setFlagFilter(-1); document.querySelector('#dropdownMenuButton1').innerHTML = 'Rating Smaller than' }}>Rating Smaller than</button></li>
                            <li><button className="dropdown-item" onClick={() => { setSearchFilter(7); setFlagFilter(0); document.querySelector('#dropdownMenuButton1').innerHTML = 'Rating Equal to' }}>Rating Equal to</button></li>
                            <li><button className="dropdown-item" onClick={() => { setSearchFilter(7); setFlagFilter(1); document.querySelector('#dropdownMenuButton1').innerHTML = 'Rating Greater than' }}>Rating Greater than</button></li>
                        </ul>
                    </div>
                    <form>
                        <label htmlFor="search">Search</label>
                        <input id="search" type="search" pattern=".*\S.*" ref={searchBox} onKeyUp={search} required />
                        <span className="caret"></span>
                        
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
