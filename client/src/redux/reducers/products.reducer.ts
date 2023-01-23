import {
  GET_PRODUCT,
  GET_PRODUCTS,
  GET_PRODUCTS_ERROR,
  GET_PRODUCT_ERROR,
  POST_PRODUCT,
  POST_PRODUCT_ERROR,
  PUT_PRODUCT,
  PUT_PRODUCT_ERROR,
  CLEAR_STATE,
} from '../../global/constants';
import { Action } from '../../global/types';

const INITIAL_STATE = {
  products: [],
  productsError: '',
  product: {},
  productError: '',
  isProductLoaded: false,
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
    case GET_PRODUCT:
      return {
        ...state,
        product: action.payload,
        isProductLoaded: true,
      };
    case GET_PRODUCT_ERROR:
      return {
        ...state,
        productError: action.payload,
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
    case PUT_PRODUCT:
      return {
        ...state,
        product: action.payload,
        isProductUpdated: true,
      };
    case PUT_PRODUCT_ERROR:
      return {
        ...state,
        productError: action.payload,
        isProductUpdated: false,
      };
    case CLEAR_STATE:
      return {
        ...state,
        product: {},
        isProductLoaded: false,
        isProductCreated: false,
        isProductUpdated: false,
        isProductDeleted: false,
      };
    default:
      return state;
  }
};

export default reducer;
