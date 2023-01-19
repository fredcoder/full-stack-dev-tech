using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.tests;

public class UnitProductTest
{
    [Fact]
    public async void GetProductsTest()
    {
        using var apiContext = ApiTestContext.GetApiTestContext();
        var productsService = new ProductsService(apiContext);

        var result = await productsService.GetProducts();

        Assert.IsType<List<Product>>(result);
    }

    [Fact]
    public async void GetProductIdTest()
    {
        using var apiContext = ApiTestContext.GetApiTestContext();
        var productsService = new ProductsService(apiContext);
        var productId = "50909b94-5134-4392-be80-13bcccd2086c";

        var result = await productsService.GetProduct(productId);

        Assert.IsType<Product>(result);
    }

    [Fact]
    public async void PostProductTest()
    {
        using var apiContext = ApiTestContext.GetApiTestContext();
        var productsService = new ProductsService(apiContext);
        var newProduct = new Product
        {
            Id = "0",
            Name = "Hot Wheels",
            ProductTypeId = "d6d124a9-df5b-4ae8-848d-d15bb33bbd19",
            Price = 20.50F,
            IsActive = true
        };
        var result = await productsService.PostProduct(newProduct);

        Assert.IsType<Product>(result);
    }

    [Fact]
    public async void PutProductTest()
    {
        using var apiContext = ApiTestContext.GetApiTestContext();
        var productsService = new ProductsService(apiContext);
        var newProduct = new Product
        {
            Id = "f6095b43-57f1-49a7-9acf-ac3d145fef4f",
            Name = "XBox One",
            ProductTypeId = "d6d124a9-df5b-4ae8-848d-d15bb33bbd19",
            Price = 40.50F,
            IsActive = true
        };
        var result = await productsService.PutProduct(newProduct.Id, newProduct);

        Assert.IsType<Product>(result);
    }

    [Fact]
    public async void DeleteProductTest()
    {
        using var apiContext = ApiTestContext.GetApiTestContext();
        var productsService = new ProductsService(apiContext);
        var productId = "f6095b43-57f1-49a7-9acf-ac3d145fef4f";

        await productsService.DeleteProduct(productId);
        var result = await productsService.GetProduct(productId);

        Assert.Null(result);
    }
}