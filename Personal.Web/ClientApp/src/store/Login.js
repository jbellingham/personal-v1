import {
    loginRequestType,
    loginReceiveType
} from "../actions/login";
import axios from "axios";

const initialState = { isLoggedIn: false, isLoading: false, email: "", password: "" };

export const actionCreators = {
    login: (loginProps) => async (dispatch) => {
        if (!loginProps || !loginProps.email || !loginProps.password) {
            return
        }
        dispatch({ type: loginRequestType });
        
        const url = "api/login/login";
        const response = (await axios.post(url, { email: loginProps.email, password: loginProps.password })).data;
        
        dispatch({ type: loginReceiveType, payload: response })
    }
};

export const reducer = (state = initialState, action) => {
    switch (action.type) {
        case loginRequestType:
            return {
                ...state,
                isLoading: true,
            };

        case loginReceiveType:
            return {
                ...state,
                isLoggedIn: action.payload.success,
                isLoading: false
            };
    }

    return state;
};
