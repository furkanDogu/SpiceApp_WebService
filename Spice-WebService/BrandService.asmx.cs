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
    /// BrandService için özet açıklama
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class BrandService : System.Web.Services.WebService
    {

        [WebMethod]
        public Response<Brand> AddBrand(Brand entity)
        {
            Response<Brand> res = new Response<Brand>();
            try
            {
                using(var brandBusiness = new BrandBusiness())
                {
                    res = brandBusiness.AddBrand(entity);
                }
                
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in AddBrand() func. in Spice-WebService.BrandService\n" + ex.Message;
            }
            return res;
        }

        [WebMethod]
        public Response<Brand> FetchAllBrands()
        {
            Response<Brand> res = new Response<Brand>();
            try
            {
                using(var brandBusiness = new BrandBusiness())
                {
                    res = brandBusiness.FetchAllBrands();
                }
            }
            catch (Exception ex)
            {
                res.Message = "An error occured in FetchAllBrands() func. in Spice-Websevice.BrandService\n" + ex.Message;
                res.isSuccess = false;
            }
            return res;
        }

        [WebMethod]
        public Response<Brand> UpdateBrand(Brand entity)
        {
            Response<Brand> res = new Response<Brand>();
            try
            {
                using(var brandBusiness = new BrandBusiness())
                {
                    res = brandBusiness.UpdateBrand(entity);
                }
            }
            catch (Exception ex)
            {
                res.isSuccess = false;
                res.Message = "An error occured in UpdateBrand() function in Spice-WebService.BrandService\n"+ex.Message;
            }
            return res;
        }

        [WebMethod]
        public Response<Brand> FetchOneBrandById(int BrandID)
        {
            Response<Brand> res = new Response<Brand>();

            try
            {
                using(var brandBusiness = new BrandBusiness())
                {
                    res = brandBusiness.FetchOneBrandById(BrandID);
                }
            }
            catch (Exception ex)
            {
                res.Message = "An error occured in FetchOneBrandById() in Spice-WebService.BrandService\n" + ex.Message;
                res.isSuccess = false;
            }
            return res;
        }
    }
}
