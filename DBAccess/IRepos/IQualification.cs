using DBAccess.Models;
using DBAccess.ViewModels;

namespace DBAccess.IRepos
{
    public interface IQualification
    {
        /// <summary>
        /// Add new Qualification
        /// </summary>
        /// <param name="model"></param>
        /// <returns>True if added successfully</returns>
        bool Add(Qualification model);

        ApiResponse GetGenders();
        /// <summary>
        /// Get lists of contractions
        /// </summary>
        /// <returns>list of Qualification</returns>
        IEnumerable<Qualification> Get();
        /// <summary>
        /// Get Qualification by id
        /// </summary>
        /// <param name="id">Qualification id</param>
        /// <returns>specific Qualification</returns>
        Qualification GetById(int? id);
        /// <summary>
        /// Remove Qualification by Id
        /// </summary>
        /// <param name="id">Qualification id</param>
        /// <returns>true if removed </returns>
        bool RemoveById(int? id);
    }
}
