import React from 'react';

import SurveysListContainer from '../../containers/SurveysListContainer';
import FormToSubmit from '../../containers/FormToSubmit';

const MainPageContent = () => (
    <div className='container main_page'>
        <div className='row'>
            <FormToSubmit />
        </div>

        <SurveysListContainer />
    </div>
);

export default MainPageContent;
