import React from "react";
import { bindActionCreators } from "redux";
import { actionCreators } from "../../store/Login";
import { connect } from "react-redux";
import LoginForm from "./LoginForm";

class LoginComponent extends React.Component {
    static displayName = LoginComponent.name;
    
    login = values => {
        this.props.login(values);
    };

    render() {
        return (
            <div className="login-wrapper justify-content-center d-flex">
                <div className="panel-inner">
                    <div className="panel-header">
                        <h1 style={{ textAlign: "center" }}>
                            Login
                        </h1>
                        <hr />
                    </div>
                    <div className="content">
                        <div className="form-container">
                            <LoginForm
                                onSubmit={this.login}
                                isLoading={this.props.isLoading}
                                isLoggedIn={this.props.isLoggedIn}
                            />
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

const Login = connect(
    state => state.loginState,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(LoginComponent);

export default Login;
