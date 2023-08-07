using DBAccess.Models;
using DBAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Rgistrations.IRepos
{
    public interface IAdminTemplates
    {
        ApiResponse GetTemplate(string page);        
        //ApiResponse GetAboutTemplate();
        //ApiResponse GetCourseTemplate();

        ApiResponse SetTemplate(MyHtmlContent htmlContent);
        //ApiResponse SetContactTemplate(MyHtmlContent htmlContent);
        //ApiResponse SetCourseTemplate(MyHtmlContent htmlContent);

        ApiResponse UpdateTemplate(MyHtmlContent htmlContent);
        //ApiResponse UpdateAboutTemplate(MyHtmlContent htmlContent);
        //ApiResponse UpdateCourseTemplate(MyHtmlContent htmlContent);


        //ApiResponse DeleteContactTemplate(Guid id);
        //ApiResponse GetContactTemplateById(Guid id);
        //ApiResponse DeleteAboutTemplate(Guid id);
        //ApiResponse GetAboutTemplateById(Guid id);
        //ApiResponse DeleteCourseTemplate(Guid id);
        //ApiResponse GetCourseTemplateById(Guid id);

        //ApiResponse SetCourseActiveTemplate(TemplateActiveUpdate htmlContent);
        //ApiResponse SetContactActiveTemplate(TemplateActiveUpdate htmlContent);
        //ApiResponse SetAboutActiveTemplate(TemplateActiveUpdate htmlContent);
        ApiResponse GetActiveTemplate(string page);
        //ApiResponse GetContactActiveTemplate();
        //ApiResponse GetAboutActiveTemplate();

    }
}
