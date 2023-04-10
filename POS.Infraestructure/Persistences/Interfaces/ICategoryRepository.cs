namespace POS.Infraestructure.Persistences.Interfaces;

public interface ICategoryRepository
{
    Task<BaseEntityResponse<Category>> GetByFilter(BaseFiltersRequest filters);
    Task<IEnumerable<Category>> Get();
    Task<Category> GetById(int id);
    Task<bool> Create(Category category);
    Task<bool> Update(Category category);
    Task<bool> Delete(int id);
}
