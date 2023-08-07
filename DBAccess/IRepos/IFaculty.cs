using DBAccess.Models;
using DBAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Rgistrations.IRepos
{
    public interface IFaculty
    {
        ApiResponse GetAllFaculties();
        ApiResponse RemoveFacultyById(Guid id);
        ApiResponse GetFacultyById(Guid id);
        ApiResponse SetFaculty(MyFaculty myFaculty);
        ApiResponse UpdateFaculty(MyFaculty faculty);
        ApiResponse UpdateFacultyById(TemplateActiveUpdate massUpdate);

    }
}
