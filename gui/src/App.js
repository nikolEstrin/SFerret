import './App.css';
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import Login from './login/Login';
import OptionsList from './list/OptionsList';
import Feed from './Feed/Feed';
import WatchListPage from './WatchList/WatchListPage';
import SearchPage from './Search/SearchPage';
import movies from './list/movies';
import AddPostPage from './AddPost/AddPostPage';

function App() {
  return (
    <Router>
      <Routes>
        <Route exact path='/' element={<OptionsList/>} />
        <Route exact path='/login' element={<Login/>} />
        <Route exact path='/feed' element={<Feed/>} />
        <Route exact path='/watchlist' element={<WatchListPage/>} />
        <Route exact path='/search' element={<SearchPage/>} />
        <Route exact path='/addpost' element={<AddPostPage/>} />
      </Routes>
    </Router>
  );
}

export default App;
