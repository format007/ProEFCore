import { fork, take, call, put } from "redux-saga/effects";
import {FETCH_START} from "../actionTypes";
import {fetchTasks} from "../actionCreators";
import taskWebSvc from "../../websvc/taskWebSvc";

const taskSvc = new taskWebSvc("http://localhost:5000/api/task", ()=>{});

export default function* rootSaga(){
    
    yield fork(watchFetchTasks); // запускает вилку (fork)

}

function* watchFetchTasks(action){
    while(true){
        yield take(FETCH_START); //Ждем FETCH_START
        try {
            const {data} = yield call(taskSvc.load); // выполняем загрузку данных из веб-сервиса
            yield put(fetchTasks(data)); // сохранить данные через reducer
        }
        catch(e){
            yield put(
                {type: "FETCH_FAILED",
            payload: {error: e.message}
                } 
            );
        }
    }
}
