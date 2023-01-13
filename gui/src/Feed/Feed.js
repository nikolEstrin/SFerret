import OptionsList from "../list/OptionsList";
import MoviePostItem from "./MoviePostItem";
import "./Feed.css"
import * as aj from "../ajax";
import { useState, useEffect, useRef } from 'react';
var pageNum = 1;
var searchFilter= 0 //0=regular, 1=title

function Feed() {
    const [posts, setPosts] = useState('');
    const [movies, setMovies] = useState('');
    var moviesId = []
    const searchBox = useRef(null);

    useEffect(() =>{
        aj.getPosts(setPosts);
        for(let i = 0; i < posts.length; i++) {
            
        }
    },[]);

    var moviesList;
    if (movies!=''){
        moviesList = movies.map((movie,key)=>{    
            return <MoviePostItem adult={movie.adult} collection={movie.collection} id={movie.id} language={movie.language} overview={movie.overview} posterPath={movie.posterPath} releaseDate={movie.releaseDate} runtime={movie.runtime} title={movie.title} key={key}/>
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
                            <input id="search" type="search" pattern=".*\S.*" ref={searchBox} onKeyUp={search} required/>
                            <span className="caret"></span>
                        </form>
                    </div>
                </div>

        </div>
    );
}

export default Feed;