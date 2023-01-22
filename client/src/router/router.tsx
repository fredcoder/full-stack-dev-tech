import { createBrowserRouter } from 'react-router-dom';
import AddProduct from '../pages/AddProduct';
import Products from '../pages/Products';

const Router = createBrowserRouter([
  {
    path: '/',
    element: <Products />,
  },
  {
    path: '/add-product',
    element: <AddProduct />,
  },
]);

export default Router;
