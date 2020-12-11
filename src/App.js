import logo from "./logo.svg";
import "./App.css";
import getAllSessions from "./DAL/GetAllSessions";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import Home from "./Home";
import Session from "./Session";

import React, { Component } from "react";

function App() {
    return (
        <Router>
            <Switch>
                <Route
                    path="/:sessionid"
                    render={(props) => <Session {...props} />}
                />
                <Route path="/">
                    <Home />
                </Route>
            </Switch>
        </Router>
    );
}

export default App;
