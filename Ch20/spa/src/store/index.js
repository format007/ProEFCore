import {createStore, applyMiddleware} from "redux";
import modelReducer from "./modelReducer";
import createSagaMiddleware from "redux-saga";
import rootSaga from "./sagas";

const sagaMiddleware = createSagaMiddleware();

export default createStore(modelReducer, applyMiddleware(sagaMiddleware));

sagaMiddleware.run(rootSaga);

export {CREATE, UPDATE, DELETE, FETCH, FETCH_FINISHED, FETCH_START} from "./actionTypes";
export {TASKS} from "./dataTypes";
export { createTask, deleteTask, fetchTasks, fetchTasksFinished, fetchTaskStart } from "./actionCreators";