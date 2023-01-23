import React, { useEffect } from 'react';
import { Button } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import { clearState, getProducts } from '../../redux/actions/products.action';
import Table from 'react-bootstrap/Table';
import './index.css';
import { Product } from '../../global/types';
import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';

const ProductsPage = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const products = useSelector((store: any) => store.productsReducer.products);

  useEffect(() => {
    dispatch(getProducts());
    dispatch(clearState());
  }, [dispatch]);

  return (
    <div>
      <div>
        <h1>Products</h1>
        <Button onClick={() => navigate('/add-product')}>Add Product</Button>
        <Link to={`/AddProduct`} />
        <Table responsive="sm">
          <thead>
            <tr>
              <th>Product Name</th>
              <th>Price</th>
              <th>Type</th>
              <th>Status</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {products.map((product: Product) => (
              <tr key={product.id}>
                <td>{product.name}</td>
                <td>${(Math.round(product.price * 100) / 100).toFixed(2)}</td>
                <td>{product.productType.name}</td>
                <td>{product.isActive ? 'Active' : 'Inactive'}</td>
                <td>
                  <Button
                    variant="primary"
                    onClick={() => navigate('/edit-product/' + product.id)}
                  >
                    Edit
                  </Button>
                  <Button variant="danger" onClick={() => navigate('/')}>
                    Delete
                  </Button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
    </div>
  );
};

export default ProductsPage;
