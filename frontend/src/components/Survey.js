import React from 'react';
import PropTypes from 'prop-types'

const Survey = ({onClick, text}) =>(
<li
    onClick={onClick}
  >
    {text}
  </li>
)

Survey.propTypes = {
    onClick: PropTypes.func.isRequired,
    text: PropTypes.string.isRequired
  }

export default Survey;