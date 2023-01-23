export const API_BASE = 'http://localhost:81/api';

export const GET_PRODUCTS = 'getProducts';
export const GET_PRODUCTS_ERROR = 'getProductsError';
export const GET_PRODUCT = 'getProduct';
export const GET_PRODUCT_ERROR = 'getProductError';
export const POST_PRODUCT = 'postProductError';
export const POST_PRODUCT_ERROR = 'postProductError';
export const PUT_PRODUCT = 'putProductError';
export const PUT_PRODUCT_ERROR = 'putProductError';

export const GET_PRODUCT_TYPES = 'getProductTypes';
export const GET_PRODUCT_TYPES_ERROR = 'getProductTypesError';

export const CLEAR_STATE = 'clearState';

export const PRODUCT_ERRORS_INITIAL_STATE = {
  name: '',
  price: '',
  productTypeId: '',
};

export const PRODUCT_INITIAL_STATE = {
  id: '0',
  name: '',
  price: 0,
  isActive: true,
  productTypeId: '',
};
