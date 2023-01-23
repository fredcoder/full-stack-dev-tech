import { createBrowserRouter } from 'react-router-dom';
import Products from '../pages/Products';
import AddProduct from '../pages/AddProduct';
import EditProduct from '../pages/EditProduct';

const Router = createBrowserRouter([
  {
    path: '/',
    element: <Products />,
  },
  {
    path: '/add-product',
    element: <AddProduct />,
  },
  {
    path: '/edit-product/:id',
    element: <EditProduct />,
  },
]);

export default Router;
