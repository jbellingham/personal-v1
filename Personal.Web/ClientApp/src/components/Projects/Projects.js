import React from "react";

export default class Projects extends React.Component {
    static displayName = Projects.name;

    render() {
        return (
            <div className="panel-inner">
                <div className="panel-header">
                    <h2>
                        Some things I've made
                    </h2>
                    <hr />
                </div>
                <div className="projects-container">
                    <div className="project-wrapper">
                        <div className="project-links">
                            <ul className="project-links-list list" style={{justifyContent: "flex-end"}}>
                                <li><a target="_blank" href="https://github.com/JesseBellingham/read-me-a-story"><i className="fab fa-github-square fa-2x" /></a></li>
                                <li><a target="_blank" href="http://www.2minutestories.io/"><i className="fas fa-link fa-2x" /></a></li>
                            </ul>
                        </div>
                        <h4>Tell Me A Story</h4>
                        <p>A web app utilizing the reddit API to bring a random short story from the current best.</p>
                        <ul className="tech-container list">
                            <li>NodeJS</li>
                            <li>Heroku</li>
                            <li>Reddit API</li>
                            <li>Bootstrap CSS</li>
                        </ul>
                    </div>
                    <div className="project-wrapper">
                        <div className="project-links">
                            <ul className="project-links-list list" style={{justifyContent: "flex-end"}}>
                                <li><a target="_blank" href="https://github.com/JesseBellingham/personal-v1"><i className="fab fa-github-square fa-2x" /></a></li>
                            </ul>
                        </div>
                        <h4>This web app</h4>
                        <p>What you're looking at right now.</p>
                        <ul className="tech-container list">
                            <li>.Net Core</li>
                            <li>React.js</li>
                            <li>Redux</li>
                            <li>PostgreSQL</li>
                        </ul>
                    </div>
                </div>
            </div>
        );
    }
}
