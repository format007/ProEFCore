import React from "react";
import AuthConsumer from "./AuthConsumer";

const AuthCallback = () => {
    return <AuthConsumer>
        {
            ({signinRedirectCallback}) => signinRedirectCallback()
        }
    </AuthConsumer>
};

export default AuthCallback;