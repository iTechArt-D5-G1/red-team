import { connect } from 'react-redux';
import SurveysList from '../components/SurveysList/SurveysList.jsx';

// server.fetchDev(10);
const getSurversFromServerSide = server => server.surveysArr;

const getSurveys = state => state.surveys.concat(getSurversFromServerSide(state.server));

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
