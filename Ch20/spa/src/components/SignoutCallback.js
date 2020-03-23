import React from 'react';
import AuthConsumer from "./AuthConsumer";

const SignoutCallback = () => {
    return <AuthConsumer>
        {
            ({signoutCallback}) => signoutCallback()
        }
    </AuthConsumer>
};

export default SignoutCallback;
