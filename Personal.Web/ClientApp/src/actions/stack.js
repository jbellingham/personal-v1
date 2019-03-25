export const addStackItemType = positionId => ({
    type: 'ADD_STACK_ITEM',
    positionId
});

const addStackItemSuccessType = positionId => ({
    type: 'ADD_STACK_ITEM_SUCCESS',
    positionId
});

export const getStackItemsType = positionId => ({
    type: "GET_STACK_ITEMS",
    positionId
});

export const getStackItemsSuccessType = positionId => ({
    type: "GET_STACK_ITEMS_SUCCESS",
    positionId
});