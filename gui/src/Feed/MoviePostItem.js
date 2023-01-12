import "./MoviePostItem.css"
import posts from "./posts";
import PostItem from "./PostItem";
function MoviePostItem({adult, collection, id, language, overview, posterPath, releaseDate, runtime, title}){

    releaseDate = releaseDate.substring(0,10);
    if (adult)
        adult = "Yes"
    else
        adult = "No"

    return(
        <div className="postBlock">
            <h1>{title}</h1>
            <p>{overview}</p>
            <div>
                <b className="oneLine">Runtime: </b>
                <p className="oneLine">{runtime} minutes,</p>
                <b className="oneLine">Release Date: </b>
                <p className="oneLine">{releaseDate},</p>
                <b className="oneLine">For adults? </b>
                <p className="oneLine"> {adult}</p>

            </div>
            <center>
                {/* <div className="listComments overflow-auto">
                    {postsList}
                </div> */}
            </center>
            <div className="containerPost addP">
                <img src="Images/addPost.png" alt="Snow"/>
                <button type="button" className="btn btn-secondary post"/>
            </div>
            <div className="containerPost addW">
                <img src="Images/addToWatchListButton.png" alt="Snow"/>
                <button type="button" className="btn btn-secondary watch"/>
            </div>
        </div>
    );
    
}

export default MoviePostItem;
