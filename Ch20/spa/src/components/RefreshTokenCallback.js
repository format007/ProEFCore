import React from 'react';
import AuthConsumer from "./AuthConsumer";

const RefreshTokenCallback = () => {
    return <AuthConsumer>
        {
            ({refreshTokenCallback}) => refreshTokenCallback()
        }
    </AuthConsumer>
};

export default RefreshTokenCallback;