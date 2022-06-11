using System.Collections.Generic;

namespace SalesTest.Interfaces.Base.Repository
{
    /// <summary>Repository of typed entity</summary>
    /// <typeparam name="T">Type of Entity</typeparam>
    public interface IRepository<T>
    {
        /// <summary>Add item in repository</summary>
        /// <param name="item">Item to add</param>
        /// <returns>Item's id</returns>
        int Add(T item);

        /// <summary>Update item in repository</summary>
        /// <param name="id">Updated item id</param>
        /// <param name="updatedItem">Updated item</param>
        /// <returns>Item's id</returns>
        int Update(int id, T updatedItem);

        /// <summary>Get all items from repository</summary>
        /// <returns>List of items</returns>
        List<T> GetAll();

        /// <summary>Get item from repository by id</summary>
        /// <param name="id">Id of item</param>
        /// <returns>Getted item</returns>
        T GetById(int id);

        /// <summary>Delete item from repository by id</summary>
        /// <param name="id">Id of item</param>
        /// <returns>Deleted item</returns>
        T Delete(int id);

        /// <summary>Save changes in repository</summary>
        void Save();

        /// <summary>Check is repository has item with this id</summary>
        /// <param name="id">Id of item</param>
        /// <returns>True if the item exsists</returns>
        bool Exists(int id);
    }
}