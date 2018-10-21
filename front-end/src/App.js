import React, { Component } from 'react'
import {
  Route,
  NavLink,
  HashRouter
} from 'react-router-dom'
import Form from './form'
import Landing from './landing'
import Progress from './reports'
class App extends Component {
  render () {
    return (
      <HashRouter>
        <div>
          <h1>flumby</h1>
          <ul className='header'>
            <li><NavLink to='/landing'>Sign In </NavLink></li>
            <li><NavLink to='/form' >Upload Docs</NavLink></li>
            <li><NavLink to='/reports'>Reports</NavLink></li>
          </ul>
          <div className='content'>
            <Route path='/landing' component={Landing} />
            <Route path='/form' component={Form} />
            <Route path='/reports' component={Progress} />
          </div>
        </div>
      </HashRouter>)
  }
}

export default App
