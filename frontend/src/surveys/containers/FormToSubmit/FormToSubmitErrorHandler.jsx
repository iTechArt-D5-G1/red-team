import React from 'react';
import PropTypes from 'prop-types';

class FormToSubmitErrorHandler extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            hasError: false,
        };
    }

    componentDidCatch() {
        this.setState({ hasError: true });
    }

    render() {
        if (this.state.hasError) {
            return <h1 >Some error occure in FormToSubmit component! </h1>;
        }
        return this.props.children;
    }
}

FormToSubmitErrorHandler.propTypes = {
    children: PropTypes.element.isRequired,
};

export default FormToSubmitErrorHandler;
