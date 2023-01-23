import React, { useEffect, useState } from 'react';
import { Button, Modal } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import {
  clearState,
  deleteProduct,
  getProducts,
} from '../../redux/actions/products.action';
import Table from 'react-bootstrap/Table';
import '../../assets/styles/app.css';
import { Product } from '../../global/types';
import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';
import DeleteIcon from '../../assets/images/delete-icon.png';
import EditIcon from '../../assets/images/edit-icon.png';
import AddIcon from '../../assets/images/add-icon.png';

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
    <>
      <div className={'main-div'}>
        <h1>Products</h1>
        <Button
          variant="default"
          className={'icon-button'}
          onClick={() => navigate('/add-product')}
        >
          <img width="30" src={AddIcon} alt="Add" />
          Add Product
        </Button>
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
                    variant="default"
                    className={'icon-button'}
                    onClick={() => navigate('/edit-product/' + product.id)}
                  >
                    <img width="30" src={EditIcon} alt="Delete" />
                  </Button>
                  <Button
                    variant="default"
                    className={'icon-button'}
                    onClick={() => toggleDeletingModal(product.id)}
                  >
                    <img width="30" src={DeleteIcon} alt="Delete" />
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
    </>
  );
};

export default ProductsPage;
