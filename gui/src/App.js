import './App.css';
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import Login from './login/Login';
import OptionsList from './list/OptionsList';
import Feed from './list/Feed';
import WatchListPage from './list/WatchListPage';
import SearchPage from './list/SearchPage';
import movies from './list/movies';

function App() {
  return (
    <Router>
      <Routes>
        <Route exact path='/' element={<OptionsList/>} />
        <Route exact path='/login' element={<Login/>} />
        <Route exact path='/feed' element={<Feed/>} />
        <Route exact path='/watchlist' element={<WatchListPage/>} />
        <Route exact path='/search' element={<SearchPage/>} />


      </Routes>
    </Router>
  );
}

export default App;
