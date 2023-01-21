import { GET_PRODUCTS, GET_PRODUCTS_ERROR } from '../../global/constants';
import { Action } from '../../global/types';

const INITIAL_STATE = {
  products: [],
  productsError: '',
};

const reducer = (state = INITIAL_STATE, action: Action) => {
  switch (action.type) {
    case GET_PRODUCTS:
      return {
        ...state,
        products: action.payload,
      };
    case GET_PRODUCTS_ERROR:
      return {
        ...state,
        products: action.payload,
      };
    default:
      return state;
  }
};

export default reducer;
