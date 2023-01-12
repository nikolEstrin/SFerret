import OptionsList from "../list/OptionsList";
import MoviePostItem from "./MoviePostItem";
import "./Feed.css"
import * as aj from "../ajax";
import { useState, useEffect } from 'react';
var pageNum = 1;


function Feed() {
    const [movies, setMovies] = useState('');

    const getMoviesPerPage = function(n){
        aj.getMovies(n, setMovies)
    }

    var moviesList;
    if (movies!=''){
        moviesList = movies.map((movie,key)=>{    
            return <MoviePostItem adult={movie.adult} collection={movie.collection} id={movie.id} language={movie.language} overview={movie.overview} posterPath={movie.posterPath} releaseDate={movie.releaseDate} runtime={movie.runtime} title={movie.title} key={key}/>
        });
    }

    const nextPage = function(){
        pageNum++;
        getMoviesPerPage(pageNum);
    }
    const prePage = function(){
        if(pageNum > 1){
            pageNum--;
            getMoviesPerPage(pageNum);
        }
    }
    if (pageNum==1)
        getMoviesPerPage(pageNum);

    return (
        <div>
            <img className='background' src="Images/feed_background.png" />
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
                                <button className="oneLine" onClick={() => { prePage() }}>&lt;</button>
                                <h4 className="oneLine">{pageNum}</h4>
                                <button className="oneLine" onClick={() => { nextPage() }}>&gt;</button>
                                <div className="moviesList1">
                                    <div>
                                    {moviesList}
                                    </div>
                                </div>
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