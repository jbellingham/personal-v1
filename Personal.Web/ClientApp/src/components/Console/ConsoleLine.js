import React from "react"

export class ConsoleLine extends React.Component {
  static displayName = ConsoleLine.name

  constructor(props) {
    super(props)
    this.state = { lineTitle: "", lineDescription: "", lineLink: "" }
  }

  render() {
    const { lineTitle, lineDescription, lineLink } = this.props
    return (
      <div style={{ margin: "1em 2em" }}>
        <p className="row code-text">>&nbsp;{lineTitle}</p>
        {(lineLink && <span>=> <a href={lineLink}>{lineDescription}</a></span>) ||
          (lineDescription && (
            <p className="row code-text" style={{ paddingLeft: "1em" }}>
              => {lineDescription}
            </p>
          ))}
      </div>
    )
  }
}
