import { connect } from 'react-redux';
import SurveysList from '../components/SurveysList.jsx';


// const getSurversFromServerSide = server => server.surveysArr;

// server.fetchDev(10);


//  return serverAndLocalSurveys = surveys.concat(getSurversFromServerSide(state.server));
const getSurveys = state => state.surveys;


const tempOnSurveyClick = () => {
    alert('click');
};

const mapStateToProps = state => ({
    surveys: getSurveys(state),
});


const mapDispatchToProps = {
    onSurveyClick: tempOnSurveyClick,
};

const GetSurveysList = connect(
    mapStateToProps,
    mapDispatchToProps,
)(SurveysList);

export default GetSurveysList;
