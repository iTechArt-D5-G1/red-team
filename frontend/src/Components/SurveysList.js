import React, { Component } from 'react';

class SurveysList extends Component {
    render() {
        return (
            <div className='col-m-12 surveys-list__content'>
                <p>{this.props.data}</p>
            </div>
        );
    }
}


export default SurveysList;
