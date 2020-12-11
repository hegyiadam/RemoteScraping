import React, { Component } from "react";
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link,
    useRouteMatch,
    useParams,
} from "react-router-dom";
import TitleBar from "./Components/TitleBar";

function Topic() {
    let { topicId } = useParams();
    var topic = require("./Resources/Articles/" + topicId + ".json");
    return (
        <div className="App ">
            <header className="App-header ">
                <TitleBar title={topic.title}></TitleBar>
            </header>
            <body className="centered">
                <div className="article-body">
                    <div>
                        {topic.article.map((art) => (
                            <div className="article">{art}</div>
                        ))}
                    </div>
                </div>
            </body>
        </div>
    );
}

export default Topic;
