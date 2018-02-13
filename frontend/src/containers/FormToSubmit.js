import React from 'react'
import { connect } from 'react-redux'
import { addSurvey } from '../actions/action-creators';




let FormToSubmit = ({ dispatch }) => {
    let input

    return (
        <div className='col-md-12 form-to-submit'>
            <p className='form-to-submit__header lead'>Count of models to show:</p>
        <form onSubmit={e => {
          e.preventDefault()
          if (!input.value.trim()) {
            return
          }
          dispatch(addSurvey(input.value))
          input.value = ''
        }}>
          <input onChange={e =>{
              if (!e.target.value instanceof (String)) {
                return;
            }
            const reg = /^\d+$/;
            const ourData = e.target.value;

            if (reg.test(ourData[ourData.length - 1])) {
                return;
            } else {
                e.target.value = ourData.substring(0, ourData.length - 1);
            }
          }} ref={node => {
            input = node
          }} className='form-to-submit__input-field' />
          <br/>
          <button type="submit" className='form-to-submit__submit-button'>
            Submit
          </button>
        </form>
      </div>
    )
  }
  FormToSubmit = connect()(FormToSubmit)

  export default FormToSubmit