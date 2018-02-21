import { connect } from 'react-redux';

import SurveysList from '../../components/SurveysList';
import HttpUtility from '../../utils';
// server.fetchDev(10);
const getSurversFromServerSide = () => HttpUtility.GetSurveys();

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
