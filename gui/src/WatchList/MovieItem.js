import "./MovieItem.css"
import { OverlayTrigger, Tooltip } from 'react-bootstrap';
function MovieItem({title, overview}){
    
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
                <div className="container add_post">
                    <img src="Images/addPost.png" alt="Snow"/>
                    <button type="button" className="btn btn-secondary"/>
                </div>
                <div className="container watched">
                    <img src="Images/watched.png" alt="Snow"/>
                    <button type="button" className="btn btn-secondary"/>
                </div>
            </dd>
            <br/>
        </div>
    );
}

export default MovieItem;

