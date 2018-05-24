import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { logoutUser } from './../../containers/logoutUser.js';

class LogOutPage extends React.Component {
    componentWillMount() {
        this.props.logoutUser();
    }

    render() {
        return <div>Sorry to see you go!</div>;
    }
}

LogOutPage.propTypes = {
    logoutUser: PropTypes.func.isRequired,
};

export default connect(null, { logoutUser })(LogOutPage);
