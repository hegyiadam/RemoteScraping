import React from 'react';
import logo from './logo.svg';
import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import Home from './Home' 
import Topic from './Topic' 

function App() {
  return (
    
    <Router>
        <Switch>
          <Route path="/topic/:topicId"  component={Topic} />
          <Route path="/">
            <Home />
          </Route>
        </Switch>
    </Router>
  );
}

export default App;
