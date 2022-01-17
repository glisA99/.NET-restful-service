namespace EPOSProject.Services;

public interface IService<T> {

    ICollection<T> GetAll();
    T? GetByID(int id);
    void Delete(int id);
    T Create(T t);

}