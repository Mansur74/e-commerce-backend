using AutoMapper;
using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper) 
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }
        public Result Create(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);
            _categoryDal.Create(category);
            return new SuccessResult("Category created successfully");
        }

        public DataResult<ICollection<CategoryDto>> GetAll()
        {
            ICollection<Category> categories = _categoryDal.GetAll();
            ICollection<CategoryDto> result = _mapper.Map<ICollection<CategoryDto>>(categories);
            return new SuccessDataResult<ICollection<CategoryDto>>(result);
        }
    }
}
