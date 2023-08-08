using DBAccess.Models;
using DBAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DashboardLink = DBAccess.ViewModels.DashboardLink;

namespace Medical_Rgistrations.IRepos
{
    public interface IAdminTemplates
    {
        ApiResponse GetTemplate(string page);        
        ApiResponse SetTemplate(MyHtmlContent htmlContent);
        ApiResponse UpdateTemplate(MyHtmlContent htmlContent);
        ApiResponse GetActiveTemplate(string page);
        ApiResponse SetLinkTemplate(DashboardLink dashboardLink);
        ApiResponse GetLinkTemplates(string Linkposition);
        ApiResponse GetDashboardLink();

    }
}
