using GoParkService.Repository;
using System.Linq.Expressions;

namespace GoParkService.BLL.Services;
/// <summary>
/// Crud services interface.
/// </summary>
/// <typeparam name="T">Generic Parameter.</typeparam>
public interface ICrudService<T>
{
    /// <summary>
    /// Method declration of ICrudService to add the Object.
    /// </summary>
    /// <param name="entity">General object to be add.</param>
    /// <returns>General object after adding.</returns>
    public Task<T> Add(T entity);

    /// <summary>
    /// For adding list.
    /// </summary>
    /// <param name="entities">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public Task Add(IEnumerable<T> entities);

    /// <summary>
    /// For adding list.
    /// </summary>
    /// <param name="entities">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public Task Delete(IEnumerable<T> entities);

    /// <summary>
    /// Method declration of ICrudService to update the Object.
    /// </summary>
    /// <param name="entity">General object to be update.</param>
    /// <returns>General object after updating.</returns>
    public Task<T> Update(T entity);

    /// <summary>
    /// For updating list.
    /// </summary>
    /// <param name="entities">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public Task Update(IEnumerable<T> entities);

    /// <summary>
    /// Method declration of ICrudService to get the Object.
    /// </summary>
    /// <param name="entity">General object to be get.</param>
    /// <returns>General object after getting.</returns>
    public Task<IEnumerable<T>> Get();

    /// <summary>
    /// Method declration of ICrudService to get single Object.    
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<T> GetSingle(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// For getting.
    /// </summary>
    /// <param name="predicate">Param, check weather.</param>
    /// <returns>Returns result.</returns>
    public Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Method declration of ICrudService to delete the Object.
    /// </summary>
    /// <param name="entity">General object to be delete.</param>
    /// <returns>General object after deleting.</returns>
    public Task<bool> Delete(T entity);
    /// <summary>
    /// Delete Permanantly
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public Task Discard(IEnumerable<T> entities);
    /// <summary>
    ///  Discard parmanantly
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task Discard(T entity);
}
/// <summary>
/// CRUD service class use to manage the crud operations in db.
/// </summary>
/// <typeparam name="T">Object as paramter of any entity.</typeparam>
public class CrudService<T> : ICrudService<T>
{
    private readonly IUnitOfWork _unitOfWork;
    private IRepository<T> _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CrudService{T}"/> class.
    /// </summary>
    /// <param name="repository">Member of CRUD service.</param>
    /// <param name="unitOfWork">Member of CRUD services.</param>
    public CrudService(IRepository<T> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Method of CRUD service to add the record.
    /// </summary>
    /// <param name="entity">Object as paramter to add the entity.</param>
    /// <returns>Entity object after added.</returns>
    public virtual async Task<T> Add(T entity)
    {
        await _repository.Add(entity);
        _unitOfWork.Commit();
        return entity;
    }

    /// <summary>
    /// For adding list.
    /// </summary>
    /// <param name="entities">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public async Task Add(IEnumerable<T> entities)
    {
        await _repository.Add(entities);
        _unitOfWork.Commit();
    }
    /// <summary>
    /// For adding list.
    /// </summary>
    /// <param name="entities">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public async Task Delete(IEnumerable<T> entities)
    {
        await _repository.Delete(entities);
        _unitOfWork.Commit();
    }

    /// <summary>
    /// Method of CRUD service to delete the record.
    /// </summary>
    /// <param name="entity">Object as paramter to delete the entity.</param>
    /// <returns>Entity object after deleted.</returns>
    public virtual async Task<bool> Delete(T entity)
    {
        await _repository.Delete(entity);
        _unitOfWork.Commit();
        return true;
    }

    /// <summary>
    /// Method of CRUD service to get the record.
    /// </summary>
    /// <returns>Entity object after getting.</returns>
    public async Task<IEnumerable<T>> Get()
    {
        return await _repository.Get();
    }

    /// <summary>
    /// Method of CRUD service to get single record.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public async Task<T> GetSingle(Expression<Func<T, bool>> predicate)
    {
        return await _repository.GetSingle(predicate);
    }

    /// <summary>
    /// For getting.
    /// </summary>
    /// <param name="predicate">Param, check weather.</param>
    /// <returns>Returns result.</returns>
    public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
    {
        return await _repository.Get(predicate);
    }

    /// <summary>
    /// Method of CRUD service to update the record.
    /// </summary>
    /// <param name="entity">Object as paramter to update the entity.</param>
    /// <returns>Entity object after update.</returns>
    public virtual async Task<T> Update(T entity)
    {
        await _repository.Update(entity);
        _unitOfWork.Commit();
        return entity;
    }

    /// <summary>
    /// For updating list.
    /// </summary>
    /// <param name="entities">is an entity model.</param>
    /// <returns>Returns result.</returns>
    public async Task Update(IEnumerable<T> entities)
    {
        await _repository.Update(entities);
        _unitOfWork.Commit();
    }
    /// <summary>
    /// Discard single item parmanantly
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>

    public async Task Discard(T entity)
    {
        await _repository.Discard(entity);
        _unitOfWork.Commit();
    }
    /// <summary>
    /// Discard single item parmanantly
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>

    public async Task Discard(IEnumerable<T> entities)
    {
        await _repository.Discard(entities);
        _unitOfWork.Commit();
    }
    
}