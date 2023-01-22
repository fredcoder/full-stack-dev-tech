export type Action = {
  type: string;
  payload: object;
};

export type ProductType = {
  id: string;
  name: string;
};

export type Product = {
  id: string;
  name: string;
  price: number;
  isActive: boolean;
  productTypeId: string;
  productType: ProductType;
};

export type ProductInputs = {
  id: string;
  name: string;
  price: number;
  isActive: boolean;
  productTypeId: string;
};
