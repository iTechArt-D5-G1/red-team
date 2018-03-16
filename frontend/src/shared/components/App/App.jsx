import React from 'react';
import PropTypes from 'prop-types';

import HeaderMenu from './../HeaderMenu/HeaderMenu.jsx';

import './App.scss';

const App = ({ children }) => (
    <main className='app'>
        <HeaderMenu />
        <article className='app__element'>
            {children}
        </article>
    </main >
);

App.propTypes = {
    children: PropTypes.arrayOf(PropTypes.element).isRequired,
};

export default App;
