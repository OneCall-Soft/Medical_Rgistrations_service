using DBAccess.AppContext;
using DBAccess.IRepos;
using DBAccess.Models;
using DBAccess.Utility;
using DBAccess.ViewModels;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace DBAccess.IRepositoryImplementations
{
    public class GallaryImp : IGallary
    {
        private readonly SSOContext _sSOContext;
        private readonly IHostingEnvironment _HostinEnv;
        private ApiResponse response;


        public GallaryImp(IHostingEnvironment hostingEnvironment, SSOContext context)
        {
            _HostinEnv = hostingEnvironment;
            _sSOContext = context;
        }

        public ApiResponse GetGallaryPhotos(Guid GroupId)
        {
            response = new ApiResponse();
            try
            {

                var list = _sSOContext.Gallary.Where(x => x.GroupId == GroupId).Select(x => new GallaryViewModel
                {
                    order = x.order,
                    GroupId = x.GroupId,
                    Active = x.Active,
                    CreatedOn = x.CreatedOn,
                    FileName = x.FileName,
                    GroupName = x.GroupName,
                    Id = x.Id
                }).FirstOrDefault();

                response.Data = JsonConvert.SerializeObject(list);
                response.Success = true;

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }
            return response;
        }

        public ApiResponse SetGallaryPhotos(GallaryViewModel gallary)
        {

            response = new ApiResponse();
            try
            {

                _sSOContext.Gallary.Add(new Gallary
                {
                    Active = gallary.Active,
                    CreatedOn = DateTime.Now.Date,
                    FileName = gallary.FileName,
                    GroupId = gallary.GroupId,
                    GroupName = gallary.GroupName,
                    order = gallary.order,
                });

                var template = _sSOContext.Templetes.Where(x => x.Active == true && x.Page == gallary.GroupName.Trim().ToLower()).FirstOrDefault();
                if (template != null)
                {
                    template.GallaryGroupId = gallary.GroupId;
                }
                _sSOContext.SaveChanges();

                response.Success = true;
                response.Message = Constants.Messages.PHOTOADDED;
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

