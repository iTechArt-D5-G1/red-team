import React from 'react';
import PropTypes from 'prop-types';

const Survey = ({ onClick, text }) => (
    <div
        className='col-md-12'
        onClick={onClick}
        onKeyPress={onClick}
    >
        {text}
    </div>
);

Survey.propTypes = {
    onClick: PropTypes.func.isRequired,
    text: PropTypes.string.isRequired,
};

export default Survey;
