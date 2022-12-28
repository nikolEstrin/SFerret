import OptionsList from "./OptionsList";
import "./OptionsList.css"
function Feed() {


    return (
        <div className="container">
            <div className="row">
                <div className="col-4">
                    <OptionsList/>
                </div>
                <div className="col-8">
                    <h1>Feed</h1>
                </div>
            </div>
            
        </div>
    );
}

export default Feed;