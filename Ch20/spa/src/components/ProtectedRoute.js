import React from "react";
import AuthConsumer from './AuthConsumer';
import {Route} from "react-router-dom";

export const ProtectedRoute = ({ component, ...rest }) => {
    const renderFn = (Component) => (props) => (
        <AuthConsumer>
            {
            ({ isAuthenticated, signinRedirect }) => {
                if (isAuthenticated()) {
                    return <Component {...props} />;
                } else {
                    signinRedirect();
                    return <span>loading</span>;
                }
            }
            }
        </AuthConsumer>
    );

    return <Route {...rest} render={renderFn(component)} />;
};

export default ProtectedRoute;