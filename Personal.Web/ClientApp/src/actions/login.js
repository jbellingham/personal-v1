export const loginRequestType = loginRequest => ({
    type: 'LOGIN_REQUEST_TYPE',
    loginRequest
});

export const loginReceiveType = loginResult => ({
    type: 'SAVE_STACK_ITEM',
    loginResult
});