import React, { Component } from 'react';
import  './Styles/hello-world-page.scss';

class HelloWorldPage extends Component{
    render(){
        return(
            <div className = 'Container hello-world-page'>
                <p className = 'hello-world-page__content'>Hello World!</p>
            </div>
        );
    }
}


export default HelloWorldPage;