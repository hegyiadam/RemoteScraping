import React from 'react';
import logo from './logo.svg';
import TitleBar from './Components/TitleBar';
import './App.css';
import ListContainer from './Components/ListContainer';

function App() {
  return (
    <div className="App">
      <header className="App-header ">
        <TitleBar/>
      </header>
      <body className="centered" >
        <ListContainer numberOfElements={10}></ListContainer>
      </body>

    </div>
  );
}

export default App;
