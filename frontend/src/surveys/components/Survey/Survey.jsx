import React from 'react';
import PropTypes from 'prop-types';

const Survey = ({ text }) => (
    <div className='col-md-12'>
        {text}
    </div>
);

Survey.propTypes = {
    text: PropTypes.string.isRequired,
};

export default Survey;
