import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import SurveysList from '../../components/SurveysList';
import { surveysRequest } from '../../actions/';

const mapStateToProps = state => ({
    surveys: state.surveys.surveys,
    isError: state.surveys.isError,
    isFetching: state.surveys.isFetching,
});

const mapDispatchToProps = dispatch => ({
    fetchSurveys: bindActionCreators(surveysRequest, dispatch),
});

const GetSurveysList = connect(
    mapStateToProps,
    mapDispatchToProps,
)(SurveysList);

export default GetSurveysList;
