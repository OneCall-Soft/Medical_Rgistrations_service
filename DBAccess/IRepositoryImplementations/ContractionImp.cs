using DBAccess.AppContext;
using DBAccess.IRepos;
using DBAccess.Models;
using DBAccess.Utility;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Medical_Rgistrations.IRepos
{
    public class ContractionImp : IContraction
    {
        private readonly SSOContext _sSOContext;
        private readonly IHostingEnvironment _HostinEnv;
        private readonly Logger<ContractionImp> _Logger;

        public ContractionImp(IHostingEnvironment hostingEnvironment, SSOContext context)
        {
            _HostinEnv = hostingEnvironment;
            _sSOContext = context;
            //_Logger = logger;
        }

        public bool Add(Contraction model)
        {
            var res = false;
            try
            {
                _sSOContext.Contraction.Add(model);
                _sSOContext.SaveChanges();
                res = true;
            }
            catch (Exception e)
            {
                //_Logger.LogError(e.Message);
            }

            return res;
        }

        public IEnumerable<Contraction> Get()
        {
            var list = new List<Contraction> ();
            try
            {
                list.AddRange(_sSOContext.Contraction.ToList());
            }
            catch (Exception e)
            {
                //_Logger.LogError(e.Message);
            }

            return list;
        }

        public Contraction GetById(int? id)
        {
            var record = new Contraction();
            try
            {
                record = _sSOContext.Contraction.Find(id);
            }
            catch (Exception e)
            {
                //_Logger.LogError(e.Message);
            }

            return record;
        }

        public bool RemoveById(int? id)
        {
            var res = false;
            try
            {
                var entityRecord = _sSOContext.Contraction.Find(id);

                var d = _sSOContext.Contraction.Remove(entityRecord);
                if (d != null)
                {
                    res = true;
                }
            }
            catch (Exception e)
            {
                //_Logger.LogError(e.Message);
            }

            return res;
        }
    }
}
