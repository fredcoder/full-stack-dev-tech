import React, { useEffect, useState } from 'react';
import { Button, Form } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import '../../assets/styles/app.css';
import {
  Product,
  ProductErrors,
  ProductInputs,
  ProductType,
} from '../../global/types';
import { useForm } from 'react-hook-form';
import { getProductTypes } from '../../redux/actions/productTypes.action';
import { postProduct } from '../../redux/actions/products.action';
import { useNavigate } from 'react-router-dom';
import {
  PRODUCT_ERRORS_INITIAL_STATE,
  PRODUCT_INITIAL_STATE,
} from '../../global/constants';

const AddProductPage = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const { register, handleSubmit } = useForm<ProductInputs>();

  const isProductCreated = useSelector(
    (store: any) => store.productsReducer.isProductCreated
  );
  const productTypes = useSelector(
    (store: any) => store.productTypesReducer.productTypes
  );

  const [productForm, setProductForm] = useState<ProductInputs>(
    PRODUCT_INITIAL_STATE
  );
  const [productFormErrors, setProductFormErrors] = useState<ProductErrors>(
    PRODUCT_ERRORS_INITIAL_STATE
  );

  useEffect(() => {
    dispatch(getProductTypes());
    if (isProductCreated) {
      navigate('/');
    }
  }, [dispatch, isProductCreated, navigate]);

  const onChangeInput = (key: keyof Product, value: string | boolean) => {
    setProductFormErrors(PRODUCT_ERRORS_INITIAL_STATE);
    setProductForm({
      ...productForm,
      [key]: value,
    });
  };

  const isValidForm = () => {
    let isValid = true;

    let errors: ProductErrors = { ...PRODUCT_ERRORS_INITIAL_STATE };
    for (const [key, value] of Object.entries(productForm)) {
      if (value === null || value === '') {
        errors[key as keyof ProductErrors] = 'This field is required';
        isValid = false;
      }
    }
    setProductFormErrors({ ...PRODUCT_ERRORS_INITIAL_STATE, ...errors });
    return isValid;
  };

  const onSubmit = () => {
    if (isValidForm()) {
      dispatch(postProduct(productForm));
    }
  };

  return (
    <div className={'product-div'}>
      <h1>Add Product</h1>
      <Form onSubmit={handleSubmit(onSubmit)}>
        <Form.Group className="mb-3" controlId="productName">
          <Form.Label>Name</Form.Label>
          <Form.Control
            type="text"
            placeholder="Enter product name"
            {...register('name')}
            isInvalid={!!productFormErrors.name}
            onChange={(e) =>
              onChangeInput(e.target.name as keyof Product, e.target.value)
            }
          />
          <p style={{ color: 'red', fontSize: 12 }}>{productFormErrors.name}</p>
        </Form.Group>
        <Form.Group className="mb-3" controlId="productPrice">
          <Form.Label>Price</Form.Label>
          <Form.Control
            type="number"
            step=".01"
            placeholder="Enter product price"
            {...register('price')}
            value={productForm?.price}
            isInvalid={!!productFormErrors.price}
            onChange={(e) =>
              onChangeInput(e.target.name as keyof Product, e.target.value)
            }
          />
          <p style={{ color: 'red', fontSize: 12 }}>
            {productFormErrors.price}
          </p>
        </Form.Group>
        <Form.Group className="mb-3" controlId="productType">
          <Form.Label>Type</Form.Label>
          <Form.Select
            aria-label="Type"
            {...register('productTypeId')}
            value={productForm?.productTypeId}
            isInvalid={!!productFormErrors.productTypeId}
            onChange={(e) =>
              onChangeInput(e.target.name as keyof Product, e.target.value)
            }
          >
            <option value="">Select product type</option>
            {productTypes.map((productType: ProductType) => (
              <option key={productType.id} value={productType.id}>
                {productType.name}
              </option>
            ))}
          </Form.Select>
          <p style={{ color: 'red', fontSize: 12 }}>
            {productFormErrors.productTypeId}
          </p>
        </Form.Group>
        <Form.Group className="mb-3" controlId="productStatus">
          <Form.Label>Active</Form.Label>
          <Form.Check
            type="switch"
            {...register('isActive')}
            checked={productForm.isActive}
            onChange={(e) => {
              onChangeInput(e.target.name as keyof Product, e.target.checked);
            }}
          />
        </Form.Group>
        <Form.Group className="buttons-box">
          <Button variant="secondary" onClick={() => navigate('/')}>
            Cancel
          </Button>

          <Button variant="primary" type="submit">
            Submit
          </Button>
        </Form.Group>
      </Form>
    </div>
  );
};

export default AddProductPage;
