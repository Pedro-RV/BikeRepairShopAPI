using Sale_Bussiness;
using Sale_Entities.EntityModel;
using Sale_Entities.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sale_Service.Controllers
{
    public class SaleController : ApiController
    {
        // GET
        [HttpGet]
        [Route("api/sale/GetSale/{saleId}")]
        public Sale GetSale(int saleId)
        {
            SaleBussiness saleBussiness = new SaleBussiness();

            Sale request = saleBussiness.ReadSale(saleId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/sale/InsertSale")]
        public string InsertSale(SaleSpecific saleSpecific)
        {
            SaleBussiness saleBussiness = new SaleBussiness();

            bool introduced_well = saleBussiness.InsertSale(saleSpecific);

            if (introduced_well == true)
            {
                return "Sale introduced satisfactorily.";
            }
            else
            {
                return "Error !!! Sale could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/sale/UpdateSale")]
        public string UpdateSale(SaleSpecific update)
        {
            SaleBussiness saleBussiness = new SaleBussiness();

            bool updated_well = saleBussiness.UpdateSale(update);

            if (updated_well == true)
            {
                return "Sale updated satisfactorily.";
            }
            else
            {
                return "Error !!! Sale could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/sale/DeleteSale/{saleId}")]
        public string DeleteSale(int saleId)
        {
            SaleBussiness saleBussiness = new SaleBussiness();

            bool deleted_well = saleBussiness.DeleteSale(saleId);

            if (deleted_well == true)
            {
                return "Sale deleted satisfactorily.";
            }
            else
            {
                return "Error !!! Sale could not be deleted.";
            }

        }
    }
}
