import React from 'react';

const AuthContext = React.createContext({
        getUser: () => {},
        signinRedirectCallback: () => {},
        refreshTokenCallback: () => {},
        isAuthenticated: () => {},
        signIn: () => {}
    }
);

export default AuthContext;