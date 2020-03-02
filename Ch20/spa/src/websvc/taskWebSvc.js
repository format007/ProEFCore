import BaseWebService from "./baseWebSvc";

class TaskWebSvc extends BaseWebService {
    
    load(callback){
        return super.sendRequest(`${this.BASE_URL}/list`, "get", callback);
    }
}

export default TaskWebSvc;