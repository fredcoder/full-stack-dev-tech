import React, { useEffect } from 'react';
import { Button, Form } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import './index.css';
import { ProductInputs, ProductType } from '../../global/types';
import { useForm, SubmitHandler } from 'react-hook-form';
import { getProductTypes } from '../../redux/actions/productTypes.action';
import { postProduct } from '../../redux/actions/products.action';
import { useNavigate } from 'react-router-dom';

const AddProductPage = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const isProductCreated = useSelector(
    (store: any) => store.productsReducer.isProductCreated
  );
  const productTypes = useSelector(
    (store: any) => store.productTypesReducer.productTypes
  );

  useEffect(() => {
    dispatch(getProductTypes());
    console.log('isProductCreated', isProductCreated);
    if (isProductCreated) {
      navigate('/');
    }
  }, [dispatch, isProductCreated, navigate]);

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<ProductInputs>();

  const onSubmit: SubmitHandler<ProductInputs> = async (newProduct) => {
    newProduct.id = '0';
    dispatch(postProduct(newProduct));
  };

  return (
    <div>
      <h1>Add Product</h1>
      <Form onSubmit={handleSubmit(onSubmit)}>
        <Form.Group className="mb-3" controlId="productName">
          <Form.Label>Name</Form.Label>
          <Form.Control
            type="text"
            placeholder="Enter product name"
            {...register('name', { required: true })}
          />
          {errors.name && <span>This field is required</span>}
        </Form.Group>
        <Form.Group className="mb-3" controlId="productPrice">
          <Form.Label>Price</Form.Label>
          <Form.Control
            type="number"
            step=".01"
            placeholder="Enter product price"
            {...register('price', { required: true })}
          />
          {errors.price && <span>This field is required</span>}
        </Form.Group>
        <Form.Group className="mb-3" controlId="productType">
          <Form.Label>Type</Form.Label>
          <Form.Select
            aria-label="Type"
            {...register('productTypeId', { required: true })}
          >
            <option value="">Select product type</option>
            {productTypes.map((productType: ProductType) => (
              <option key={productType.id} value={productType.id}>
                {productType.name}
              </option>
            ))}
          </Form.Select>
          {errors.productTypeId && <span>This field is required</span>}
        </Form.Group>
        <Form.Group className="mb-3" controlId="productStatus">
          <Form.Check
            type="checkbox"
            label="Active"
            {...register('isActive')}
          />
        </Form.Group>

        <Button variant="secundary" onClick={() => navigate('/')}>
          Cancel
        </Button>

        <Button variant="primary" type="submit">
          Submit
        </Button>
      </Form>
    </div>
  );
};

export default AddProductPage;
