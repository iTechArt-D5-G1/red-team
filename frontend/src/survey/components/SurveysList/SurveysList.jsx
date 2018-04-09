import React from 'react';
import PropTypes from 'prop-types';

import Survey from '../Survey/Survey.jsx';

class SurveysList extends React.Component {
    componentDidMount() {
        this.props.fetchSurveys();
    }

    renderSurveys = survey => (<Survey
        key={survey.id}
        {...survey}
    />);

    render() {
        const { isFetching, isError } = this.props;
        return (
            <div className='row surveys-list'>
                <div className='col-md-12'>
                    { isFetching &&
                        <h4>Fetching process ... </h4>
                    }
                    { !isError &&
                        this.props.surveys.map(this.renderSurveys)
                    }
                    { isError &&
                        <h4> Error during surveys request </h4>
                    }
                </div>
            </div>
        );
    }
}

SurveysList.propTypes = {
    surveys: PropTypes.arrayOf(PropTypes.instanceOf(Object)).isRequired,
    fetchSurveys: PropTypes.func.isRequired,
    isError: PropTypes.bool.isRequired,
    isFetching: PropTypes.bool.isRequired,
};

export default SurveysList;
