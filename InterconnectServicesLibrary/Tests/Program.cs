using InterconnectServicesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://localhost:44315/api/employee/DeleteEmployee/";
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            //queryParams.Add("employeeId", "9");
            EmployeeSpecific insert = new EmployeeSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            EmployeeSpecific modify = new EmployeeSpecific();
            modify.EmployeeId = 11;
            modify.EmployeeName = "Braulio";

            object result = InterconnectServices.SendGet<object>(url, queryParams, 9);
            
            //string result = InterconnectServices.SendPost(url, queryParams, null, insert);

            //string result = InterconnectServices.SendPut(url, queryParams, null, modify);

            //string result = InterconnectServices.SendDelete(url, queryParams, 10);
        }
    }
}
