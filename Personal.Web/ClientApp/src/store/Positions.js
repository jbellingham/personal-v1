import {bindActionCreators} from "redux";

const requestPositionsType = 'REQUEST_POSITIONS';
const receivePositionsType = 'RECEIVE_POSITIONS';
const initialState = { positions: null, isLoading: false };

export const actionCreators = {
  requestPositions: () => async (dispatch, getState) => {
    const s = getState().positions;
    if (s.isLoading || s.positions) {
      // Don't issue a duplicate request (we already have or are loading the requested data)
      return;
    }

    dispatch({ type: requestPositionsType });

    const url = "api/WorkExperience/";
    const response = await fetch(url);
    const result = await response.json();

    dispatch({ type: receivePositionsType, result });
  }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestPositionsType) {
    return {
      ...state,
      isLoading: true
    };
  }

  if (action.type === receivePositionsType) {
    return {
      ...state,
      positions: action.result.positions,
      isLoading: false
    };
  }

  return state;
};
