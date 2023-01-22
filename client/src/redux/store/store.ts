import { createStore, combineReducers, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import productsReducer from '../reducers/products.reducer';
import productTypesReducer from '../reducers/productTypes.reducer';

const reducer = combineReducers({
  productsReducer,
  productTypesReducer,
});

const store = createStore(reducer, applyMiddleware(thunk));

export default store;
