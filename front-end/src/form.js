import { FilePond } from 'react-filepond'
import 'filepond/dist/filepond.min.css'
import React, { Component } from 'react'



class Form extends Component {
  render () {
    var formStyle ={
      width: 250,
      textAlign: "center",
      position : "center",
      backgroundColor: "#020202",
      padding: 10,
      fontFamily: "sans-serif",
      color: "#999999",
      borderRadius: 10

    };

    return (
      <div style={formStyle}>
          
            <FilePond allowMultiple={true}/>
          
      </div>
    )
  }
}

export default Form  