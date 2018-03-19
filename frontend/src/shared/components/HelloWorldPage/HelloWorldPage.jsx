import React from 'react';

import './hello-world-page.scss';
import helloWorldPageBackground from './hello-world-page-background.png';

const HelloWorldPage = () => (
    <section className='hello-world-page'>
        <p className='hello-world-page__text'>Hello World!</p>
        <img src={helloWorldPageBackground} alt='Error during load' className='hello-world-page__image' />
    </section>
);

export default HelloWorldPage;
