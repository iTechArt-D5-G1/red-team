import React, { Component } from 'react';
import FormToSubmit from '../containers/FormToSubmit';
import GetSurveysList from '../containers/GetSurveysList';
import { addSurvey } from '../actions/action-creators';


const MainPageContent = () =>(
    <div className='container main_page'>
        <div className='row'>
            <FormToSubmit />
        </div>

    <GetSurveysList />
</div>
)

export default MainPageContent;