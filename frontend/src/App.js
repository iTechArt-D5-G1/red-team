import React, { Component } from 'react';
import {
    BrowserRouter as Router,
    Route,
    Link
  } from 'react-router-dom'
import './dependences';
import MainPageContent from './Components/MainPageContent';
import SecondPageContent from './Components/SecondPageContent';
import LoginPageContent from './Components/LoginPageContent';

class App extends Component {





    render() {
        return (
            <div>
                <Router>
                    <div>
                    <ul>
                        <li><Link to="/">Main Page</Link></li>
                        <li><Link to="/second">Second Page</Link></li>
                        <li><Link to="/login">Sign in</Link></li>
                    </ul>

                    <Route exact path="/" component={MainPageContent}/>
                    <Route path="/second" component={SecondPageContent}/>
                    <Route path="/login" component={LoginPageContent}/>
                    </div>
                </Router>
            </div>

        );
    }
}


export default App;
