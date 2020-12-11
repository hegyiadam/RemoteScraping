import React, { Component } from "react";

function ListElement(props) {
    let articleContent = require("../Resources/Articles/" +
        props.itemNumber +
        ".json");
    return (
        <div className="element">
            <div className="element-image">
                <img
                    className="thumbnail"
                    src={require("../Resources/Thumbnails/" +
                        props.itemNumber +
                        ".jpg")}
                />
            </div>
            <div className="element-text">
                <h3 className="element-title">
                    <a href={"/topic/" + props.itemNumber}>
                        {articleContent.title}
                    </a>
                </h3>
                <div className="article-overview">{articleContent.article}</div>
            </div>
        </div>
    );
}
export default ListElement;
