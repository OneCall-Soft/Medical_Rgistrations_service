using DBAccess.AppContext;
using DBAccess.Models;
using DBAccess.Utility;
using DBAccess.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Medical_Rgistrations.IRepos
{

    public class AdminTemplateImp : IAdminTemplates
    {
        private readonly SSOContext _sSOContext;
        private readonly IHostingEnvironment _HostinEnv;
        private ApiResponse response;


        public AdminTemplateImp(IHostingEnvironment hostingEnvironment, SSOContext context)
        {
            _HostinEnv = hostingEnvironment;
            _sSOContext = context;
        }

        public ApiResponse GetTemplate(string page)
        {
            response = new ApiResponse();
            try
            {
                var contactTemplates = new List<MyHtmlContent>();

                var masterList = _sSOContext.Templetes.Where(x => x.Page == page.ToLower().Trim()).ToList();

                contactTemplates.AddRange(masterList.Select(x => new MyHtmlContent
                {
                    Active = x.Active,
                    HtmlData = x.HtmlContent,
                    Id = x.Id,
                    TemplateName = x.TemplateName,
                    GallaryGroup = x.GallaryGroupId,
                    Page = x.Page
                }).ToList());


                response.Success = true;
                response.Data = JsonConvert.SerializeObject(contactTemplates);


            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public ApiResponse SetTemplate(MyHtmlContent htmlContent)
        {
            response = new ApiResponse();
            try
            {
                PageTemplete aboutMaster = new PageTemplete
                {
                    CreatedOn = DateTime.Now,
                    HtmlContent = htmlContent.HtmlData,
                    TemplateName = htmlContent.TemplateName,
                    Id = htmlContent.Id,
                    Active = htmlContent.Active,
                    Page = htmlContent.Page,
                };


                var master = _sSOContext.Templetes.Add(aboutMaster);

                if (master != null)
                {
                    //Desctivate other template
                    var toBeDeactivated = _sSOContext.Templetes.Where(x => x.Id != aboutMaster.Id && x.Page == htmlContent.Page.Trim()).ToList();

                    foreach (var item in toBeDeactivated)
                    {
                        item.Active = false;
                    }
                }

                _sSOContext.SaveChanges();

                response.Message = Constants.Messages.TEMPLATEADDED;
                response.Success = true;

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public ApiResponse UpdateTemplate(MyHtmlContent htmlContent)
        {
            response = new ApiResponse();
            try
            {
                var master = _sSOContext.Templetes.Where(x => x.Id == htmlContent.Id && x.Page == htmlContent.Page.Trim()).FirstOrDefault();

                if (master != null)
                {
                    master.HtmlContent = htmlContent.HtmlData;
                    master.Active = htmlContent.Active;
                    master.TemplateName = htmlContent.TemplateName;

                    if (htmlContent.Active)
                    {
                        var toBeDeactivated = _sSOContext.Templetes.Where(x => x.Active == true && x.Page == htmlContent.Page.Trim().ToLower()).FirstOrDefault();

                        if (toBeDeactivated != null)
                        {
                            toBeDeactivated.Active = false;
                            master.GallaryGroupId = toBeDeactivated.GallaryGroupId;

                            _sSOContext.Update(toBeDeactivated);
                        }
                    }

                    _sSOContext.SaveChanges();
                    response.Success = true;
                    response.Data = JsonConvert.SerializeObject(htmlContent);
                    response.Message = Constants.Messages.TEMPLATEUPDATE;
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public ApiResponse GetActiveTemplate(string page)
        {
            response = new ApiResponse();
            try
            {
                var htmlData = new MyHtmlContent();
                var master = _sSOContext.Templetes.Where(x => x.Active == true && x.Page == page.Trim()).FirstOrDefault();

                if (master != null)
                {
                    htmlData.Active = master.Active;
                    htmlData.HtmlData = master.HtmlContent;
                    htmlData.Id = master.Id;
                    htmlData.TemplateName = master.TemplateName;
                    htmlData.GallaryGroup = master.GallaryGroupId;
                    htmlData.Page = master.Page;

                    response.Success = true;
                    response.Data = JsonConvert.SerializeObject(htmlData);
                }

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

    }



}
