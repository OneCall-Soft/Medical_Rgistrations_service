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
    public class RegisterationImp : IRegisterRepo
    {
        private readonly SSOContext _sSOContext;
        private readonly IHostingEnvironment _HostinEnv;
        private ApiResponse apiResponse { get; set; }
        //private readonly Logger<RegisterationImp> _Logger;

        public RegisterationImp(IHostingEnvironment hostingEnvironment, SSOContext context)
        {
            _HostinEnv = hostingEnvironment;
            _sSOContext = context;
            _sSOContext.Registrations.Include(x => x.Qualification).ToList();
            _sSOContext.Registrations.Include(x => x.Genders).ToList();
            //_Logger = logger;
        }


        public ApiResponse GetRegistrations()
        {
            var list = new List<RegisterViewModels>();
            try
            {


                apiResponse = new ApiResponse();
                list.AddRange(_sSOContext.Registrations.Select(ent =>
                     new RegisterViewModels
                     {
                         Name = ent.Name,
                         Email = ent.Email,
                         Nationality = ent.Nationality,
                         Pincode = ent.Pincode,
                         Mobile = ent.Mobile,
                         Address = ent.Address,
                         CompletePart = ent.CompletePart,
                         ReadTermsCondition = ent.ReadTermsCondition,
                         RCPCode = ent.RCPCode,
                         DOB = ent.DOB,
                         InstituteName = ent.InstituteName,
                         RegistrationId = ent.RegistrationId,
                         RferenceNbr = ent.RferenceNbr,
                         Year = ent.Year,
                         ModifiedOn = ent.ModifiedOn,
                         CreatedOn = ent.CreatedOn,
                         Genders=new MyGender {Id=ent.Genders.Id,Value=ent.Genders.Value},
                         Qualification=new MyQualification {Id=ent.Qualification.Id,Value=ent.Qualification.Value},
                         GenderId = ent.GenderId,
                         QualificationId = ent.QualificationId,
                     }).ToList());

                apiResponse.Data = JsonConvert.SerializeObject(list);
                apiResponse.Success = true;

            }
            catch (Exception e)
            {
                apiResponse.Success = false;
                apiResponse.Message = e.Message;
            }
            return apiResponse;
        }

        ApiResponse IRegisterRepo.GetRegistrationById(Guid id)
        {
            apiResponse = new ApiResponse { };
            try
            {
                var ent = _sSOContext.Registrations.Find(id);



                if (ent != null)
                {
                    var entity = new RegisterViewModels
                    {
                        Name = ent.Name,
                        GenderId=ent.GenderId,
                        QualificationId=ent.QualificationId,
                        Email = ent.Email,
                        Nationality = ent.Nationality,
                        Pincode = ent.Pincode,
                        Mobile = ent.Mobile,
                        Address = ent.Address,
                        CompletePart = ent.CompletePart,
                        ReadTermsCondition = ent.ReadTermsCondition,
                        RCPCode = ent.RCPCode,
                        DOB = ent.DOB,
                        InstituteName = ent.InstituteName,
                        RegistrationId = ent.RegistrationId,
                        RferenceNbr = ent.RferenceNbr,
                        Year = ent.Year,
                        ModifiedOn = ent.ModifiedOn,
                        CreatedOn = ent.CreatedOn,
                        Genders = new MyGender { Id = ent.Genders.Id, Value = ent.Genders.Value },
                        Qualification = new MyQualification { Id = ent.Qualification.Id, Value = ent.Qualification.Value }
                    };
                    apiResponse.Data = JsonConvert.SerializeObject(entity);
                    apiResponse.Success = true;
                }

            }
            catch (Exception e)
            {
                apiResponse.Success = false;
                apiResponse.Message = e.Message;
            }
            //return data;
            return apiResponse;

        }



        ApiResponse IRegisterRepo.NewRegistration(RegisterViewModels model)
        {
            apiResponse = new ApiResponse { };

            try
            {
                SSORegistrations modelToUpdate = new SSORegistrations();

                modelToUpdate = new SSORegistrations
                {
                    Address = model.Address,
                    GenderId = Convert.ToInt32(model.GenderId),
                    Email = model.Email,
                    InstituteName = model.InstituteName,
                    Year = model.Year,
                    Pincode = model.Pincode,
                    Nationality = model.Nationality,
                    DOB = model.DOB,
                    CreatedOn = DateTime.Now.Date,
                    Name = model.Name,
                    Mobile = model.Mobile,
                    QualificationId = Convert.ToInt32(model.QualificationId),
                    CompletePart = model.CompletePart,
                    ReadTermsCondition = model.ReadTermsCondition,
                    RCPCode = model.RCPCode,                   
                };

                modelToUpdate.RferenceNbr = Utils.RandomString(10);

                var ent = _sSOContext.Registrations.Add(modelToUpdate).Entity;
                _sSOContext.SaveChanges();

                if (ent != null)
                {
                    var entity = new RegisterViewModels
                    {
                        Name = ent.Name,
                        Email = ent.Email,
                        Nationality = ent.Nationality,
                        Pincode = ent.Pincode,
                        Mobile = ent.Mobile,
                        Address = ent.Address,
                        CompletePart = ent.CompletePart,
                        ReadTermsCondition = ent.ReadTermsCondition,
                        RCPCode = ent.RCPCode,
                        DOB = ent.DOB,
                        InstituteName = ent.InstituteName,
                        RegistrationId = ent.RegistrationId,
                        RferenceNbr = ent.RferenceNbr,
                        Year = ent.Year,
                        ModifiedOn = ent.ModifiedOn,
                        CreatedOn = ent.CreatedOn,
                        Genders = new MyGender { Id = ent.Genders.Id, Value = ent.Genders.Value },
                        Qualification = new MyQualification { Id = ent.Qualification.Id, Value = ent.Qualification.Value },
                        GenderId = ent.GenderId,
                        QualificationId = ent.QualificationId,
                    };
                    apiResponse.Data = JsonConvert.SerializeObject(entity);
                }

                apiResponse.Success = true;


            }
            catch (Exception e)
            {
                apiResponse.Message = e.Message;
                apiResponse.Success = false;
            }

            return apiResponse;
        }

    }
}
