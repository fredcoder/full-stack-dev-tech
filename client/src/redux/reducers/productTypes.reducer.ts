import {
  GET_PRODUCT_TYPES,
  GET_PRODUCT_TYPES_ERROR,
} from '../../global/constants';
import { Action } from '../../global/types';

const INITIAL_STATE = {
  productTypes: [],
  productTypesError: '',
};

const reducer = (state = INITIAL_STATE, action: Action) => {
  switch (action.type) {
    case GET_PRODUCT_TYPES:
      return {
        ...state,
        productTypes: action.payload,
      };
    case GET_PRODUCT_TYPES_ERROR:
      return {
        ...state,
        productTypes: action.payload,
      };
    default:
      return state;
  }
};

export default reducer;
