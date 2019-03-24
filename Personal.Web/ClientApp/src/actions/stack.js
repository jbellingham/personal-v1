// export const addStackItemType = 'ADD_STACK_ITEM';
// const addStackItemSuccessType = 'ADD_STACK_ITEM_SUCCESS';

export const getStackItemsType = positionId => ({
    type: "GET_STACK_ITEMS",
    positionId
});

export const getStackItemsSuccessType = positionId => ({
    type: "GET_STACK_ITEMS_SUCCESS",
    positionId
});