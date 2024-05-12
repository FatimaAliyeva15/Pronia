using AdminArea_ProniaBusiness.Exceptions;
using AdminArea_ProniaBusiness.Services.Abstracts;
using AdminArea_ProniaCore.Models;
using AdminArea_ProniaCore.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminArea_ProniaBusiness.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryReposiroty _categoryReposiroty;

        public CategoryService(ICategoryReposiroty categoryReposiroty)
        {
            _categoryReposiroty = categoryReposiroty;
        }

        public void AddCategory(Category category)
        {
            if (category == null) throw new NullReferenceException("Category cannot be null");

            if(!_categoryReposiroty.GetAll().Any(x => x.Name == category.Name))
            {
                _categoryReposiroty.Add(category);
                _categoryReposiroty.Commit();
            }
            else
            {
                throw new DuplicateCategoryException("Category name cannot be the same");
            }
        }

        public void DeleteCategory(int id)
        {
            var existCategory = _categoryReposiroty.Get(x => x.Id == id);

            if (existCategory == null) throw new NullReferenceException("There is not category");

            _categoryReposiroty.Delete(existCategory);
            _categoryReposiroty.Commit();
        }

        public List<Category> GetAllCategories(Func<Category, bool>? func = null)
        {
            return _categoryReposiroty.GetAll(func);
        }

        public Category GetCategory(Func<Category, bool>? func = null)
        {
            return _categoryReposiroty.Get(func);
        }

        public void UpdateCategory(int id, Category newCategory)
        {
            var existCategory = _categoryReposiroty.Get(x => x.Id == id);

            if (existCategory == null) throw new NullReferenceException("There is not category");

            if(!_categoryReposiroty.GetAll().Any(x => x.Name == newCategory.Name))
            {
                existCategory.Name = newCategory.Name;
                _categoryReposiroty.Commit();
            }
            else
            {
                throw new DuplicateCategoryException("Category name cannot be the same");
            }
        }
    }
}
