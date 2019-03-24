import React from "react"
import { Stack } from "./Stack";
import {connect} from "react-redux";
import {bindActionCreators} from "redux";
import {actionCreators} from "../store/Stack";

export class PositionComponent extends React.Component {
  static displayName = PositionComponent.name;

  constructor(props) {
    super(props);
    this.state = {
      positionTitle: "",
      currentPositionId: "",
      companyName: "",
      location: "",
      startDate: "",
      endDate: "",
      duties: null,
      stack: []
    }
  }

  componentDidMount() {
    // This method is called when the component is first added to the document
    this.ensureDataFetched();
  }

  componentDidUpdate() {
    // This method is called when the route parameters change
    this.ensureDataFetched();
  }

  ensureDataFetched() {
    this.props.getStackItems();
  }

  render() {
    const {
      positionTitle,
      currentPositionId,
      companyName,
      startDate,
      endDate,
      duties,
      location,
      positions
    } = this.props;
    
    const position = positions.find(_ => _.positionId === currentPositionId);
    const stack = position && position.stack;
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
          <div className="stack-container">
            <Stack stack={stack} />
          </div>
        </div>
      </div>
    )
  }
}

const Position = connect(
    state => state.stack,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(PositionComponent);

export default Position;
