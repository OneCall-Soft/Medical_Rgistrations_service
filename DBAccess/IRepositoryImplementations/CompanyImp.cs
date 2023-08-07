using DBAccess.AppContext;
using DBAccess.Models;
using DBAccess.Utility;
using DBAccess.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Medical_Rgistrations.IRepos
{
    public class CompanyImp : ICompany
    {
        private readonly SSOContext _sSOContext;
        private readonly IHostingEnvironment _HostinEnv;
        private ApiResponse response;

        //private readonly Logger<RegisterationImp> _Logger;

        public CompanyImp(IHostingEnvironment hostingEnvironment, SSOContext context)
        {
            _HostinEnv = hostingEnvironment;
            _sSOContext = context;
            _sSOContext.Registrations.Include(x => x.Qualification).ToList();
            _sSOContext.Registrations.Include(x => x.Genders).ToList();
            //_Logger = logger;
        }

        public ApiResponse GetCompany()
        {
            response = new ApiResponse();

            CompanyDetails companyDetails = new CompanyDetails();
            try
            {
                var company = _sSOContext.Company.FirstOrDefault();

                companyDetails.Address = company.Address;
                companyDetails.Id = company.CompId;
                companyDetails.Name = company.Name;
                companyDetails.Email = company.Email;

                response.Data = JsonConvert.SerializeObject(companyDetails);
                response.Success = true;
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success =false;
                return response;
            }
        }

        public ApiResponse PutCompany(CompanyDetails company)
        {
            response = new ApiResponse();

            CompanyInfo companyDetails = new CompanyInfo();
            try
            {
                companyDetails.Address = company.Address;
                companyDetails.CompId = Guid.NewGuid();
                companyDetails.Name = company.Name;
                companyDetails.Email = company.Email;
                companyDetails.CreatedOn = DateTime.Now.Date.ToShortDateString();


                var entity = _sSOContext.Company.Add(companyDetails);
                _sSOContext.SaveChanges();

                if (entity != null)
                {
                    response.Data = JsonConvert.SerializeObject(true);
                    response.Success = true;
                }

                return response;

            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                return response;
            }
        }

    }
}
