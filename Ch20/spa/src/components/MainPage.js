import React, { Component } from 'react';
import {BrowserRouter as Router, Route, Switch} from "react-router-dom";
import ProtectedRoute from "./ProtectedRoute";
import clientRoutes from "../routes/clientRoutes";
import AuthCallback from "./AuthCallback";
import RefreshTokenCallback from "./RefreshTokenCallback";
import SignoutCallback from "./SignoutCallback";
import ProtectedPage from "./ProtectedPage";
import MainMenu from "./MainMenu";
import AuthProvider from './AuthProvider';

export default class MainPage extends Component {
    render() {
        return (
            <AuthProvider>
            <Router>
                <MainMenu/>
                <Switch>
                    <Route exact={true} path={clientRoutes.oidc.callback} 
                        component={AuthCallback}/>
                    <Route exact={true} path={clientRoutes.oidc.refreshToken} 
                        component={RefreshTokenCallback}/>
                    <Route exact={true} path={clientRoutes.oidc.signoutCallback} 
                        component={SignoutCallback}/>
                    <ProtectedRoute path="/" component={ProtectedPage}/>
                </Switch>
            </Router>
            </AuthProvider>
        )
    }
}
