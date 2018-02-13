import axios from 'axios';
import React, { Component } from 'react';
import FormToSubmit from '../containers/FormToSubmit';
import GetSurveysList from '../containers/GetSurveysList';
import { addSurvey } from '../actions/action-creators';
import { store } from '../index';

const ServerURL = 'http://http://localhost:8081/';

class MainPageContent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            test: null,
        };
    }

    callback(data) {
        alert('Not implemented part: wait till server side is enable');
        const requestData = axios.get(`${ServerURL}MethodName/${data}`);
    }


    render() {
        return (
            <div className='container'>
                <div className='row'>
                    <FormToSubmit />
                </div>

                <GetSurveysList />

            </div>
        );
    }
}


export default MainPageContent;