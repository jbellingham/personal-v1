import React from 'react';
import { connect } from 'react-redux';
import WorkExperience from "./WorkExperience/WorkExperience";
import { Console } from "./Console/Console";
import { actionCreators } from "../store/Positions";
import {bindActionCreators} from "redux";

const Home = props => (
    <div>
        <div className="about-me">
            <div className="panel-inner" style={{ padding: "8em 1em" }}>
                <p style={{ textAlign: "center", fontSize:"20px" }}>
                    Hello World!
                </p>
                <h1 className="name-header" >
                    My name is Jesse
                </h1>
                <h2
                    style={{ textAlign: "center", color: "grey", marginBottom: "3em" }} >
                    I build web applications.
                </h2>
                <Console />
            </div>
        </div>
        <div id="workHistory" className="work-experience">
            <WorkExperience />
        </div>
    </div>
);

export default connect(
    null,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Home);
