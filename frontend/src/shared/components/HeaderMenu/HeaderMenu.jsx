import React from 'react';
import { Link } from 'react-router-dom';

import './HeaderMenu.scss';

const HeaderMenu = () => (
    <header>
        <nav>
            <ul className='menu'>
                <li className='menu__btn'><Link to='/' className='menu__link'>Main Page</Link></li>
                <li className='menu__btn'><Link to='/hello' className='menu__link'>Second Page</Link></li>
            </ul>
        </nav>
    </header>
);

export default HeaderMenu;

