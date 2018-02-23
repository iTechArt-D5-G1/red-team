import React from 'react';
import {
    Router,
    Route,
    Link,
} from 'react-router-dom';
import { createBrowserHistory } from 'history';

import MainPageContent from '../surveys/components/MainPage/MainPageContent.jsx';
import HelloWorldPage from '../shared/HelloWorldPage/HelloWorldPage.jsx';
import LoginPageContent from '../auth/components/Login/LoginPageContent.jsx';

import './app.scss';

const history = createBrowserHistory();

const App = () => (
    <Router history={history}>
        <div>
            <ul className='menu'>
                <li className='menu__btn'><Link to='/'>Main Page</Link></li>
                <li className='menu__btn'><Link to='/hello'>Second Page</Link></li>
                <li className='menu__btn'><Link to='/login'>Sign in</Link></li>
            </ul>
            <Route exact path='/' component={MainPageContent} />
            <Route path='/hello' component={HelloWorldPage} />
            <Route path='/login' component={LoginPageContent} />
        </div>
    </Router>
);

export default App;
