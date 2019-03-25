import { getStackItemsType, getStackItemsSuccessType, addStackItemType } from "../actions/stack";

const initialState = { stacks: [], isLoading: false };

export const actionCreators = {
    getStackItems: () => async (dispatch, getState) => {
        const st = getState().stackState;
        console.log(st);
        if (st && (st.isLoading || st.stacks.length)) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
        }
        
        dispatch({ type: getStackItemsType });

        const url = 'api/Stack';
        const response = await fetch(url);
        const result = await response.json();

        dispatch({ type: getStackItemsSuccessType, payload: result });
    },
    addStackItem: positionId => ({ type: addStackItemType, payload: { positionId }}),
};

export const reducer = (state = initialState, action) => {
    switch (action.type) {
        case getStackItemsType:
            return {
                ...state,
                isLoading: true,
            };
        
        case getStackItemsSuccessType:
            return {
                ...state,
                stacks: action.payload.positions,
                isLoading: false
            };
            
        case addStackItemType:
            return {
                ...state,
                stacks: state.stacks.map(_ =>
                    _.positionId === action.payload.positionId ?
                        {
                            ..._,
                            isAddingStackItem: true
                        } : _),// action.payload.positionId,
                // isAddingStackItem: true
            }
    }

    return state;
};
