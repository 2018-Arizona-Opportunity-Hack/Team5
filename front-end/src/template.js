
import React, { Component } from 'react'

class Template extends Component {
  render () {
  	 var templateStyle = {
      width: 250,
      textAlign: 'center',
      position: 'center',
      backgroundColor: '#020202',
      padding: 10,
      fontFamily: 'sans-serif',
      color: '#999999',
      borderRadius: 10
    }
    return (
      <div style={templateStyle} ><Template /></div>)
  }
}
export default Template
