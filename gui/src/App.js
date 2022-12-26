import logo from './logo.svg';
import './App.css';
import {BrowserRouter as Router, Route, Switch} from "react-router-dom";
import Login from './login/Login';

function App() {
  return (
    <Router>
      <Switch>
        <Route exact path="/" component={() => <Login/>} />
        <Route exact path="/login" component={() => <Login/>} />
      </Switch>
    </Router>
  );
}

export default App;
