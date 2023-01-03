import "./MovieSearchResultItem.css"
import { OverlayTrigger, Tooltip } from 'react-bootstrap';
function MovieSearchResultItem({title, overview}) {


    return (
        <div>
            <dt>{title}</dt>
            <dd>
                <OverlayTrigger placement="right" overlay={(<Tooltip>{overview}</Tooltip>)}>
                    <div className="container">
                        <img src="Images/informationButton.png" alt="Snow"/>
                        <button type="button" className="btn btn-secondary"/>
                    </div>
                </OverlayTrigger>
            </dd>
        </div>
    );
}

export default MovieSearchResultItem;