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
    public class BillController : ApiController
    {
        // GET
        [HttpGet]
        [Route("api/bill/GetBill/{billId}")]
        public Bill GetBill(int billId)
        {
            BillBussiness billBussiness = new BillBussiness();

            Bill request = billBussiness.ReadBill(billId);

            return request;
        }

        // POST
        [HttpPost]
        [Route("api/bill/InsertBill")]
        public string InsertBill(BillSpecific billSpecific)
        {
            BillBussiness billBussiness = new BillBussiness();

            bool introduced_well = billBussiness.InsertBill(billSpecific);

            if (introduced_well == true)
            {
                return "Bill introduced satisfactorily.";
            }
            else
            {
                return "Error !!! Bill could not be introduced.";
            }

        }

        // PUT
        [HttpPut]
        [Route("api/bill/UpdateBill")]
        public string UpdateBill(BillSpecific update)
        {
            BillBussiness billBussiness = new BillBussiness();

            bool updated_well = billBussiness.UpdateBill(update);

            if (updated_well == true)
            {
                return "Bill updated satisfactorily.";
            }
            else
            {
                return "Error !!! Bill could not be updated.";
            }

        }

        // DELETE
        [HttpDelete]
        [Route("api/bill/DeleteBill/{billId}")]
        public string DeleteBill(int billId)
        {
            BillBussiness billBussiness = new BillBussiness();

            bool deleted_well = billBussiness.DeleteBill(billId);

            if (deleted_well == true)
            {
                return "Bill deleted satisfactorily.";
            }
            else
            {
                return "Error !!! Bill could not be deleted.";
            }

        }
    }
}
