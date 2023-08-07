using DBAccess.Models;
using DBAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Rgistrations.IRepos
{
    public interface ICompany
    {
        ApiResponse GetCompany();
        ApiResponse PutCompany(CompanyDetails company);
    }
}
