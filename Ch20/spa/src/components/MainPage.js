import React, { Component } from 'react';
import TaskDisplay from "./TaskDisplay/";
import OrderDisplay from "./OrderDisplay";
import AuthCallback from "./AuthCallback";
import {NavLink as Link, Route, Switch, Redirect} from "react-router-dom";
import mgr from "../websvc/authMgr";
import LoginAuth from "../websvc/loginAuth";

export default class MainPage extends Component {
    constructor(props){
        super(props);

        this.state = {
            menuindex : 0,
            logged: false
        };

        this.loginAuthSvc = new LoginAuth("http://localhost:5000/Account/Login", "alice", "alice");
    }
    
    login =  async () => {
        let user =await mgr.getUser();
        if (!user) {
            await this.loginAuthSvc.login();
            let result = await mgr.signinSilent();
            console.log(result);
        }
    };

    logout = () => {
        mgr.signoutRedirect();
    };

    checkLogged = () => {
        mgr.getUser().then( user => {
            user ? this.setState({logged: true}) : this.setState({logged:false})
        });
    };

    api = async () => {
        let user = await mgr.getUser();
        if (!user)
            await this.login();

        var url = "http://localhost:5001/identity";
        var xhr = new XMLHttpRequest();
        xhr.open("GET", url);
        xhr.onload = function () {
            console.log(JSON.parse(xhr.responseText));
            }
        xhr.setRequestHeader("Authorization", "Bearer " + user.access_token);
        xhr.send();
    } 

    render() {
        return (
            <div>
                {this.state.logged.toString()}
                <Link to="/orders" activeStyle={ {"color":"red" } }>Orders</Link>
                <Link to="/tasks">Tasks 1</Link>
                <Link to="/login">Login</Link>
                <Switch>
                    <Route path="/orders" component={ OrderDisplay }/>
                    <Route path="/tasks" component={ TaskDisplay }/>
                    <Route path="/callback" component={AuthCallback}/>
                    <Redirect to="orders"/>
                </Switch>

                <button onClick={this.login}>Login</button>
                <button onClick={this.api}>Api</button>
                <button onClick={this.logout}>Logout</button>

            </div>
        )
    }
}