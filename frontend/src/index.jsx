import 'bootstrap/dist/css/bootstrap.min.css';
import React from 'react';
import {
    Router,
    Route,
} from 'react-router-dom';
import ReactDOM from 'react-dom';
import jwtDecode from 'jwt-decode';
import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import { createBrowserHistory } from 'history';
import { surveyRootPath, helloWorldPagePath, signInPath } from './shared/routePath';
import { SurveyService } from './survey/services/survey';
import { AuthService } from './authentication/services/authService';
import { http } from './shared/utils/';
import reducer from './survey/reducer';
import App from './app/App.jsx';
import Surveys from './survey/containers/Surveys/Surveys.jsx';
import HelloWorldPage from './helloWorld/HelloWorldPage.jsx';
import SignInPage from './authentication/components/SignIn/SignInPage.jsx';

import './index.scss';

const services = {
    surveyService: new SurveyService(http),
    authService: new AuthService(http),
};

const createStoreWithMiddleware = applyMiddleware(thunk.withExtraArgument(services))(createStore);
const store = createStoreWithMiddleware(reducer);

const history = createBrowserHistory();

const checkTokenExpired = () => {
    const token = JSON.parse(localStorage.getItem('token'));
    if (token && jwtDecode(token).exp < Date.now().valueOf() / 1000) {
        localStorage.clear();
        return false;
    } else if (token) {
        return true;
    } else {
        return false;
    }
};

ReactDOM.render(
    <Provider store={store}>
        <Router history={history}>
            <App>
                <Route
                    exact
                    path={checkTokenExpired ? surveyRootPath : signInPath}
                    component={checkTokenExpired ? Surveys : SignInPage}
                />
                <Route path={helloWorldPagePath} component={HelloWorldPage} />
            </App>
        </Router>
    </Provider>,
    document.getElementById('app'),
);

if (module.hot) {
    // Whenever a new version of App.js is available
    module.hot.accept('./app/App.jsx', () => {
        // Require the new version and render it instead
        const NextApp = App;
        ReactDOM.render(<NextApp />, 'app');
    });
}
