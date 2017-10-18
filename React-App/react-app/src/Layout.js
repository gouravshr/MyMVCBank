import React, { Component } from 'react';

import './App.css';
import Header from './Header';
import Footer from './Footer';

class Layout extends Component {
  
constructor(){
super();
this.state ={title:"Welcome"};
}

  changeTitle(title)
  {
    this.setState({title:title});
  }
  
  render() {
    return (
      <div className="App">
      <Header title= {this.state.title} />
      <Footer changeTitle = {this.changeTitle.bind(this)} />
      </div>
    );
  }
}

export default Layout;
