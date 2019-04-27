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
    /// CarService için özet açıklama
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class CarService : System.Web.Services.WebService
    {

        [WebMethod]
        public Response<Car> FetchAllCarsByCompanyId(int CompanyID)
        {
            Response<Car> res = new Response<Car>();
            try
            {
                using (var carBusiness = new CarBusiness())
                {
                     res = carBusiness.FetchAllCarsByCompany(CompanyID);
                }
            }
            catch(Exception ex)
            {
                res.Message = "An error occured in CarService.FetchAllCarsByCompanyId \n" + ex.Message;
                res.isSuccess = false;
            }
            return res;
            
        }

        [WebMethod]
        public Response<Car> AddNewCar(Car entity)
        {
            Response<Car> res = new Response<Car>();
            try
            {
                using (var carBusiness = new CarBusiness())
                {
                    res = carBusiness.AddNewCar(entity);
                }
            }
            catch(Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in CarService.AddNewCar \n" + ex.Message;
            }
            return res;
        }

        [WebMethod]
        public Response<Car> FetchOneCarById(int CarID)
        {
            Response<Car> res = new Response<Car>();

            try
            {
                using (var carBusiness = new CarBusiness())
                {
                    res = carBusiness.FetchCarById(CarID);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in CarService.FetchOneCarById \n" + ex. Message;
            }
            return res;
        }

        [WebMethod]
        public Response<Car> DeleteCarById(int CarID)
        {
            Response<Car> res = new Response<Car>();
            try
            {
                using (var carBusiness = new CarBusiness())
                {
                    res = carBusiness.DeleteCarById(CarID);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in CarService.DeleteCarById\n"+ex.Message;
            }
            return res;
        }

        [WebMethod]
        public Response<Car> ActivateCarById(int CarID)
        {
            Response<Car> res = new Response<Car>();
            try
            {
                using (var carBusiness = new CarBusiness())
                {
                    res = carBusiness.ActivateCarById(CarID);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in CarService.ActivateCarById\n"+ex.Message;
            }
            return res;
        }

        [WebMethod]
        public Response<Car> UpdateCar(Car entity)
        {
            Response<Car> res = new Response<Car>();

            try
            {
                using(var carBusiness = new CarBusiness())
                {
                    res = carBusiness.UpdateCar(entity);
                }
            }
            catch (Exception ex)
            {
                res.Message = "An error occured in CarService.UpdateCar\n" + ex.Message;
            }
            return res;
        }

    }
}
