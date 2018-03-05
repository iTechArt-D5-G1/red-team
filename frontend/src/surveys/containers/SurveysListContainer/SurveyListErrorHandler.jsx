import React from 'react';
import PropTypes from 'prop-types';

class SurveyListErrorHandler extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            hasError: false,
        };
    }

    componentDidCatch(error, info) {
        this.setState({ hasError: true });
        console.log(info);
    }

    render() {
        if (this.state.hasError) {
            return <h2 >Some error occure in SurveyList component! </h2>;
        }
        return this.props.children;
    }
}

SurveyListErrorHandler.propTypes = {
    children: PropTypes.element.isRequired,
};

export default SurveyListErrorHandler;
