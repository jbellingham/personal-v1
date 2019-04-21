import React from "react"
import {TokenManager} from "../../helpers/TokenManager";

export default class Stack extends React.Component {
    static displayName = Stack.name;
    
    render() {
        const {
            addStackItem,
            saveStackItem,
            isAddingStackItem,
            currentPositionId,
            isLoading,
            stack
        } = this.props;
        
        const isLoggedIn = TokenManager.isLoggedIn();
        
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
            {isLoggedIn &&
            !isAddingStackItem &&
                <button
                    key={`${currentPositionId}-create-stack-item`}
                    onClick={() => addStackItem(currentPositionId)}
                    className="stack-item btn btn-outline-primary"
                    style={{
                        color: '#333333',
                        border: "1px solid blue",
                        borderRadius: "5px",
                        marginBottom: "0.25em",
                        padding: "0.2em",
                    }}
                > + Add
                </button>}
            {isAddingStackItem &&
                <input type="text"
                key={`${currentPositionId}-new-item`}
                className="stack-item"
                autoFocus={true}
                style={{
                    border: "1px solid blue",
                    borderRadius: "5px",
                    marginRight: "0.5em",
                    padding: "0.2em",
                    maxWidth: "5em"
                }}
               onBlur={(e) => saveStackItem(e, currentPositionId)}
                >
                </input>
            }
        </React.Fragment>
    }
}
