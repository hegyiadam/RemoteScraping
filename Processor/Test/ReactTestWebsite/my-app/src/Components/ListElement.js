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
                    <img className="thumbnail" src={this.props.src}/>
                </div>
                <div className="element-text">
                    <h3 className="element-title" >Title</h3>
                    <div className="article-overview">It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).</div>
                </div>
            </div>
        );
    }
}
export default ListElement;