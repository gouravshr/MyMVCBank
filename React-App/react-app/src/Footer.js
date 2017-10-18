import React, { Component } from 'react';
import './App.css';

export default class Footer extends Component {
  handleTitleChange(e)
  {
    console.log(e.target.value);
this.props.changeTitle(e.target.value);
  }
  render() {
    return (
      <div>
        <p>
        To get started, edit <code>src/App.js </code> and save to reload.
        <input value ={this.props.title} onChange = {this.handleTitleChange.bind(this)}/>
        </p>        
      </div>
    );
  }
}

