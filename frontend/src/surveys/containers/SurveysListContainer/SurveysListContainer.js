import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import SurveysList from '../../components/SurveysList';
import { surveysRequest } from '../../action';

const mapStateToProps = state => ({
    surveys: state.surveys,
    isError: state.isError,
    isFetching: state.isFetching,
});

const mapDispatchToProps = dispatch => ({
    fetchSurveys: bindActionCreators(surveysRequest, dispatch),
});

const GetSurveysList = connect(
    mapStateToProps,
    mapDispatchToProps,
)(SurveysList);

export default GetSurveysList;
