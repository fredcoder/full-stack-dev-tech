import React, { useEffect, useState } from 'react';
import { Button, Modal } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import {
  clearState,
  deleteProduct,
  getProducts,
} from '../../redux/actions/products.action';
import Table from 'react-bootstrap/Table';
import './index.css';
import { Product } from '../../global/types';
import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';

const ProductsPage = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const { products, isProductDeleted } = useSelector(
    (store: any) => store.productsReducer
  );

  const [openModal, setOpenModal] = useState(false);
  const [deletingId, setDeletingId] = useState('');

  useEffect(() => {
    dispatch(getProducts());
    dispatch(clearState());
    if (isProductDeleted) {
      setOpenModal(false);
    }
  }, [dispatch, isProductDeleted]);

  const toggleDeletingModal = (id: string) => {
    setOpenModal(!openModal);
    setDeletingId(id);
  };

  const deleteProductItem = () => {
    dispatch(deleteProduct(deletingId));
  };

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
                  <Button
                    variant="danger"
                    onClick={() => toggleDeletingModal(product.id)}
                  >
                    Delete
                  </Button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
      <Modal show={openModal} onHide={() => toggleDeletingModal('')}>
        <Modal.Header closeButton>
          <Modal.Title>Delete Product</Modal.Title>
        </Modal.Header>
        <Modal.Body>Are you sure you want to delete this item?</Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => toggleDeletingModal('')}>
            Cancel
          </Button>
          <Button variant="danger" onClick={deleteProductItem}>
            Yes
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default ProductsPage;
