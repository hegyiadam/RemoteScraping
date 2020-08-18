import ListElement from "./ListElement";
import React, {Component} from "react";

class ListContainer extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            elements:  Array(props.numberOfElements).fill(null),
        };
    }
    render(){
        const elements = this.state.elements.map((number,id)=>
                <div className="list-container">
                    <ListElement  src={require("../Resources/Thumbnails/"+id+".jpg")}/>
                </div>
            );
        return <div>{elements}</div>;
    }
}
export default ListContainer;