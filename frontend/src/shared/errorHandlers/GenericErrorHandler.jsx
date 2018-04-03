import React from 'react';
import PropTypes from 'prop-types';

class GenericErrorHandler extends React.Component {
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
            return <h1 >Some error occurred!</h1>;
        }
        return this.props.children;
    }
}

GenericErrorHandler.propTypes = {
    children: PropTypes.arrayOf(PropTypes.element.isRequired).isRequired,
};

export default GenericErrorHandler;
