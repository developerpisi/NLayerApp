using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services;

public class CategoryService:Service<Category>,ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(IGenericRepository<Category> genericRepository, IUnitOfWork unitOfWork,ICategoryRepository categoryRepository,IMapper mapper) : base(genericRepository, unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryId)

    {
        var category = await _categoryRepository.GetSingleCategoryByIdWithProductsAsync(categoryId);
        var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);
        return  CustomResponseDto<CategoryWithProductsDto>.Success(200,categoryDto);
    }
    
}