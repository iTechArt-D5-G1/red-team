import React from 'react';
import PropTypes from 'prop-types';

const Survey = ({ text }) => (
    <div>
        {text}
    </div>
);

Survey.propTypes = {
    text: PropTypes.string.isRequired,
};

export default Survey;
