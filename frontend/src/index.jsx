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
import { surveyRootPath, helloWorldPagePath, logInPath } from './shared/routePath';
import { SurveyService } from './survey/services/survey';
import { http } from './shared/utils/';
import reducer from './survey/reducer';
import App from './app/App.jsx';
import Surveys from './survey/containers/Surveys/Surveys.jsx';
import HelloWorldPage from './helloWorld/HelloWorldPage.jsx';
import LogInPage from './authentication/components/login/LogInPage.jsx';

import './index.scss';

const services = {
    surveyService: new SurveyService(http),
};

const createStoreWithMiddleware = applyMiddleware(thunk.withExtraArgument(services))(createStore);
const store = createStoreWithMiddleware(reducer);

const history = createBrowserHistory();

ReactDOM.render(
    <Provider store={store}>
        <Router history={history}>
            <App>
                <Route exact path={surveyRootPath} component={Surveys} />
                <Route path={helloWorldPagePath} component={HelloWorldPage} />
                <Route path={logInPath} component={LogInPage} />
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
