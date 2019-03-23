import React from "react";
import Position from "./Position";
import { bindActionCreators } from "redux";
import { actionCreators } from "../store/Positions";
import { connect } from "react-redux";

class WorkExperienceComponent extends React.Component {
  static displayName = WorkExperienceComponent.name;

  componentDidMount() {
    // This method is called when the component is first added to the document
    this.ensureDataFetched();
  }

  componentDidUpdate() {
    // This method is called when the route parameters change
    this.ensureDataFetched();
  }

  ensureDataFetched() {
    this.props.requestPositions();
  }

  render() {

    const { positions } = this.props;
    return (
      <div className="row">
        <div className="wrapper" style={{ width: "900px" }}>
          <h1 className="d-flex justify-content-center">
            ----- Work Experience ------
          </h1>
          {positions && positions.map(_ => (
            <Position
              key={`${_.companyName}-${_.startDate}`}
              positionTitle={_.title}
              positionId={_.positionId}
              companyName={_.companyName}
              startDate={_.startDate}
              endDate={_.endDate}
              location={_.location}
              duties={_.duties}
              stack={_.stack}
            />
          ))}
        </div>
      </div>
    );
  }
}

const WorkExperience = connect(
  state => state.positions,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(WorkExperienceComponent);

export default WorkExperience;
