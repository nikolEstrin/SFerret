import "./MovieSearchResultItem.css"
import { OverlayTrigger, Tooltip } from 'react-bootstrap';
function MovieSearchResultItem({title, overview}) {


    return (
        <div className="bodySearch">
            <dt className="searchDesign">{title}</dt>
            <dd className="searchDesign">
                <OverlayTrigger placement="right" overlay={(<Tooltip>{overview}</Tooltip>)}>
                    <div className="containerdd">
                        <img src="Images/informationButton.png" alt="Snow"/>
                        <button type="button" className="btn btn-secondary"/>
                    </div>
                </OverlayTrigger>
                <div className="container">
                    <img src="Images/addPost.png" alt="Snow"/>
                    <button type="button" className="btn btn-secondary"/>
                </div>
            </dd>
        </div>
    );
}

export default MovieSearchResultItem;