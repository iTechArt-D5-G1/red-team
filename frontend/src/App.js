import React, { Component } from 'react';
import './dependences';
import FormToSubmit from './FormToSubmit';
import SurveysList from './SurveysList';

class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            test: null,
        };
    }

    callback(data) {
        alert(data);
    }


    render() {
        return (
            <div>
                <h1 className='title-bar'>Welcome</h1>
                <div className='container'>
                    <div className='row'>
                        <FormToSubmit call={this.callback} />
                    </div>
                    <div className='row'>
                        <SurveysList data={this.state.test} />
                    </div>
                </div>
            </div>

        );
    }
}


export default App;
