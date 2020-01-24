using Supplier_Service.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;

namespace Service_Tests
{
    [TestFixture]
    class EmployeeController_Tests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            EmployeeController employeeController = new EmployeeController();

            employeeController.InsertEmployee(new EmployeeSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            employeeController.InsertEmployee(new EmployeeSpecific("Rodolfo", "Suarez", "88", "rodolf@correo", "Avnd Institucion", "123", "321"));
            employeeController.InsertEmployee(new EmployeeSpecific("Marco", "Polo", "99", "marco@correo", "Avnd Marco Polo", "000", "000"));

        }

        [Test]
        public void AAEmployeesList_Test()
        {
            EmployeeController employeeController = new EmployeeController();

            List<Employee> currentEmployee = employeeController.EmployeesList();

            Assert.AreEqual(currentEmployee[0].EmployeeName, "Jacinto");
            Assert.AreEqual(currentEmployee[1].EmployeeName, "Rodolfo");
            Assert.AreEqual(currentEmployee[2].EmployeeName, "Marco");

        }

        [Test]
        public void InsertEmployee_Test()
        {
            EmployeeController employeeController = new EmployeeController();

            String message = employeeController.InsertEmployee(new EmployeeSpecific("antonio", "carrasco", "22", "carrasco@correo", "calle malagon", "56", "87"));

            Employee employeeGotten = employeeController.GetEmployee(4);

            Assert.AreEqual(message, "Employee introduced satisfactorily.");
            Assert.AreEqual(employeeGotten.EmployeeName, "antonio");
            Assert.AreEqual(employeeGotten.Surname, "carrasco");
            Assert.AreEqual(employeeGotten.DNI, "22");
            Assert.AreEqual(employeeGotten.Email, "carrasco@correo");
            Assert.AreEqual(employeeGotten.EmployeeAddress, "calle malagon");
            Assert.AreEqual(employeeGotten.CP, "56");
            Assert.AreEqual(employeeGotten.MobileNum, "87");

        }

        [Test]
        public void GetEmployee_Test()
        {
            EmployeeController employeeController = new EmployeeController();

            Employee employeeGotten = employeeController.GetEmployee(1);

            Assert.AreEqual(employeeGotten.EmployeeName, "Jacinto");
            Assert.AreEqual(employeeGotten.Email, "sierra@correo");

        }

        [Test]
        public void GetEmployeeDNI_Test()
        {
            EmployeeController employeeController = new EmployeeController();

            Employee employeeGotten = employeeController.GetEmployeeDNI("77");

            Assert.AreEqual(employeeGotten.EmployeeName, "Jacinto");
            Assert.AreEqual(employeeGotten.Email, "sierra@correo");

        }

        [Test]
        public void UpdateEmployee_Test()
        {
            EmployeeController employeeController = new EmployeeController();

            EmployeeSpecific change = new EmployeeSpecific();
            change.EmployeeId = 2;
            change.EmployeeName = "Domingo";
            change.MobileNum = "621";

            String message = employeeController.UpdateEmployee(change);

            Employee employeeCompare = employeeController.GetEmployee(2);

            Assert.AreEqual(message, "Employee updated satisfactorily.");
            Assert.AreEqual(employeeCompare.EmployeeName, "Domingo");
            Assert.AreEqual(employeeCompare.MobileNum, "621");

        }

        [Test]
        public void DeleteEmployee_Test()
        {
            EmployeeController employeeController = new EmployeeController();

            String message = employeeController.DeleteEmployee(3);

            Assert.AreEqual(message, "Employee deleted satisfactorily.");

        }
    }
}
