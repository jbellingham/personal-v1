import React from 'react';
import { connect } from 'react-redux';
import WorkExperience from "./WorkExperience";
import { Console } from "./Console";
import { actionCreators } from "../store/Positions";
import {bindActionCreators} from "redux";

const Home = props => (
    <div>
        <div style={{ marginBottom: "5em" }}>
            <div className="row justify-content-center">
                <div className="wrapper" style={{ width: "900px" }}>
                    <p
                        className="d-flex justify-content-center"
                        style={{ color: "#00FF00" }}
                    >
                        Hello World!
                    </p>
                    <h1
                        className="d-flex justify-content-center"
                        style={{ color: "grey", marginBottom: "5em" }}
                    >
                        I build web applications.
                    </h1>
                    <Console />
                </div>
            </div>
        </div>
        <WorkExperience />
    </div>
);

export default connect(
    null,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Home);
