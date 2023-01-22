import axios from 'axios';
import {
  API_BASE,
  GET_PRODUCT_TYPES,
  GET_PRODUCT_TYPES_ERROR,
} from '../../global/constants';

export const getProductTypes = () => {
  return async (
    dispatch: (arg0: { type: string; payload: { data: object } }) => void
  ) => {
    return axios
      .get(`${API_BASE}/ProductTypes`)
      .then((response) => {
        dispatch({
          type: GET_PRODUCT_TYPES,
          payload: response.data,
        });
      })
      .catch((error) => {
        dispatch({
          type: GET_PRODUCT_TYPES_ERROR,
          payload: error.response.data,
        });
      });
  };
};
