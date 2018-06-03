import React from 'react';
import { Link } from 'react-router-dom';
import { surveyRootPath, helloWorldPagePath, signInPath } from '../../../shared/routePath';
import './HeaderMenu.scss';

const HeaderMenu = () => (
    <header>
        <nav>
            <ul className='menu'>
                <li className='menu__btn'><Link to={surveyRootPath} className='menu__link'>Main Page</Link></li>
                <li className='menu__btn'><Link to={helloWorldPagePath} className='menu__link'>Hello world Page</Link></li>
                <li className='menu__btn'><Link to={signInPath} className='menu__link'>Sign In</Link></li>
            </ul>
        </nav>
    </header>
);

export default HeaderMenu;

