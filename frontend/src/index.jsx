import 'bootstrap/dist/css/bootstrap.min.css';
import React from 'react';
import {
    Router,
    Route,
} from 'react-router-dom';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import { createBrowserHistory } from 'history';

import App from './App/App.jsx';
import reducer from './surveys/reducers';
import Surveys from './surveys/components/Surveys/Surveys.jsx';
import HelloWorldPage from './shared/helloWorld/HelloWorldPage.jsx';

import './assets/stylesheets/index.scss';

const createStoreWithMiddleware = applyMiddleware(thunk)(createStore);
const store = createStoreWithMiddleware(reducer);

const history = createBrowserHistory();

ReactDOM.render(
    <Provider store={store}>
        <Router history={history}>
            <App >
                <Route exact path='/' component={Surveys} />
                <Route path='/hello' component={HelloWorldPage} />
            </App>
        </Router>
    </Provider>,
    document.getElementById('app'),
);

if (module.hot) {
    // Whenever a new version of App.js is available
    module.hot.accept('./App/App.jsx', () => {
        // Require the new version and render it instead
        const NextApp = App;
        ReactDOM.render(<NextApp />, 'app');
    });
}
