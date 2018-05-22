import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { logoutUser } from './../../containers/logoutUser.js';

class LogOutPage extends React.Component {
    componentWillMount() {
        this.props.logoutUser();
    }

    render() {
        return <form>Sorry to see you go!</form>;
    }
}

LogOutPage.propTypes = {
    logoutUser: PropTypes.string.isRequired,
};

export default connect(null, { logoutUser })(LogOutPage);
