using AutoMapper;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Dto;
using EcommerceWebApi.Exceptions;
using EcommerceWebApi.IRepository;
using EcommerceWebApi.IService;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.Service
{
    public class CategoryService(ICategoryRepository CategoryRepository, IMapper mapper)
        : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository = CategoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<StandardResponse<CreateCategoryDto>> CreateCategory(
            CreateCategoryDto createCategoryDto
        )
        {
            var Category = _mapper.Map<Category>(createCategoryDto);

            await _CategoryRepository.Create(Category);

            return new StandardResponse<CreateCategoryDto>
            {
                Message = "Created Successfully",
                Data = createCategoryDto,
            };
        }

        public async Task<StandardResponse<List<CreateCategoryDto>>> GetAllCategories()
        {
            var Categorys = await _CategoryRepository.GetAll();

            var result = _mapper.Map<List<CreateCategoryDto>>(Categorys);

            return new StandardResponse<List<CreateCategoryDto>>
            {
                Message = "success",
                Data = result,
            };
        }

        public async Task<
            StandardResponse<PaginatedResponse<CategoryDto>>
        > GetPaginatedAllCategories(PaginationQuery query)
        {
            var Categories = await _CategoryRepository.GetPaginatedAll(query, null);

            var mappedItems = _mapper.Map<List<CategoryDto>>(Categories.Data);

            return new StandardResponse<PaginatedResponse<CategoryDto>>
            {
                Message = "success",
                Data = new PaginatedResponse<CategoryDto>(
                    mappedItems,
                    Categories.TotalRecords,
                    Categories.PageNumber,
                    Categories.PageSize
                ),
            };
        }

        public async Task<StandardResponse<CreateCategoryDto>> DeleteCategory(int Id)
        { //check if Category exists
            var existingCategory = await _CategoryRepository.GetById(Id);

            if (existingCategory is null)
            {
                throw new UnprocessibleEntityException("Category Does Not Exist");
            }

            var result = await _CategoryRepository.SoftDelete(existingCategory);

            var Category = _mapper.Map<CreateCategoryDto>(result);

            return new StandardResponse<CreateCategoryDto> { Message = "success", Data = Category };
        }

        public async Task<StandardResponse<UpdateCategoryDto>> UpdateCategory(
            int Id,
            UpdateCategoryDto updateCategoryDto
        )
        { //check if Category exists
            var existingCategory = await _CategoryRepository.GetById(Id);

            if (existingCategory is null)
            {
                throw new UnprocessibleEntityException("Category Does Not Exist");
            }

            var Category = _mapper.Map(updateCategoryDto, existingCategory);

            await _CategoryRepository.Update(Category);

            return new StandardResponse<UpdateCategoryDto>
            {
                Message = "success",
                Data = updateCategoryDto,
            };
        }

        public async Task<StandardResponse<Category>> GetCategoryById()
        {
            throw new NotImplementedException();
        }
    }
}
