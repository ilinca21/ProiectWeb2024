using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Solution.BusinessLogic.DBModel.Seed;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.User;
using Solution.Domain.Enums;
using Solution.Helpers;
using Solution.Domain.Entities.Case;
using Solution.Domain.Entities.Testimonial;

namespace Solution.BusinessLogic.Core
{
    public class AdminApi
    {
        public CaseResp AddCase(NewCaseData data)
        {
            var newCase = Mapper.Map<CaseDbTable>(data);
            var response = new CaseResp();

            try
            {
                using (var db = new CaseContext())
                {
                    db.Cases.Add(newCase);
                    db.SaveChanges();
                }

                response.StatusMessage = "Case added successfully!";
                response.Status = true;
                response.CaseId = newCase.Id;
            }
            catch
            {
                response.StatusMessage = "An error occured while adding case";
                response.Status = false;
                response.CaseId = 0;
            }

            return response;
        }
        public CaseResp ReturnEditedCase(CaseEditData existingCase)
        {
            var response = new CaseResp();
            using (var db = new CaseContext())
            {
                try
                {
                    var caseToEdit = db.Cases.Find(existingCase.Id);
                    if (caseToEdit != null)
                    {
                        caseToEdit.FullName = existingCase.FullName;
                        caseToEdit.Age = existingCase.Age;
                        caseToEdit.City = existingCase.City;
                        caseToEdit.Address = existingCase.Address;
                        caseToEdit.Email = existingCase.Email;
                        caseToEdit.PhoneNumber = existingCase.PhoneNumber;
                        caseToEdit.Title = existingCase.Title;
                        caseToEdit.TotalSum = existingCase.TotalSum;
                        caseToEdit.CollectedSum = existingCase.CollectedSum;
                        caseToEdit.Description = existingCase.Description;
                        caseToEdit.Status = existingCase.Status;

                        if (existingCase.ImagePath != null)
                        {
                            caseToEdit.ImagePath = existingCase.ImagePath;
                        }

                        db.SaveChanges();
                        response.Status = true;
                        response.CaseId = caseToEdit.Id;
                        response.StatusMessage = "Your case was edited successfully!";
                    }
                    else
                    {
                        response.CaseId = 0;
                        response.Status = false;
                        response.StatusMessage = "Case not found!";
                    }
                }
                catch (Exception)
                {
                    response.CaseId = 0;
                    response.Status = false;
                    response.StatusMessage = "An error occurred!";
                }
            }

            return response;
        }
        public IEnumerable<CaseMinimal> ReturnCasesByKey(string key)
        {
            List<CaseMinimal> list = new List<CaseMinimal>();
            using (var db = new CaseContext())
            {
                var results = db.Cases.Where(item => item.Title.Contains(key) && item.Status == "Approved"
                                                     || item.Description.Contains(key)
                );

                foreach (var item in results)
                {
                    var caseMinimal = Mapper.Map<CaseMinimal>(item);
                    list.Add(caseMinimal);
                }
            }

            return list.ToList();
        }
        public IEnumerable<CaseMinimal> ReturnCases()
        {
            List<CaseMinimal> list = new List<CaseMinimal>();
            var dateTimeNow = DateTime.Now;

            using (var db = new CaseContext())
            {
                var results = db.Cases.Where(a => a.Status == "Approved");

                foreach (var item in results)
                {
                    var caseMinimal = Mapper.Map<CaseMinimal>(item);
                    list.Add(caseMinimal);
                }
            }

            return list.ToList();
        }
        public IEnumerable<CaseMinimal> ReturnUrgentCases()
        {
            List<CaseMinimal> list = new List<CaseMinimal>();
            var todayPlus5Days = DateTime.Today.AddDays(5);

            using (var db = new CaseContext())
            {
                var results = db.Cases.Where(a => a.EndDate <= todayPlus5Days);

                foreach (var item in results)
                {
                    var caseMinimal = Mapper.Map<CaseMinimal>(item);
                    list.Add(caseMinimal);
                }
            }

            return list.ToList();
        }

        public IEnumerable<CaseMinimal> ReturnFinishedCases()
        {
            List<CaseMinimal> list = new List<CaseMinimal>();

            using (var db = new CaseContext())
            {
                var results = db.Cases.Where(a => a.CollectedSum == a.TotalSum);

                foreach (var item in results)
                {
                    var caseMinimal = Mapper.Map<CaseMinimal>(item);
                    list.Add(caseMinimal);
                }
            }

            return list.ToList();
        }

        public TestimonialResp AddTestimonial(NewTestimonialData data)
        {
            var newTestimonial = Mapper.Map<TestimonialDbTable>(data);
            var response = new TestimonialResp();

            try
            {
                using (var db = new TestimonialContext())
                {
                    db.Testimonials.Add(newTestimonial);
                    db.SaveChanges();
                }

                response.StatusMessage = "Testimonial added successfully!";
                response.Status = true;
            }
            catch
            {
                response.StatusMessage = "An error occured while adding testimonial";
                response.Status = false;
            }
            return response;
        }

    public List<UserMinimal> RGetAllUsers()
        {
            using (var dbContext = new UserContext())
            {
                var users = dbContext.Users.Select(u => new UserMinimal
                {
                    UserName = u.UserName,
                    Email = u.Email,
                    Id = u.Id,
                    LastIp = u.LastIp,
                    LastLogin = u.LastLogin,
                    Level = u.Level,
                }).ToList();

                return users;
            }
        }

        public UserMinimal RGetUserById(int Id)
        {
            using (var dbContext = new UserContext())
            {
                var user = dbContext.Users.FirstOrDefault(us => us.Id == Id);
                if (user == null) return null;
                return new UserMinimal
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Level = user.Level,
                    Id = user.Id,
                };
            }
        }

        public void REditUser(int Id, UserMinimal userModel)
        {
            using (var dbContext = new UserContext())
            {
                var user = dbContext.Users.FirstOrDefault(us => us.Id == Id);
                if (user == null) return;

                user.UserName = userModel.UserName;
                user.Email = userModel.Email;
                user.Level = userModel.Level;

                dbContext.SaveChanges();
            }
        }
        public ULoginResp AddNewUserAction(ANewUser data)
        {
            using (var db = new UserContext())
            {
                // Check if passwords match first
                if (data.Password != data.ConfirmPassword)
                    return new ULoginResp { Status = false, Message = "Passwords do not match." };

                // Check for existing user
                bool existingUser = db.Users.Any(u => u.UserName == data.Credential);
                if (existingUser)
                {
                    return new ULoginResp { Status = false, Message = "A user already exists with this username." };
                }

                // Create new user
                var newUser = new UDBTable
                {
                    UserName = data.Credential,
                    Email = data.Email,
                    Password = LoginHelper.HashGen(data.Password),
                    LastIp = "",
                    PhoneNumber = data.PhoneNumber,
                    Country = data.Country,
                    LastLogin = DateTime.Now,
                    Level = UserRole.User
                };

                // Add new user to database and save changes
                db.Users.Add(newUser);
                try
                {
                    db.SaveChanges();
                    return new ULoginResp { Status = true, Message = "User registered successfully" };
                }
                catch (Exception)
                {
                    // Log the exception
                    // Log.Error("Failed to save new user", ex);
                    return new ULoginResp { Status = false, Message = "Error registering user." };
                }
            }
        }
    }
}