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
    /// RentDetailService için özet açıklama
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class RentDetailService : System.Web.Services.WebService
    {

        [WebMethod]
        public Response<RentDetail> CompleteReservation(int ReservationID)
        {
            Response<RentDetail> res = new Response<RentDetail>();

            try
            {
                using(var rentDetailBusiness = new RentDetailBusiness())
                {
                    res = rentDetailBusiness.CompleteReservation(ReservationID);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in CompleteReservation() func. in Spice-WebService.RentDetailService\n" + ex.Message;
            }
            return res;
        }

        [WebMethod]
        public Response<RentDetail> FetchAllRentDetailById(int UserID)
        {
            Response<RentDetail> res = new Response<RentDetail>();

            try
            {
                using(var rentDetailBusiness = new RentDetailBusiness())
                {
                    res = rentDetailBusiness.FetchAllRentDetailById(UserID);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in FetchAllRentDetailById() func. in Spice-WebService.RentDetailService\n" + ex.Message;
            }
            return res;
        }

        [WebMethod]
        public Response<RentDetail> FetchOneById(int RentDetailID)
        {
            Response<RentDetail> res = new Response<RentDetail>();
            try
            {
                using(var rentDetailBusiness = new RentDetailBusiness())
                {
                    res = rentDetailBusiness.FetchOneById(RentDetailID);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in FetchOneById() func. in Spice-WebService\n" + ex.Message;
            }
            return res;
        }

        [WebMethod]
        public Response<RentDetail> ReturnCarToCompany(int RentDetailID, int KmInfo, int Score)
        {
            Response<RentDetail> res = new Response<RentDetail>();
            try
            {
                using (var rentDetailBusiness = new RentDetailBusiness())
                {
                    res = rentDetailBusiness.ReturnCarToCompany(RentDetailID, KmInfo, Score);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in ReturnCarToCompany() func. in Spice-WebService\n" + ex.Message;
            }
            return res;
        }

    }
}
