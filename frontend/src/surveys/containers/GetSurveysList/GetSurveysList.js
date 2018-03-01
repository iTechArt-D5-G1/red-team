import { connect } from 'react-redux';

import SurveysList from '../../components/SurveysList';
import { getSurveys as getSurveysAction } from '../../actions/';

const getSurversFromServerSide = dispatch => dispatch(getSurveysAction);

const getSurveys = state => state.surveys;

const tempOnSurveyClick = () => {
    alert('click');
};

const mapStateToProps = state => ({
    surveys: getSurveys(state),
});

const mapDispatchToProps = dispatch => ({
    onSurveyClick: tempOnSurveyClick,
    serverSurveys: getSurversFromServerSide(dispatch),
});

const GetSurveysList = connect(
    mapStateToProps,
    mapDispatchToProps,
)(SurveysList);

export default GetSurveysList;
