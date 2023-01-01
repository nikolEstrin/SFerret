import "./OptionsList.css"
import { OverlayTrigger, Tooltip } from 'react-bootstrap';
function MovieItem({title, overview}){
    
    return (
        <div>
        <dt>{title}</dt>
        <dd>
            bbbbbbbbbbbb
            <OverlayTrigger placement="right" overlay={(<Tooltip>{overview}</Tooltip>)}>
                <div className="container">
                    <img src="Images/informationButton.png" alt="Snow"/>
                    <button type="button" className="btn btn-secondary"/>
                </div>
            </OverlayTrigger>
        </dd>
        <br/>
        </div>
    );
}

export default MovieItem;

