import React, { Component } from 'react';
import {
    BrowserRouter as Router,
    Route,
    Link
  } from 'react-router-dom'

  import MainPageContent from './MainPageContent';
  import HelloWorldPage from './HelloWorldPage';
  import LoginPageContent from './LoginPageContent';

const App = () => (
        <div>
            <Router>
                <div>
                    <ul>
                        <li><Link to="/">Main Page</Link></li>
                        <li><Link to="/hello">Second Page</Link></li>
                        <li><Link to="/login">Sign in</Link></li>
                    </ul>
                    <Route exact path="/" component={MainPageContent}/>
                    <Route path="/hello" component={HelloWorldPage}/>
                    <Route path="/login" component={LoginPageContent}/>
                </div>
            </Router>
        </div>
)


export default App;
