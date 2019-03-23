const addStackItemType = 'ADD_STACK_ITEM';
const addStackItemSuccessType = 'ADD_STACK_ITEM_SUCCESS';

const getStackItemsType = "GET_STACK_ITEMS";
const getStackItemsSuccessType = "GET_STACK_ITEMS_SUCCESS";

const initialState = { stack: null, isLoading: false };

export const actionCreators = {
    getStackItems: positionId => async (dispatch, getState) => {
        const s = getState().stack;
        if (!positionId || s.isLoading || s.stack) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
        }
        
        dispatch({ type: getStackItemsType, positionId});

        const url = `api/Stack?positionId=${positionId}`;
        const response = await fetch(url);
        const result = await response.json();

        dispatch({ type: getStackItemsSuccessType, result });
    },
    // addStackItem: positionId => async (dispatch, getState) => {
    //     if (positionId === getState().stack.positionId) {
    //         // Don't issue a duplicate request (we already have or are loading the requested data)
    //         return;
    //     }
    //
    //     dispatch({ type: addStackItemType, positionId });
    //
    //     const url = `api/Stack?positionId=${positionId}`;
    //     const response = await fetch(url);
    //     const result = await response.json();
    //
    //     dispatch({ type: addStackItemSuccessType, result });
    // }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === getStackItemsType) {
        return {
            ...state,
            positionId: action.positionId,
            isLoading: true
        };
    }

    if (action.type === getStackItemsSuccessType) {
        return {
            ...state,
            positionId: action.positionId,
            stack: action.result.items,
            isLoading: false
        };
    }

    return state;
};
