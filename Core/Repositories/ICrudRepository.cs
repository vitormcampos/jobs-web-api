namespace Jobs.Core.Repositories;

public interface ICrudRepository<Model, Id>
{
    bool ExistsById(Id id);
    Model? FindById(Id id);
    ICollection<Model> FindAll();
    Model Create(Model model);
    Model Update(Model model);
    void DeleteById(Id id);
}