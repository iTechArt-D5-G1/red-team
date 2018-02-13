import { connect } from 'react-redux'
import SurveysList from '../components/SurveysList';


const getSurversFromServerSide = (server) =>{
    server.fetchDev(10);
    if(server.isFetching == false)
        return server.surveysArr;
}


const getSurveys = (state) => {
    //uncomment when ready
    //return serverAndLocalSurveys = surveys.concat(getSurversFromServerSide(state.server))
    return state.surveys;
}

const tempOnSurveyClick = () =>{
    alert('click');
}

const mapStateToProps = (state) => ({
  surveys: getSurveys(state)
})


const mapDispatchToProps = {
    onSurveyClick:tempOnSurveyClick
}

const GetSurveysList = connect(
  mapStateToProps,
  mapDispatchToProps
)(SurveysList)

export default GetSurveysList
