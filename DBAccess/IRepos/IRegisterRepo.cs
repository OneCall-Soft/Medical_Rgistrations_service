using DBAccess.Models;
using DBAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Rgistrations.IRepos
{
    public interface IRegisterRepo
    {
       ApiResponse NewRegistration(RegisterViewModels model);
       ApiResponse GetRegistrations();
       ApiResponse GetRegistrationById(Guid id);        
    }
}
