export const addStackItemType = positionId => ({
    type: 'ADD_STACK_ITEM',
    positionId
});

export const saveStackItemType = positionId => ({
    type: 'SAVE_STACK_ITEM',
    positionId
});

export const saveStackItemFailedType = positionId => ({
   type: 'SAVE_STACK_ITEM_FAILED',
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