import React, { Component } from 'react';
import FormToSubmit from './FormToSubmit';
import SurveysList from './SurveysList';
import axios from 'axios';

const ServerURL = "http://http://localhost:8081/";

class MainPageContent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            test: null,
        };
    }

    callback(data) {
        alert('Not implemented part: wait till server side is enable');
        var requestData = axios.get( ServerURL + 'MethodName/' + data);
    }


    render() {
        return (
                <div className='container'>
                    <div className='row'>
                        <FormToSubmit call={this.callback} />
                    </div>
                    <div className='row'>
                        <SurveysList data={this.state.test} />
                    </div>
                </div>
        );
    }
}


export default MainPageContent;