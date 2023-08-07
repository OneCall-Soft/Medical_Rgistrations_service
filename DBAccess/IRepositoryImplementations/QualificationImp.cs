using DBAccess.AppContext;
using DBAccess.IRepos;
using DBAccess.Models;
using DBAccess.Utility;
using DBAccess.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Medical_Rgistrations.IRepos
{
    public class QualificationImp : IQualification
    {
        private readonly SSOContext _sSOContext;
        private readonly IHostingEnvironment _HostinEnv;
        private readonly Logger<QualificationImp> _Logger;
        private ApiResponse response;

        public QualificationImp(IHostingEnvironment hostingEnvironment, SSOContext context )
        {
            _HostinEnv = hostingEnvironment;
            _sSOContext = context;
            //_Logger = logger;
        }

        public bool Add(Qualification model)
        {
            var res = false;
            try
            {
                _sSOContext.Qualification.Add(model);
                _sSOContext.SaveChanges();
                res = true;
            }
            catch (Exception e)
            {
                _Logger.LogError(e.Message);
            }

            return res;
        }

        public IEnumerable<Qualification> Get()
        {
            var list = new List<Qualification> ();
            try
            {
                list.AddRange(_sSOContext.Qualification.ToList());
            }
            catch (Exception e)
            {
                _Logger.LogError(e.Message);
            }

            return list;
        }

        public Qualification GetById(int? id)
        {
            var record = new Qualification();
            try
            {
                record = _sSOContext.Qualification.Find(id);
            }
            catch (Exception e)
            {
                _Logger.LogError(e.Message);
            }

            return record;
        }

        public ApiResponse GetGenders()
        {
            List<MyGender> myGenders = new List<MyGender>();
            response = new ApiResponse();
            try
            {
                myGenders = _sSOContext.Gender.Select(x=>new MyGender {Id=x.Id,Value=x.Value }).ToList();

                response.Data=JsonConvert.SerializeObject(myGenders);
                response.Success = true;

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Data = e.Message;
            }
            return response;
        }

        public bool RemoveById(int? id)
        {
            var res = false;
            try
            {
                var entityRecord = _sSOContext.Qualification.Find(id);

                var d = _sSOContext.Qualification.Remove(entityRecord);
                if (d != null)
                {
                    res = true;
                }
            }
            catch (Exception e)
            {
                _Logger.LogError(e.Message);
            }

            return res;
        }
    }
}
