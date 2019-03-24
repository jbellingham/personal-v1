import { getStackItemsType, getStackItemsSuccessType } from "../actions/stack";

const initialState = { positions: [], isLoading: false };

export const actionCreators = {
    getStackItems: () => async (dispatch, getState) => {
        const s = getState().stack;
        console.log(s);
        if (s && (s.isLoading || s.positions.length)) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
        }
        
        dispatch({ type: getStackItemsType });

        const url = 'api/Stack';
        const response = await fetch(url);
        const result = await response.json();

        dispatch({ type: getStackItemsSuccessType, payload: result });
    },
    // addStackItem: positionId => ({ type: addStackItemType, positionId }),
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
                positions: action.payload.positions,
                isLoading: false
            };
            
        // case addStackItemType:
        //     return {
        //         ...state,
        //         newStackItemPositionId: action.positionId,
        //         isAddingStackItem: true
        //     }
    }

    return state;
};
