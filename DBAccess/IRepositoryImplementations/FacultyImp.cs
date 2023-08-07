using DBAccess.AppContext;
using DBAccess.Models;
using DBAccess.Utility;
using DBAccess.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Medical_Rgistrations.IRepos
{
    public class FacultyImp : IFaculty
    {
        private readonly SSOContext _sSOContext;
        private readonly IHostingEnvironment _HostinEnv;
        private ApiResponse response;


        public FacultyImp(IHostingEnvironment hostingEnvironment, SSOContext context)
        {
            _HostinEnv = hostingEnvironment;
            _sSOContext = context;
        }

        public ApiResponse GetAllFaculties()
        {
            response = new ApiResponse();
            try
            {
                var faculties = _sSOContext.Faculty.ToList();

                response.Success = true;
                response.Data = JsonConvert.SerializeObject(faculties);

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }



        public ApiResponse GetFacultyById(Guid id)
        {
            response = new ApiResponse();
            try
            {
                var faculty = _sSOContext.Faculty.Find(id);

                if (faculty == null)
                {
                    response.Success = false;
                    response.Message = $"Unable to find faculty with id {id}";
                }
                else
                {
                    var myfaculty = new Faculty
                    {
                        Description = faculty.Description,
                        Email = faculty.Email,
                        InstituteName = faculty.InstituteName,
                        Name = faculty.Name,
                        ProfileName = faculty.ProfileName,
                        Active = faculty.Active,
                    };

                    response.Success = true;
                    response.Data = JsonConvert.SerializeObject(faculty);
                    response.Message = "";
                }

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public ApiResponse UpdateFaculty(MyFaculty faculty)
        {
            response = new ApiResponse();
            try
            {
                var toupdate = _sSOContext.Faculty.Find(faculty.FacultyId);

                if (toupdate == null)
                {
                    response.Success = false;
                    response.Message = $"Unable to find faculty with id {faculty.FacultyId}";
                }
                else
                {

                    toupdate.Description = faculty.Description;
                    toupdate.Email = faculty.Email;
                    toupdate.InstituteName = faculty.InstituteName;
                    toupdate.Name = faculty.Name;
                    toupdate.ProfileName = faculty.ProfileName;
                    toupdate.Active = faculty.Active;

                    _sSOContext.Faculty.Attach(toupdate);
                    _sSOContext.SaveChanges();

                    response.Success = true;
                    response.Data = JsonConvert.SerializeObject(true);
                    response.Message = $"Faculty with id = {faculty.FacultyId} is updated";
                }

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public ApiResponse SetFaculty(MyFaculty faculty)
        {
            response = new ApiResponse();
            try
            {
                var myfaculty = new Faculty
                {
                    Description = faculty.Description,
                    Email = faculty.Email,
                    InstituteName = faculty.InstituteName,
                    Name = faculty.Name,
                    ProfileName = faculty.ProfileName,
                    Active = faculty.Active,
                };


                _sSOContext.Faculty.Add(myfaculty);
                _sSOContext.SaveChanges();

                response.Success = true;
                response.Data = JsonConvert.SerializeObject(true);
                response.Message = "Faculty has been added succesfully";

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public ApiResponse RemoveFacultyById(Guid id)
        {
            response = new ApiResponse();
            try
            {
                var faculty = _sSOContext.Faculty.Find(id);

                if (faculty == null)
                {
                    response.Success = false;
                    response.Message = $"Unable to find faculty with id {id}";
                }
                else
                {

                    var removedFaculty = _sSOContext.Faculty.Remove(faculty);

                    if (removedFaculty != null)
                    {
                        _sSOContext.SaveChanges();
                        response.Success = true;
                        response.Data = JsonConvert.SerializeObject(true);
                        response.Message = "Faculty deleted successfully";
                    }
                }

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public ApiResponse UpdateFacultyById(TemplateActiveUpdate massUpdate)
        {
            response = new ApiResponse();
            try
            {
                var faculty = _sSOContext.Faculty.Find(massUpdate.id);

                if (faculty == null)
                {
                    response.Success = false;
                    response.Message = $"Unable to find the faculty with id {massUpdate.id}";
                }
                else
                {

                    faculty.Active = massUpdate.active;

                    _sSOContext.SaveChanges();
                    response.Success = true;
                    response.Data = JsonConvert.SerializeObject(true);
                    response.Message = "Faculty updated successfully";
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
