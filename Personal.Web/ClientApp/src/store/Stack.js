import { getStackItemsType, getStackItemsSuccessType, addStackItemType, saveStackItemType } from "../actions/stack";
import axios from "axios";

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
        const response = (await axios.get(url)).data;

        dispatch({ type: getStackItemsSuccessType, payload: response });
    },
    addStackItem: positionId => ({ type: addStackItemType, payload: { positionId }}),
    
    saveStackItem: (event, positionId) => async (dispatch) => {
        const value = event.target.value;
        if (value) {
            const payload = { positionId, value: value };
            dispatch({ type: saveStackItemType, payload: payload});
            await axios({
                url: 'api/Stack',
                method: 'POST',
                data: {
                    'positionId': payload.positionId,
                    'value': payload.value
                }
            });            
        }
    }
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
            };
        
        case saveStackItemType:
            return {
                ...state,
                stacks: state.stacks.map(_ =>
                    _.positionId === action.payload.positionId ?
                        {
                            ..._,
                            stack: [..._.stack, { name: action.payload.value }],
                            isAddingStackItem: false
                        } : _)
            };
    }

    return state;
};
