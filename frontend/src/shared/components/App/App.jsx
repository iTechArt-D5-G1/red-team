import React from 'react';
import { Route } from 'react-router-dom';

import Surveys from './../../../surveys/components/Surveys/Surveys.jsx';
import HelloWorldPage from './../HelloWorldPage/HelloWorldPage.jsx';
import LoginPage from './../../../auth/components/Login/LoginPage.jsx';
import HeaderMenu from './../HeaderMenu/HeaderMenu.jsx';

const App = () => (
    <article className='app'>
        <HeaderMenu />
        <Route exact path='/' component={Surveys} />
        <Route path='/hello' component={HelloWorldPage} />
        <Route path='/login' component={LoginPage} />
    </article >
);

export default App;
