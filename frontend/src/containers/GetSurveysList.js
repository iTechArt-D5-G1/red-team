import { connect } from 'react-redux'
import SurveysList from '../components/SurveysList';

const getSurveys = (surveys) => {
    return surveys;
}

const tempOnSurveyClick = () =>{
    alert('click');
}

const mapStateToProps = (state) => ({
  surveys: getSurveys(state.surveys)
})


const mapDispatchToProps = {
    onSurveyClick:tempOnSurveyClick
}

const GetSurveysList = connect(
  mapStateToProps,
  mapDispatchToProps
)(SurveysList)

export default GetSurveysList
