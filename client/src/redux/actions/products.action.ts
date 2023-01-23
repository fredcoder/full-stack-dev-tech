import axios from 'axios';
import {
  API_BASE,
  GET_PRODUCTS,
  GET_PRODUCTS_ERROR,
  GET_PRODUCT,
  GET_PRODUCT_ERROR,
  POST_PRODUCT,
  POST_PRODUCT_ERROR,
  PUT_PRODUCT,
  PUT_PRODUCT_ERROR,
  CLEAR_STATE,
} from '../../global/constants';
import { ProductInputs } from '../../global/types';

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

export const getProduct = (id: string) => {
  return async (
    dispatch: (arg0: { type: string; payload: { data: object } }) => void
  ) => {
    return axios
      .get(`${API_BASE}/Products/${id}`)
      .then((response) => {
        dispatch({
          type: GET_PRODUCT,
          payload: response.data,
        });
      })
      .catch((error) => {
        dispatch({
          type: GET_PRODUCT_ERROR,
          payload: error.response.data,
        });
      });
  };
};

export const postProduct = (productInputs: ProductInputs) => {
  return async (
    dispatch: (arg0: { type: string; payload: { data: object } }) => void
  ) => {
    return axios
      .post(`${API_BASE}/Products`, productInputs)
      .then((response) => {
        dispatch({
          type: POST_PRODUCT,
          payload: response.data,
        });
      })
      .catch((error) => {
        dispatch({
          type: POST_PRODUCT_ERROR,
          payload: error.response.data,
        });
      });
  };
};

export const putProduct = (productInputs: ProductInputs) => {
  return async (
    dispatch: (arg0: { type: string; payload: { data: object } }) => void
  ) => {
    return axios
      .put(`${API_BASE}/Products/${productInputs.id}`, productInputs)
      .then((response) => {
        dispatch({
          type: PUT_PRODUCT,
          payload: response.data,
        });
      })
      .catch((error) => {
        dispatch({
          type: PUT_PRODUCT_ERROR,
          payload: error.response.data,
        });
      });
  };
};

export const clearState = () => {
  return async (dispatch: (arg0: { type: string }) => void) => {
    return dispatch({
      type: CLEAR_STATE,
    });
  };
};
