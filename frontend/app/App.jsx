import React from 'react';
import {
    Router,
    Route,
    Link,
} from 'react-router-dom';
import { createBrowserHistory } from 'history';
import MainPageContent from '../shared/MainPage/MainPageContent.jsx';
import HelloWorldPage from '../shared/HelloWorldPage/HelloWorldPage.jsx';
import LoginPageContent from '../auth/components/Login/LoginPageContent.jsx';
import './App.scss';

const history = createBrowserHistory();

const App = () => (
    <div>
        <Router history={history}>
            <div>
                <ul>
                    <li><Link to='/'>Main Page</Link></li>
                    <li><Link to='/hello'>Second Page</Link></li>
                    <li><Link to='/login'>Sign in</Link></li>
                </ul>
                <Route exact path='/' component={MainPageContent} />
                <Route path='/hello' component={HelloWorldPage} />
                <Route path='/login' component={LoginPageContent} />
            </div>
        </Router>
    </div>
);


export default App;
