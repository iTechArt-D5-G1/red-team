import 'bootstrap/dist/css/bootstrap.min.css';
import React from 'react';
import {
    Router,
    Route,
    Link,
} from 'react-router-dom';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import { createBrowserHistory } from 'history';

import Surveys from './surveys/components/Surveys/Surveys.jsx';
import HelloWorldPage from './shared/components/HelloWorldPage/HelloWorldPage.jsx';
import LoginPage from './auth/components/Login/LoginPage.jsx';
import reducer from './surveys/reducers';
import './assets/stylesheets/index.scss';

const createStoreWithMiddleware = applyMiddleware(thunk)(createStore);
const store = createStoreWithMiddleware(reducer);

const history = createBrowserHistory();

ReactDOM.render(
    <Provider store={store}>
        <Router history={history}>
            <article className='app'>
                <header>
                    <nav>
                        <ul className='menu'>
                            <li className='menu__btn'><Link to='/' className='menu__link'>Main Page</Link></li>
                            <li className='menu__btn'><Link to='/hello' className='menu__link'>Second Page</Link></li>
                            <li className='menu__btn'><Link to='/login' className='menu__link'>Sign in</Link></li>
                        </ul>
                    </nav>
                </header>
                <Route exact path='/' component={Surveys} />
                <Route path='/hello' component={HelloWorldPage} />
                <Route path='/login' component={LoginPage} />
            </article >
        </Router>
    </Provider>,
    document.getElementById('app'),
);

if (module.hot) {
    // Whenever a new version of App.js is available
    module.hot.accept('./surveys/components/Surveys', () => {
        // Require the new version and render it instead
        const NextApp = Surveys;
        ReactDOM.render(<NextApp />, 'app');
    });
}
