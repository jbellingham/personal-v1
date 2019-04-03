import React from "react"

export class Socials extends React.Component {
    static displayName = Socials.name;

    render() {
        return (
            <div style={{width: "40px", position: "fixed", bottom: "0px", left: "40px", color: "black"}}
            >
                <ul className="socials-container" style={{ display: "flex", flexDirection: "column", alignItems: "center", listStyleType: "none" }}>
                    <li style={{ paddingBottom: "1em" }}><a target="_blank" href="https://www.linkedin.com/in/jesse-bellingham/"><i className="fab fa-linkedin fa-2x" /></a></li>
                    <li style={{ paddingBottom: "1em" }}><a target="_blank" href="https://github.com/jessebellingham/"><i className="fab fa-github-square fa-2x" /></a></li>
                    <li style={{ paddingBottom: "1em" }}><a href="mailto:jbellingham91@gmail.com"><i className="fas fa-envelope fa-2x" /></a></li>
                </ul>
            </div>
        )
    }
}
