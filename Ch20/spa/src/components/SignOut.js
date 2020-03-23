import React from 'react';
import AuthConsumer from "./AuthConsumer";

const SignOut = () => {
    return <AuthConsumer>
        {
            ({signOut}) => 
                <button onClick={signOut}>SingOut</button>         
        }
    </AuthConsumer>
}

export default SignOut;