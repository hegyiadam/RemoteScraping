import React from "react";

class TitleBar extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            
        };
    }
    render(){
        return (
        <h1>{this.props.title}</h1>
        );
    }
}
export default TitleBar;