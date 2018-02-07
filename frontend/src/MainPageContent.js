import React, { Component } from 'react';
import FormToSubmit from './FormToSubmit';
import SurveysList from './SurveysList';

class MainPageContent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            test: null,
        };
    }

    callback(data) {
        alert('Not Implement: get server data From that point ant pass it to SurveysList');
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