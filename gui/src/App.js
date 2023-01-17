import './App.css';
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import Login from './login/Login';
import OptionsList from './list/OptionsList';
import Feed from './Feed/Feed';
import WatchListPage from './WatchList/WatchListPage';
import SearchPage from './Search/SearchPage';
import AddPostPage from './AddPost/AddPostPage';
import EditPostPage from './EditPost/EditPostPage';

function App() {
  return (
    <Router>
      <Routes>
        <Route exact path='/' element={<Login/>} />
        <Route exact path='/feed' element={<Feed/>} />
        <Route exact path='/watchlist' element={<WatchListPage/>} />
        <Route exact path='/search' element={<SearchPage/>} />
        <Route exact path='/addpost' element={<AddPostPage/>} />
        <Route exact path='/editpost' element={<EditPostPage/>} />
      </Routes>
    </Router>
  );
}

export default App;
