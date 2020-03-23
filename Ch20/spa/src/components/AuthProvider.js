import React, { Component } from 'react';
import AuthService from "../websvc/authService";
import AuthContext from "./AuthContext";

export default class AuthProvider extends Component {
    authService;

    constructor(props){
        super(props);

        this.authService = new AuthService();
    }
    render() {
        return (
            <AuthContext.Provider value={this.authService}>
                {this.props.children}
            </AuthContext.Provider>
        )
    }
}
