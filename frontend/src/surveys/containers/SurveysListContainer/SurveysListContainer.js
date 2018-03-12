import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import SurveysList from '../../components/SurveysList';
import { getSurveys as getSurveysAction } from '../../actions/';

const mapStateToProps = state => ({
    surveys: state.surveys,
});

const mapDispatchToProps = dispatch => ({
    getSurveys: bindActionCreators(getSurveysAction, dispatch),
});

const GetSurveysList = connect(
    mapStateToProps,
    mapDispatchToProps,
)(SurveysList);

export default GetSurveysList;
