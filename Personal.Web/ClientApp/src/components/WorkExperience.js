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
        <div className="panel-inner">
          <div className="work-experience-header">
            <h1 style={{ textAlign: "center" }}>
              Work Experience
            </h1>
            <hr />
          </div>
          {positions && positions.map(_ => (
            <div className="content"
                 key={`${_.companyName}-${_.startDate}`}
            >
              <Position
                positionTitle={_.title}
                currentPositionId={_.positionId}
                companyName={_.companyName}
                startDate={_.startDate}
                endDate={_.endDate}
                location={_.location}
                duties={_.duties}
              />
            </div>
          ))}
        </div>
    );
  }
}

const WorkExperience = connect(
    state => state.positions,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(WorkExperienceComponent);

export default WorkExperience;
