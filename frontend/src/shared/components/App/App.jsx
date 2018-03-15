import React from 'react';
import PropTypes from 'prop-types';

import HeaderMenu from './../HeaderMenu/HeaderMenu.jsx';

import './App.scss';

const App = ({ children }) => (
    <article className='app'>
        <HeaderMenu />
        {children}
    </article >
);

App.propTypes = {
    children: PropTypes.arrayOf(PropTypes.element).isRequired,
};

export default App;
