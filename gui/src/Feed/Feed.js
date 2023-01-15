import OptionsList from "../list/OptionsList";
import MoviePostItem from "./MoviePostItem";
import "./Feed.css"
import * as aj from "../ajax";
import { useState, useEffect, useRef } from 'react';
var pageNum = 1;
var isSearching = 0

function Feed() {
    const [posts, setPosts] = useState('');
    const [movies, setMovies] = useState('');
    var dictMoviePosts = {};
    const searchBox = useRef(null);
    const [searchFilter, setSearchFilter] = useState('') //0=regular, 1=movieName, 2=movieGenre, 3=postsRating, 4=postWriter
    const [flagFilter, setFlagFilter] = useState('')

    useEffect(() =>{
        aj.getPosts(setPosts);
        aj.getPosts_movies(setMovies);
       
    },[]);
    if(posts.length > 0)
        console.log("P", posts)
    for(let i = 0; i < posts.length; i++) {
        if (posts[i].movieId in dictMoviePosts)
            dictMoviePosts[posts[i].movieId].push(posts[i])
        else
        dictMoviePosts[posts[i].movieId] = [posts[i]]
    }
    
    var moviesList;
    if (movies!=''){
        console.log("M", movies)
        moviesList = movies.map((movie,key)=>{    
            return <MoviePostItem adult={movie.adult} collection={movie.collection} id={movie.id} language={movie.language} overview={movie.overview} posterPath={movie.posterPath} releaseDate={movie.releaseDate} runtime={movie.runtime} title={movie.title} posts={dictMoviePosts[movie.id]} key={key}/>
        });
    }

    const search = function(event){
        pageNum=1;
        if(isSearching==0){
            isSearching = 1;
            if(searchFilter==0)
                setSearchFilter(1);
        }

        if(searchFilter==1){
            aj.getPostsByMovieTitle(searchBox.current.value, setPosts);
            aj.getPostsByMovieTitle_movies(searchBox.current.value, setMovies);
        }
        else if(searchFilter==2){
            aj.getPostsByGenre(searchBox.current.value, setPosts);
            aj.getPostsByGenre_movies(searchBox.current.value, setMovies);
        }
        else if(searchFilter==3){
            aj.getPostsByRating(searchBox.current.value, flagFilter, setPosts);
            aj.getPostsByRating_movies(searchBox.current.value, flagFilter, setMovies);
        }
        else if(searchFilter==4){
            aj.getPostsByUser(searchBox.current.value, setPosts);
            aj.getPostsByUser_movies(searchBox.current.value, setMovies);
        }
            
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
                                <div className="moviesList1">
                                    <div>
                                    {moviesList}
                                    </div>
                                </div>
                            </center>
                        </div>
                    </div>
                    <div className="col-3">
                        <form className="searchSpan">
                            <label htmlFor="search">Search</label>
                            <input id="searchFeed" type="search" style={{color:"white"}} onClick={()=>{aj.getPosts(setPosts);aj.getPosts_movies(setMovies);}} pattern=".*\S.*" ref={searchBox} onKeyUp={search} required/>
                            <span className="caret"></span>
                        </form>
                        <div className="dropdown dropMenuFeed">
                            <button className="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false"> Filter</button>
                            <ul className="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                                <li><button className="dropdown-item" onClick={() => { setSearchFilter(1); document.querySelector('#dropdownMenuButton1').innerHTML = 'Movie Name' }}>Movie Name</button></li>
                                <li><button className="dropdown-item" onClick={() => { setSearchFilter(2); document.querySelector('#dropdownMenuButton1').innerHTML = 'Movie Genre' }}>Movie Genre</button></li>
                                <li><button className="dropdown-item" onClick={() => { setSearchFilter(4); document.querySelector('#dropdownMenuButton1').innerHTML = 'Post Writer' }}>Post Writer</button></li>
                                <li><button className="dropdown-item" onClick={() => { setSearchFilter(3); setFlagFilter(-1);document.querySelector('#dropdownMenuButton1').innerHTML = 'Post Rating Smaller than' }}>Post Rating Smaller than</button></li>
                                <li><button className="dropdown-item" onClick={() => { setSearchFilter(3); setFlagFilter(0);document.querySelector('#dropdownMenuButton1').innerHTML = 'Post Rating Equal to' }}>Post Rating Equal to</button></li>
                                <li><button className="dropdown-item" onClick={() => { setSearchFilter(3); setFlagFilter(1);document.querySelector('#dropdownMenuButton1').innerHTML = 'Post Rating Greater than' }}>Post Rating Greater than</button></li>
                            </ul>
                        </div>
                    </div>
                </div>

        </div>
    );
}

export default Feed;