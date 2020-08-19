import React, {Component} from "react";

class ListElement extends React.Component{
    constructor(props){
        super(props);
        this.state = {
        };
    }
    render(){
        return (
            <div className="element">
                <div className="element-image">
                    <img className="thumbnail" src={require("../Resources/Thumbnails/"+this.props.itemNumber+".jpg")}/>
                </div>
                <div className="element-text">
                    <h3 className="element-title" >
                        <a href={"/topic/"+this.props.itemNumber}>
                            {require("../Resources/Articles/"+this.props.itemNumber+".json").title.split(/\s+/).slice(0,3).join(" ")}
                        </a>
                    </h3>
                    <div className="article-overview">{require("../Resources/Articles/"+this.props.itemNumber+".json").article[0]}</div>
                </div>
            </div>
        );
    }
}
export default ListElement;