import { createStore, combineReducers, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import productsReducer from '../reducers/products.reducer';

const reducer = combineReducers({
  productsReducer,
});

const store = createStore(reducer, applyMiddleware(thunk));

export default store;
