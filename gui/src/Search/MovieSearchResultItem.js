import "./MovieSearchResultItem.css"
import { OverlayTrigger, Tooltip } from 'react-bootstrap';
function MovieSearchResultItem({adult, collection, id, language, overview, posterPath, releaseDate, runtime, title}) {


    return (
        <div className="bodySearch">
            <dt className="searchDesign">{title}</dt>
            <dd className="searchDesign">
                <OverlayTrigger placement="bottom" overlay={(<Tooltip>{overview}</Tooltip>)}>
                    <div className="containerdd">
                        <img src="Images/informationButton.png" alt="Snow"/>
                        <button type="button" className="btn btn-secondary"/>
                    </div>
                </OverlayTrigger>
                <div className="containerdd addPostSearch">
                    <img src="Images/addPost.png" alt="Snow"/>
                    <button type="button" className="btn btn-secondary post"/>
                </div>
                <div className="containerdd addWatchList">
                    <img src="Images/addToWatchListButton.png" alt="Snow"/>
                    <button type="button" className="btn btn-secondary watch"/>
                </div>
            </dd>
        </div>
    );
}

export default MovieSearchResultItem;