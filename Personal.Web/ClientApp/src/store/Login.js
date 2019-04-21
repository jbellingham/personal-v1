import {
    loginRequestType,
    loginReceiveType
} from "../actions/login";
import axios from "axios";
import {TokenManager} from "../helpers/TokenManager";

const initialState = { isLoggedIn: false, isLoading: false, email: "", password: "", token: "" };

export const actionCreators = {
    login: (loginProps) => async (dispatch) => {
        if (!loginProps || !loginProps.email || !loginProps.password) {
            return
        }
        dispatch({ type: loginRequestType });
        
        const url = "api/login/login";
        try {
            const response = (await axios.post(url, { email: loginProps.email, password: loginProps.password })).data;
            dispatch({ type: loginReceiveType, payload: response })
        }
        catch (Exception) {
            dispatch({ type: loginReceiveType, payload: null })
        }
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
            TokenManager.setToken(action.payload.token);
            return {
                ...state,
                isLoggedIn: action.payload.success,
                isLoading: false
            };
    }

    return state;
};
