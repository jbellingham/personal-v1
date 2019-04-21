import {Field, reduxForm} from "redux-form";
import React from "react";

let LoginForm = props => {
    const { handleSubmit, isLoading, isLoggedIn } = props;
    
    return <form onSubmit={handleSubmit} className="form">
        {isLoggedIn &&
            <div className="alert alert-success" role="alert">
                Login Successful
            </div>
        }
        <div className="field">
            <div className="control">
                <label className="label">Email</label>
                <Field className="input" name="email" component="input" type="email" placeholder="Email Address"/>
            </div>
        </div>

        <div className="field">
            <div className="control">
                <label className="label">Password</label>
                <Field className="input" name="password" component="input" type="password" placeholder="Password"/>
            </div>
        </div>

        <div className="field">
            <div className="control">
                <button className="button is-link">Submit</button>
            </div>
        </div>
        {isLoading &&
            <div className="spinner-border text-primary" role="status">
                <span className="sr-only">Loading...</span>
            </div>
        }
    </form>;
};

export default LoginForm = reduxForm({
    form: 'login',
})(LoginForm);
