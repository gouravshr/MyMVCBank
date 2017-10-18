import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Title from './Title';

export default class Header extends Component {
  
    render() {
    return (
      <div className="App">
        
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1>{this.props.title}</h1>               
        
        </header>
               
      </div>
    );
  }
}

