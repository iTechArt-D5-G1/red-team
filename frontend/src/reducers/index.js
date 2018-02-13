import { combineReducers } from 'redux'
import surveys from './surveys'
import server from './server'

const surveyApp = combineReducers({
    surveys: surveys,
    server: server
})

export default surveyApp
