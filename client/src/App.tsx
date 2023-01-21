import React from 'react';
import { Button } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import './App.css';
import { getProducts } from './redux/actions/products.action';

const App = () => {
  const dispatch = useDispatch();
  const products = useSelector((store: any) => store.productsReducer.products);

  return (
    <div>
      <div>
        <h1>Products Management Solution</h1>
        {products.map((product: any) => (
          <p>{product.name}</p>
        ))}
        <Button onClick={() => dispatch(getProducts())}>Get Products</Button>
      </div>
    </div>
  );
};

export default App;
