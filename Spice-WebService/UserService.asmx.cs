using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SpiceApp.Models.Entities;
using SpiceApp.BusinessLayer.Concretes;

namespace Spice_WebService
{
    /// <summary>
    /// UserService için özet açıklama
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService
    {

        [WebMethod]
        public Response<User> RegisterUser(User entity)
        {
            Response<User> res = new Response<User>();
            try
            {
                using(var userBusiness = new UserBusiness())
                {
                    res = userBusiness.RegisterUser(entity);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in UserService.RegisterUser\n" + ex.Message;
            }
            return res;
        }

        [WebMethod]
        public Response<User> Login(string Username, string Password)
        {
            Response<User> res = new Response<User>();
            try
            {
                using(var userBusiness = new UserBusiness())
                {
                    res = userBusiness.Login(Username, Password);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in UserService.Login\n" + ex.Message;
            }
            return res;
        }

        [WebMethod]
        public Response<User> UpdateInfo(User entity)
        {
            Response<User> res = new Response<User>();
            try
            {
                using(var userBusiness = new UserBusiness())
                {
                    res = userBusiness.UpdateInfo(entity);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in UpdateInfo() func. in Spice-WebService.UserService\n" + ex.Message;
            }
            return res;
        }

        [WebMethod]
        public Response<User> FetchAllCustomers()
        {
            Response<User> res = new Response<User>();
            try
            {
                using (var userBusiness = new UserBusiness())
                {
                    res = userBusiness.FetchAllCustomers();
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in FetchAllCustomers() in Spice-WebService.UserService\n" + ex.Message;
            }
            return res;
        }
        
        [WebMethod]
        public Response<User> ChangePassword(int UserID, string NewPassword)
        {
            Response<User> res = new Response<User>();

            try
            {
                using(var userBusiness = new UserBusiness())
                {
                    res = userBusiness.ChangePassword(UserID, NewPassword);
                }
                
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in ChangePassword() in Spice-WebService.UserService\n" + ex.Message;
            }
            return res;
        }

    }
}
