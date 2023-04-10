namespace POS.Infraestructure.Persistences.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{ 
    private readonly POSContext _context;

    public CategoryRepository(POSContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(Category category)
    {
        category.AuditCreateUser = 1;
        category.AuditCreateDate = DateTime.Now;

        await _context.AddAsync(category);

        var recordsAffected = await _context.SaveChangesAsync();

        return recordsAffected > 0;

    }

    public async Task<bool> Delete(int id)
    {
        var recordsAffected = 0;
        var category = await _context.Categories
                                        .AsNoTracking()
                                        .SingleOrDefaultAsync(x => x.CategoryId.Equals(id));

        if(category is not null)
        {
            category.AuditDeleteUser = 1;
            category.AuditDeleteDate = DateTime.Now;

            _context.Update(category);

            recordsAffected = await _context.SaveChangesAsync();
        }

        return recordsAffected > 0;

    }

    public async Task<IEnumerable<Category>> Get()
    {
        var categories = await _context.Categories
                                    .Where(x => x.State.Equals(1)
                                                    && x.AuditDeleteUser == null
                                                    && x.AuditDeleteDate == null)
                                    .AsNoTracking()
                                    .ToListAsync();

        return categories;
    }

    public async Task<BaseEntityResponse<Category>> GetByFilter(BaseFiltersRequest filters)
    {
        var response = new BaseEntityResponse<Category>();

        var categories = (from c in _context.Categories
                          where c.AuditDeleteUser == null 
                                && c.AuditDeleteDate == null
                          select c)
                          .AsNoTracking()
                          .AsQueryable();

        if(filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
        {
            switch (filters.NumFilter)
            {
                case 1:
                    categories = categories.Where(x => x.Name!.Contains(filters.TextFilter));
                    break;
                case 2:
                    categories = categories.Where(x => x.Description!.Contains(filters.TextFilter));
                    break;
            }
        }

        if(filters.StateFilter is not null)
        {
            categories = categories.Where(x => x.State.Equals(filters.StateFilter));        
        }

        if(!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
        {
            categories = categories.Where(x => x.AuditCreateDate >= Convert.ToDateTime(filters.StartDate) 
                                                    && x.AuditCreateDate <= Convert.ToDateTime(filters.StartDate).AddDays(1));
        }

        if (filters.Sort is null) filters.Sort = "CategoryId";

        response.TotalRecords = await categories.CountAsync();
        response.Items = await Ordering(filters, categories, !filters.Download).ToListAsync();

        return response;
    }

    public async Task<Category> GetById(int id)   
    {
        var category = await _context.Categories
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.CategoryId.Equals(id));

        return category ?? new Category();
    }

    public async Task<bool> Update(Category category)
    {
        category.AuditUpdateUser = 1;
        category.AuditUpdateDate = DateTime.Now;

        _context.Update(category);
        _context.Entry(category).Property(x => x.AuditCreateUser).IsModified = false;
        _context.Entry(category).Property(x => x.AuditCreateDate).IsModified = false;

        var recordsAffected = await _context.SaveChangesAsync();

        return recordsAffected > 0;
    }
}
