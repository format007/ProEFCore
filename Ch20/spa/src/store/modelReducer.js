import initialStore from "./initialStore";
import {CREATE, UPDATE, DELETE, FETCH} from "./actionTypes";

export default (state, action) => {
    switch (action.type) {

    case FETCH: 
        return {
            ...state, 
            [action.dataType]: action.payload
    }
    case CREATE:
        return { 
            ...state, 
            [action.dataType]: [...state[action.dataType], action.payload]
         };
    case UPDATE:
        return { 
            ...state, 
            [action.dataType]: [...state[action.dataType], action.payload]
         };
    case DELETE:
            return { 
                ...state, 
                [action.dataType]: state[action.dataType].filter(item => item.id !== action.payload)
             };
    default:
        return state || initialStore;
    }
}
