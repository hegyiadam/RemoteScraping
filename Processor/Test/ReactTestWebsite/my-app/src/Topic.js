import React, {Component} from "react";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  useRouteMatch,
  useParams
} from "react-router-dom";
import TitleBar from "./Components/TitleBar";

function Topic(){
    let { topicId } = useParams();

    return (
        <div className="App ">
            <header className="App-header ">
                <TitleBar title={require("./Resources/Articles/"+topicId+".json").title}></TitleBar>
            </header>
            <body className="centered" >
                <div className="article-body">

                    <div>
                        {require("./Resources/Articles/"+topicId+".json").article.map((art)=>
                            <div className="article">
                                {art}
                            </div>)}
                    </div>  
                </div>
            </body>
    
        </div>
    );
}

export default Topic;