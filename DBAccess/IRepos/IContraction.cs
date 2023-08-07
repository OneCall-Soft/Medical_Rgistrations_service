using DBAccess.Models;

namespace DBAccess.IRepos
{
    public interface IContraction
    {
        /// <summary>
        /// Add new contraction
        /// </summary>
        /// <param name="model"></param>
        /// <returns>True if added successfully</returns>
        bool Add(Contraction model);
        /// <summary>
        /// Get lists of contractions
        /// </summary>
        /// <returns>list of contractions</returns>
        IEnumerable<Contraction> Get();
        /// <summary>
        /// Get contraction by id
        /// </summary>
        /// <param name="id">contraction id</param>
        /// <returns>specific contraction</returns>
        Contraction GetById(int? id);
        /// <summary>
        /// Remove contraction by Id
        /// </summary>
        /// <param name="id">contraction id</param>
        /// <returns>true if removed </returns>
        bool RemoveById(int? id);
    }
}
