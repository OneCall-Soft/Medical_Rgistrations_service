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
using DashboardLink = DBAccess.ViewModels.DashboardLink;
using DBDashboardLink = DBAccess.Models.DashboardLink;
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

                if (masterList.Count > 0)
                {
                    contactTemplates.AddRange(masterList.Select(x => new MyHtmlContent
                    {
                        Active = x.Active,
                        HtmlData = x.HtmlContent,
                        Id = x.Id,
                        TemplateName = x.TemplateName,
                        //GallaryGroup = x.GallaryGroupId,
                        Page = x.Page
                    }).ToList());

                    response.Success = true;
                    response.Data = JsonConvert.SerializeObject(contactTemplates);
                }
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
                        var toBeDeactivated = _sSOContext.Templetes.Where(x => x.Active == true && x.Page == htmlContent.Page.Trim().ToLower() && x.Id != master.Id).FirstOrDefault();

                        if (toBeDeactivated != null)
                        {
                            toBeDeactivated.Active = false;
                            //master.GallaryGroupId = toBeDeactivated.GallaryGroupId;

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
                    //htmlData.GallaryGroup = master.GallaryGroupId;
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

        public ApiResponse SetLinkTemplate(DashboardLink dashboardLink)
        {
            response = new ApiResponse();
            try
            {
                var dashboard = new DBDashboardLink
                {
                    Active = dashboardLink.Active,
                    Id = Guid.NewGuid(),
                    Link = dashboardLink.Link,
                    LinkName = dashboardLink.LinksName,
                    Position = dashboardLink.Position,
                    TemplateName = dashboardLink.TemplateName
                };

                var master = _sSOContext.DashboardLink.Add(dashboard);

                if (master != null)
                {
                    //Desctivate other template
                    var toBeDeactivated = _sSOContext.DashboardLink.Where(x => x.Id != dashboard.Id
                    && x.Position.ToLower().Trim() == dashboard.Position.ToLower().Trim()).ToList();

                    foreach (var item in toBeDeactivated)
                    {
                        item.Active = false;
                    }
                }

                _sSOContext.SaveChanges();

                response.Message = Constants.Messages.LINKADDED;
                response.Success = true;

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }
            return response;
        }

        public ApiResponse GetLinkTemplates(string Linkposition)
        {
            response = new ApiResponse();
            try
            {
                var DashboardTemlate = new DashboardLink();
                var DashboardTemlateList = new List<DashboardLink>();

                if (!Linkposition.Contains("na"))
                {
                    var masterList = _sSOContext.DashboardLink.Where(x => x.Position == Linkposition.ToLower().Trim()).FirstOrDefault();

                    if (masterList != null)
                    {
                        DashboardTemlate.Active = masterList.Active;
                        DashboardTemlate.TemplateName = masterList.TemplateName;
                        DashboardTemlate.LinksName = masterList.LinkName;
                        DashboardTemlate.Link = masterList.Link;
                        DashboardTemlate.Id = masterList.Id;
                        DashboardTemlate.Position = masterList.Position;
                    }
                    response.Success = true;
                    response.Data = JsonConvert.SerializeObject(DashboardTemlate);
                }
                else
                {
                    var masterList = _sSOContext.DashboardLink.ToList();

                    foreach (var master in masterList)
                    {
                        DashboardTemlateList.Add(new DashboardLink
                        {
                            Id = master.Id,
                            Active = master.Active,
                            TemplateName = master.TemplateName,
                            LinksName = master.LinkName,
                            Link = master.Link,
                            Position = master.Position
                        });
                    }
                    response.Success = true;
                    response.Data = JsonConvert.SerializeObject(DashboardTemlateList);
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public ApiResponse GetDashboardLink()
        {
            response = new ApiResponse();
            try
            {
                var DashboardTemlate = new DashboardLinkView();

                if (_sSOContext.DashboardLink.Count() > 0)
                {
                    var downloadLinks = _sSOContext.DashboardLink.Where(x => x.Active == true && x.Position == "download").FirstOrDefault();
                    var downloadLinksName = _sSOContext.DashboardLink.Where(x => x.Active == true && x.Position == "download").FirstOrDefault();

                    var notifyLinks = _sSOContext.DashboardLink.Where(x => x.Active == true && x.Position == "notification").FirstOrDefault();
                    var notifyLinksName = _sSOContext.DashboardLink.Where(x => x.Active == true && x.Position == "notification").FirstOrDefault();


                    var footer1 = _sSOContext.DashboardLink.Where(x => x.Active == true && x.Position == "quicklink").FirstOrDefault();
                    var footer1Name = _sSOContext.DashboardLink.Where(x => x.Active == true && x.Position == "quicklink").FirstOrDefault();

                    var footer2 = _sSOContext.DashboardLink.Where(x => x.Active == true && x.Position == "importantlink").FirstOrDefault();
                    var footer2Name = _sSOContext.DashboardLink.Where(x => x.Active == true && x.Position == "importantlink").FirstOrDefault();

                    if (downloadLinks != null)
                        for (int i = 0; i < downloadLinks.Link.Split('#').ToList().Count; i++)
                        {
                            DashboardTemlate.DownloadLink.Add(new AncorLink { Name = downloadLinksName.LinkName.Split('#').ToList()[i], link = downloadLinks.Link.Split('#').ToList()[i] });
                        }
                    if (notifyLinks != null)
                        for (int i = 0; i < notifyLinks.Link.Split('#').ToList().Count; i++)
                        {
                            DashboardTemlate.NotificationLink.Add(new AncorLink { Name = notifyLinksName.LinkName.Split('#').ToList()[i], link = notifyLinks.Link.Split('#').ToList()[i] });
                        }

                    if (footer1 != null)
                        for (int i = 0; i < footer1.Link.Split('#').ToList().Count; i++)
                        {
                            DashboardTemlate.FooterLink1.Add(new AncorLink { Name = footer1Name.LinkName.Split('#').ToList()[i], link = footer1.Link.Split('#').ToList()[i] });
                        }

                    if (footer2 != null)
                        for (int i = 0; i < footer1.Link.Split('#').ToList().Count; i++)
                        {
                            DashboardTemlate.FooterLink2.Add(new AncorLink { Name = footer2Name.LinkName.Split('#').ToList()[i], link = footer2.Link.Split('#').ToList()[i] });
                        }


                    response.Success = true;
                    response.Data = JsonConvert.SerializeObject(DashboardTemlate);
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
