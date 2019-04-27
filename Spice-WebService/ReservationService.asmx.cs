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
    /// ReservationService için özet açıklama
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class ReservationService : System.Web.Services.WebService
    {

        [WebMethod]
        public Response<Car> FetchAvailableCarsForResv(int UserID, DateTime startingDate, DateTime endDate)
        {
            Response<Car> res = new Response<Car>();
            try
            {
                using(var resvBusiness = new ReservationBusiness())
                {
                    res = resvBusiness.FetchAvailableCarsForResv(UserID, startingDate, endDate);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in FetchAvailableCarsForResv() func. in Spice-WebService.ReservationService\n" + ex.Message;
            }
            return res;
        }

        [WebMethod]
        public Response<Reservation> FetchAllById(int UserID)
        {
            Response<Reservation> res = new Response<Reservation>();
            try
            {
                using(var resvBusiness = new ReservationBusiness())
                {
                    res = resvBusiness.FetchAllResvById(UserID);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in FetchAllById() in Spice-WebService.ReservationService\n" + ex.Message;
            }
            return res;
        }

        [WebMethod]
        public Response<Reservation> MakeReservation(int CarID, int UserID, DateTime startingDate, DateTime endDate)
        {
            Response<Reservation> res = new Response<Reservation>();
            try
            {
                using(var resvBusiness = new ReservationBusiness())
                {
                    res = resvBusiness.MakeReservation(CarID, UserID, startingDate, endDate);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in MakeReservation() func. in Spice-WebService.ReservationService\n" + ex.Message;
            }
            return res;
        }

        [WebMethod]
        public Response<Reservation> CancelReservation(int ReservationID)
        {
            Response<Reservation> res = new Response<Reservation>();

            try
            {
                using(var resvBusiness = new ReservationBusiness())
                {
                    res = resvBusiness.CancelReservation(ReservationID);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in CancelReservation() func. in Spice-WebService.ReservationService\n" + ex.Message;
            }
            return res;
        }


    }
}
