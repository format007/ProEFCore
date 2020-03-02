import {CREATE, UPDATE, DELETE, FETCH_START, FETCH, FETCH_FINISHED} from "./actionTypes";
import {TASKS} from "./dataTypes";


export const startFetchTasks = () => startFetch(TASKS);
export const fetchTasks = data => fetchObj(TASKS, data);
export const createTask = task => createObj(TASKS, task);
export const updateTask = task => updateObj(TASKS, task);
export const deleteTask = id => deleteObj(TASKS, id);
export const fetchTasksFinished = () => fetchFinished(TASKS);
export const fetchTaskStart = () => fetchStart(TASKS);

const fetchStart = (dataType) => ({
    type: FETCH_START,
    dataType: dataType
});

const fetchFinished = (dataType) => ({
    type: FETCH_FINISHED,
    dataType: dataType
});

const fetchObj = (dataType, data) => ({
    type: FETCH,
    dataType: dataType,
    payload: data
});

const startFetch = dataType => ({
    type: FETCH_START,
    dataType: dataType
});

const createObj = (dataType, data) => ({
    type: CREATE,
    dataType: dataType,
    payload: data
});

const updateObj = (dataType, data) => ({
    type: UPDATE,
    dataType: dataType,
    payload: data
});

const deleteObj = (dataType, id) => ({
    type: DELETE,
    dataType: dataType,
    payload: id
});