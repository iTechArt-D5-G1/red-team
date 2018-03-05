import React from 'react';
import {
    Router,
    Route,
    Link,
} from 'react-router-dom';
import { createBrowserHistory } from 'history';

import MainPage from '../surveys/components/MainPage/MainPage.jsx';
import HelloWorldPage from '../shared/HelloWorldPage/HelloWorldPage.jsx';
import LoginPage from '../auth/components/Login/LoginPage.jsx';

import './app.scss';

const history = createBrowserHistory();

const App = () => (
    <Router history={history}>
        <article className='content'>
            <header>
                <nav>
                    <ul className='menu'>
                        <li className='menu__btn'><Link to='/' className='menu_link'>Main Page</Link></li>
                        <li className='menu__btn'><Link to='/hello' className='menu_link'>Second Page</Link></li>
                        <li className='menu__btn'><Link to='/login' className='menu_link'>Sign in</Link></li>
                    </ul>
                </nav>
            </header>
            <Route className='content__element' exact path='/' component={MainPage} />
            <Route className='content__element' path='/hello' component={HelloWorldPage} />
            <Route className='content__element' path='/login' component={LoginPage} />
        </article >
    </Router>
);

export default App;
