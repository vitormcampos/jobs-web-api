using Microsoft.AspNetCore.Identity;

namespace Jobs.Core.Repositories;

public interface ICrudRepository<Model, Id>
{
    Task<bool> ExistsById(Id id);
    Task<Model?> FindById(Id id);
    Task<ICollection<Model>> FindAll();
    Task<Model> Create(Model model);
    Task<Model> Update(Model model);
    Task DeleteById(Id id);
}