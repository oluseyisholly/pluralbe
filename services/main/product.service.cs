using System.Linq.Expressions;
using AutoMapper;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Exceptions;
using EcommerceWebApi.IRepository;
using EcommerceWebApi.IService;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.Service
{
    public class ProductService(IProductRepository ProductRepository, IMapper mapper)
        : IProductService
    {
        private readonly IProductRepository _ProductRepository = ProductRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<StandardResponse<CreateProductDto>> CreateProduct(
            CreateProductDto createProductDto
        )
        {
            var Product = _mapper.Map<Product>(createProductDto);

            await _ProductRepository.Create(Product);

            return new StandardResponse<CreateProductDto>
            {
                Message = "Created Successfully",
                Data = createProductDto,
            };
        }

        public async Task<StandardResponse<List<CreateProductDto>>> GetAllProducts()
        {
            var Products = await _ProductRepository.GetAll();

            var result = _mapper.Map<List<CreateProductDto>>(Products);

            return new StandardResponse<List<CreateProductDto>>
            {
                Message = "success",
                Data = result,
            };
        }

        public async Task<StandardResponse<PaginatedResponse<ProductDto>>> GetPaginatedAllProducts(
            ProductsQuery query
        )
        {
            var filter =
                query.CategoryId != null
                    ? (Expression<Func<Product, bool>>)(p => p.CategoryId == query.CategoryId)
                    : null;

            var Products = await _ProductRepository.GetPaginatedAll(query, filter, p => p.Category);

            var mappedItems = _mapper.Map<List<ProductDto>>(Products.Data);

            return new StandardResponse<PaginatedResponse<ProductDto>>
            {
                Message = "success",
                Data = new PaginatedResponse<ProductDto>(
                    mappedItems,
                    Products.TotalRecords,
                    Products.PageNumber,
                    Products.PageSize
                ),
            };
        }

        public async Task<StandardResponse<CreateProductDto>> DeleteProduct(int Id)
        { //check if Product exists
            var existingProduct = await _ProductRepository.GetById(Id);

            if (existingProduct is null)
            {
                throw new UnprocessibleEntityException("Product Does Not Exist");
            }

            var result = await _ProductRepository.Delete(existingProduct);

            var Product = _mapper.Map<CreateProductDto>(result);

            return new StandardResponse<CreateProductDto> { Message = "success", Data = Product };
        }

        public async Task<StandardResponse<UpdateProductDto>> UpdateProduct(
            int Id,
            UpdateProductDto updateProductDto
        )
        { //check if Product exists
            var existingProduct = await _ProductRepository.GetById(Id);

            if (existingProduct is null)
            {
                throw new UnprocessibleEntityException("Product Does Not Exist");
            }

            var Product = _mapper.Map(updateProductDto, existingProduct);

            await _ProductRepository.Update(Product);

            return new StandardResponse<UpdateProductDto>
            {
                Message = "success",
                Data = updateProductDto,
            };
        }

        public async Task<StandardResponse<Product>> GetProductById()
        {
            throw new NotImplementedException();
        }
    }
}
