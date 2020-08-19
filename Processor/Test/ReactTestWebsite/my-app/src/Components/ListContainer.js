import ListElement from "./ListElement";
import PaginationList from 'react-pagination-list';
import React, {Component} from "react";

class ListContainer extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            elements:  Array.from(Array(10).keys()),
        };
    }
    render(){
        return <PaginationList
        data={this.state.elements}
        pageSize={4}
        renderItem={(item) => (
            <ListElement src={require("../Resources/Thumbnails/"+item+".jpg")}/>
        )}></PaginationList>;
    }
}
export default ListContainer;