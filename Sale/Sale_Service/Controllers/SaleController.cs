using Sale_Bussiness;
using Sale_Bussiness.Interfaces;
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
        private ISaleBussiness saleBussiness;

        public SaleController(ISaleBussiness saleBussiness)
        {
            this.saleBussiness = saleBussiness;

        }

        // GET
        [HttpGet]
        [Route("api/sale/GetSale/{saleId}")]
        public Sale GetSale(int saleId)
        {
            Sale request = this.saleBussiness.ReadSale(saleId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/sale/InsertSale")]
        public string InsertSale(SaleSpecific saleSpecific)
        {
            bool introduced_well = this.saleBussiness.InsertSale(saleSpecific);

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
            bool updated_well = this.saleBussiness.UpdateSale(update);

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
            bool deleted_well = this.saleBussiness.DeleteSale(saleId);

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
