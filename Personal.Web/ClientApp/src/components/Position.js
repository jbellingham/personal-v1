import React from "react"

export class Position extends React.Component {
  static displayName = Position.name

  constructor(props) {
    super(props)
    this.state = {
      positionTitle: "",
      companyName: "",
      location: "",
      startDate: "",
      endDate: "",
      duties: null,
      stack: null,
    }
  }

  render() {
    const {
      positionTitle,
      companyName,
      startDate,
      endDate,
      duties,
      location,
      stack,
    } = this.props
    return (
      <div className="row" style={{ marginBottom: "2em" }}>
        <div className="wrapper" style={{ width: "900px" }}>
          <h3>{positionTitle}</h3>
          <p>{companyName}</p>
          <p className="text-light">
            {startDate} - {endDate || "Present"}
          </p>
          <p>{location}</p>
          <ul>
            {duties &&
              (duties.length > 1 ? (
                duties.map((_, index) => <li key={index}>{_}</li>)
              ) : (
                <p>{duties[0]}</p>
              ))}
          </ul>
          {stack && (
            <div className="stack-container">
              {stack.map(item => (
                <span
                  className="stack-item"
                  style={{
                    border: "1px solid blue",
                    borderRadius: "5px",
                    marginRight: "0.5em",
                    padding: "0.2em",
                  }}
                >
                  {item}
                </span>
              ))}
            </div>
          )}
        </div>
      </div>
    )
  }
}
