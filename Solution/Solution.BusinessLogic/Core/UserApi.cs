using AutoMapper;
using Solution.BusinessLogic.DBModel.Seed;
using Solution.Domain.Entities.DonatorType;
using Solution.Domain.Entities.Responce;
using Solution.Domain.Entities.Session;
using Solution.Domain.Entities.User;
using Solution.Domain.Enums;
using Solution.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BusinessLogic.Core
{ 
 public class UserApi
{
    public ULoginResp RLoginUpService(ULoginData data)
    {
        // var validate = new EmailAddressAttribute();
        //if (!validate.IsValid(data.Credential))
        // {
        //     return new ULoginResp { Status = false, Message = "Invalid Email Address" };
        // }

        UDBTable user;
        using (var db = new UserContext())
        {
            // Find user by username/email. Do not hash password here.
            user = db.Users.FirstOrDefault(us => us.UserName == data.Credential);
        }
        // If user is found, verify the password.
        if (user == null)
            return new ULoginResp { Status = false, Message = "The Username or Password is Incorrect" };
        // Assuming HashGen can take a salt and you store salt with each user.
        // var hashedInputPassword = LoginHelper.HashGen(data.Password);
        //if (user.Password == data.Password)
        // {
        // Update user's last login details
        // user.LastIp = data.LoginIp;
        // user.LastLogin = data.LoginDateTime;
        // db.Entry(user).State = EntityState.Modified;
        //db.SaveChanges();
        // using (var todo = new UserContext())
        // {
        // user.LastIp = data.LoginIp;
        // user.LastLogin = data.LoginDateTime;
        // todo.Entry(user).State = EntityState.Modified;
        // todo.SaveChanges();

        //}
        // Authentication successful
        // }


        // Authentication failed
        var pass = LoginHelper.HashGen(data.Password);
        if (user != null && user.Password == pass)
        {
            using (var todo = new UserContext())
            {
                user.LastIp = data.LoginIp;
                user.LastLogin = data.LoginDateTime;
                todo.Entry(user).State = EntityState.Modified;
            }
            if (user.Level == UserRole.Admin)
                return new ULoginResp { Status = true, Message = "Admin" };
            else
                return new ULoginResp { Status = true, Message = "User" };
        }
        return new ULoginResp { Status = false };
    }

    public ULoginResp RRegisterNewUserAction(URegisterData data)
    {
        using (var db = new UserContext())
        {
            bool existingUser = db.Users.Any(u => u.UserName == data.Credential);

            if (existingUser)
            {
                return new ULoginResp { Status = false, Message = "A user exist" };
            }
            var newUser = new UDBTable
            {
                UserName = data.Credential,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
                Country = data.Country,
                Password = LoginHelper.HashGen(data.Password),
                LastIp = data.LoginIp,
                LastLogin = DateTime.Now,
                Level = UserRole.User
            };
            if (data.Password != data.ConfirmPassword)
                return new ULoginResp { Status = false, Message = "Wrong password" };
            db.Users.Add(newUser);
            db.SaveChanges();
            return new ULoginResp { Status = true, Message = "User registered successfully" };
        }
    }

    public DonatorTypeDetail GetDonatorTypeUser(int id)
    {
        return new DonatorTypeDetail();
    }

    public System.Web.HttpCookie Cookie(string credential)
    {
        var apiCookie = new System.Web.HttpCookie("X-KEY")
        {
            Value = CookieGenerator.Create(credential)
        };
        using (var db = new SessionContext())
        {
            Session curent;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(credential))
            {
                curent = (from e in db.Sessions where e.UserName == credential select e).FirstOrDefault();
            }
            else
            {
                curent = (from e in db.Sessions where e.UserName == credential select e).FirstOrDefault();
            }
            if (curent != null)
            {
                curent.CookieString = apiCookie.Value;
                curent.ExpireTime = DateTime.Now.AddMinutes(60);
                using (var todo = new SessionContext())
                {
                    todo.Entry(curent).State = EntityState.Modified;
                    todo.SaveChanges();
                }
            }
            else
            {
                db.Sessions.Add(new Session
                {
                    UserName = credential,
                    CookieString = apiCookie.Value,
                    ExpireTime = DateTime.Now.AddMinutes(60)
                });
                db.SaveChanges();
            }
        }
        return apiCookie;
    }
    public UserMinimal UserCookie(string cookie)
    {
        Session session;
        UDBTable curentUser;

        using (var db = new SessionContext())
        {
            session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
        }

        if (session == null) return null;
        using (var db = new UserContext())
        {
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(session.UserName))
            {
                curentUser = db.Users.FirstOrDefault(u => u.Email == session.UserName);
            }
            else
            {
                curentUser = db.Users.FirstOrDefault(u => u.UserName == session.UserName);
            }
        }

        if (curentUser == null) return null;
        var userMinimal = Mapper.Map<UserMinimal>(curentUser);

        return userMinimal;
    }
        public UserEditData ReturnUserById(int userId)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.Find(userId);
                if (user != null)
                {
                    var foundUser = Mapper.Map<UserEditData>(user);
                    return foundUser;
                }

                return null;
            }
        }
        public UserResp ReturnEditedProfile(UserEditData existingUser)
        {
            var response = new UserResp();
            using (var db = new UserContext())
            {
                try
                {
                    var userToEdit = db.Users.Find(existingUser.Id);
                    if (userToEdit != null)
                    {
                        userToEdit.UserName = existingUser.UserName;
                        userToEdit.Email = existingUser.Email;
                        userToEdit.PhoneNumber = existingUser.PhoneNumber;
                        userToEdit.Country = existingUser.Country;
                        db.SaveChanges();
                        response.Status = true;
                        response.StatusMessage = "User Profile was edited successfully!";
                    }
                    else
                    {
                        response.Status = false;
                        response.StatusMessage = "User not found!";
                    }
                }
                catch (Exception)
                {
                    response.Status = false;
                    response.StatusMessage = "An error occurred!";
                }
            }

            return response;
        }
    }
}

