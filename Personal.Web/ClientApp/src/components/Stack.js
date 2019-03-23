import React from "react"
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { actionCreators } from "../store/Stack";

class StackComponent extends React.Component {
    static displayName = StackComponent.name

    constructor(props) {
        super(props);
        this.state = {
            stack: null,
        }
    }

    render() {
        const {
            positionId,
            stack,
            newStackItem
        } = this.props
        return <React.Fragment>
            {stack &&
            stack.map(item => (
                <span
                    key={`${positionId}-${item.name}`}
                    className="stack-item"
                    style={{
                        border: "1px solid blue",
                        borderRadius: "5px",
                        marginRight: "0.5em",
                        padding: "0.2em",
                    }}
                >
                {item.name}
              </span>
            ))}
            <button
                key={`${positionId}-create-stack-item`}
                onClick={this.newStackItemClicked()}
                className="stack-item btn btn-outline-primary"
                style={{
                    color: '#e3f1ff',
                    border: "1px solid blue",
                    borderRadius: "5px",
                    marginRight: "0.5em",
                    padding: "0.2em",
                }}
            > + Add
            </button>
            {this.props.addingStackItem &&
                <input type="text"
                key={`${positionId}-new-item`}
                className="stack-item"
                style={{
                    border: "1px solid blue",
                    borderRadius: "5px",
                    marginRight: "0.5em",
                    padding: "0.2em",
                }}
                >
                </input>
            }
        </React.Fragment>
    }

    newStackItemClicked() {
        
    }
}

const Stack = connect(
    state => state.stack,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(StackComponent);

export default Stack;
