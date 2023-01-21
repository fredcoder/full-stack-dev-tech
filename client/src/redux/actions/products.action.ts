import axios from 'axios';
import { API_BASE } from '../../global/constants';
import { GET_PRODUCTS, GET_PRODUCTS_ERROR } from '../../global/constants';

export const getProducts = () => {
  return async (
    dispatch: (arg0: { type: string; payload: { data: object } }) => void
  ) => {
    return axios
      .get(`${API_BASE}/Products`)
      .then((response) => {
        dispatch({
          type: GET_PRODUCTS,
          payload: response.data,
        });
      })
      .catch((error) => {
        dispatch({
          type: GET_PRODUCTS_ERROR,
          payload: error.response.data,
        });
      });
  };
};
