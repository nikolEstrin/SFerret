import OptionsList from "../list/OptionsList";
import "../list/OptionsList.css";
import MovieItem from "./MovieItem";
import "./WatchListPage.css"
import * as aj from "../ajax";
import { useState, useEffect } from 'react';

function WatchListPage() {
    const [movies, setMovies] = useState('');

    const getMoviesWatchList = function(){
        aj.getWatchList(localStorage.getItem('id'), setMovies)
    }
    getMoviesWatchList();
    var moviesList;
    if (movies!=''){
        moviesList = movies.map((movie,key)=>{    
            return <MovieItem adult={movie.adult} collection={movie.collection} id={movie.id} language={movie.language} overview={movie.overview} posterPath={movie.posterPath} releaseDate={movie.releaseDate} runtime={movie.runtime} title={movie.title} key={key}/>
        });
    }

    return(
        <div>
            <img className='background' src="Images/popcorn_background.png"  alt="..."/>
            <div>
                <OptionsList/>
            </div>
            <article>
                <div>
                    <h1 className="list_title">WatchList</h1>
                    <dl>
                    {moviesList}        
                    </dl>
                </div>
            </article>
        </div>
    );
}

export default WatchListPage;