import {
  CLEAR_STATE,
  GET_PRODUCTS,
  GET_PRODUCTS_ERROR,
  POST_PRODUCT,
  POST_PRODUCT_ERROR,
} from '../../global/constants';
import { Action } from '../../global/types';

const INITIAL_STATE = {
  products: [],
  productsError: '',
  product: {},
  productError: '',
  isProductCreated: false,
  isProductUpdated: false,
  isProductDeleted: false,
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
        productsError: action.payload,
      };
    case POST_PRODUCT:
      return {
        ...state,
        product: action.payload,
        isProductCreated: true,
      };
    case POST_PRODUCT_ERROR:
      return {
        ...state,
        productError: action.payload,
        isProductCreated: false,
      };
    case CLEAR_STATE:
      return {
        ...state,
        product: {},
        isProductCreated: false,
        isProductUpdated: false,
        isProductDeleted: false,
      };
    default:
      return state;
  }
};

export default reducer;
