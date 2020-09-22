import React, {Component} from "react";
import TitleBar from './Components/TitleBar';
import ListContainer from './Components/ListContainer';

class Home extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            
        };
    }
    render(){
        return (
            <div className="App">
              <header className="App-header ">
                <TitleBar title="RemoteScraping Test Site"/>
              </header>
              <body className="centered" >
                <ListContainer numberOfElements={10}></ListContainer>
              </body>
        
            </div>
        );
    }
}
export default Home;