using System.Collections.Generic;

namespace SalesTest.Interfaces.Base.Services
{
    /// <summary>Service of typed entity</summary>
    /// <typeparam name="T">Type of Entity</typeparam>
    public interface IService<T>
    {
        /// <summary>Add item</summary>
        /// <param name="item">Item to add</param>
        /// <returns>Item's id</returns>
        int Add(T item);

        /// <summary>Update item</summary>
        /// <param name="id">Updated item id</param>
        /// <param name="updatedItem">Updated item</param>
        /// <returns>Item's id</returns>
        int Update(int id, T updatedItem);

        /// <summary>Get all items</summary>
        /// <returns>List of items</returns>
        List<T> GetAll();

        /// <summary>Get item by id</summary>
        /// <param name="id">Id of item</param>
        /// <returns>Getted item</returns>
        T GetById(int id);

        /// <summary>Delete item by id</summary>
        /// <param name="id">Id of item</param>
        /// <returns>Deleted item</returns>
        T Delete(int id);
    }
}
