import React from "react"
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { actionCreators } from "../store/Stack";

export class Stack extends React.Component {
    static displayName = Stack.name;

    constructor(props) {
        super(props);
        // this.state = {
        //     currentPositionId: "",
        //     isLoading: false,
        //     stack: [],
        // }
    }

    render() {
        const {
            addStackItem,
            isAddingStackItem,
            currentPositionId,
            isLoading,
            stack
        } = this.props;
        
        return <React.Fragment>
            {stack &&
            stack.map(item => (
                <span
                    key={`${currentPositionId}-${item.name}`}
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
            {!isAddingStackItem &&
                <button
                    key={`${currentPositionId}-create-stack-item`}
                    onClick={() => addStackItem(currentPositionId)}
                    className="stack-item btn btn-outline-primary"
                    style={{
                        color: '#e3f1ff',
                        border: "1px solid blue",
                        borderRadius: "5px",
                        marginRight: "0.5em",
                        padding: "0.2em",
                    }}
                > + Add
                </button>}
            {isAddingStackItem &&
                <input type="text"
                key={`${currentPositionId}-new-item`}
                className="stack-item"
                style={{
                    border: "1px solid blue",
                    borderRadius: "5px",
                    marginRight: "0.5em",
                    padding: "0.2em",
                    maxWidth: "5em"
                }}
                >
                </input>
            }
        </React.Fragment>
    }
}
