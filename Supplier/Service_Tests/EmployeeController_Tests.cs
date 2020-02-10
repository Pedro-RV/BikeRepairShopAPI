using Supplier_Service.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supplier_Entities.EntityModel;
using Supplier_Entities.Specific;
using Autofac;

namespace Service_Tests
{
    [TestFixture]
    class EmployeeController_Tests
    {
        private EmployeeController employeeController;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.employeeController = scope.Resolve<EmployeeController>();

            this.employeeController.InsertEmployee(new EmployeeSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            this.employeeController.InsertEmployee(new EmployeeSpecific("Rodolfo", "Suarez", "88", "rodolf@correo", "Avnd Institucion", "123", "321"));
            this.employeeController.InsertEmployee(new EmployeeSpecific("Marco", "Polo", "99", "marco@correo", "Avnd Marco Polo", "000", "000"));

        }

        [Test]
        public void AAEmployeesList_Test()
        {
            List<Employee> currentEmployee = this.employeeController.EmployeesList();

            Assert.AreEqual(currentEmployee[0].EmployeeName, "Jacinto");
            Assert.AreEqual(currentEmployee[1].EmployeeName, "Rodolfo");
            Assert.AreEqual(currentEmployee[2].EmployeeName, "Marco");

        }

        [Test]
        public void InsertEmployee_Test()
        {
            string message = this.employeeController.InsertEmployee(new EmployeeSpecific("antonio", "carrasco", "22", "carrasco@correo", "calle malagon", "56", "87"));

            Employee employeeGotten = this.employeeController.GetEmployee(4);

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
            Employee employeeGotten = this.employeeController.GetEmployee(1);

            Assert.AreEqual(employeeGotten.EmployeeName, "Jacinto");
            Assert.AreEqual(employeeGotten.Email, "sierra@correo");

        }

        [Test]
        public void GetEmployeeDNI_Test()
        {
            Employee employeeGotten = this.employeeController.GetEmployeeDNI("77");

            Assert.AreEqual(employeeGotten.EmployeeName, "Jacinto");
            Assert.AreEqual(employeeGotten.Email, "sierra@correo");

        }

        [Test]
        public void UpdateEmployee_Test()
        {
            EmployeeSpecific change = new EmployeeSpecific();
            change.EmployeeId = 2;
            change.EmployeeName = "Domingo";
            change.MobileNum = "621";

            string message = this.employeeController.UpdateEmployee(change);

            Employee employeeCompare = this.employeeController.GetEmployee(2);

            Assert.AreEqual(message, "Employee updated satisfactorily.");
            Assert.AreEqual(employeeCompare.EmployeeName, "Domingo");
            Assert.AreEqual(employeeCompare.MobileNum, "621");

        }

        [Test]
        public void DeleteEmployee_Test()
        {
            string message = this.employeeController.DeleteEmployee(3);

            Assert.AreEqual(message, "Employee deleted satisfactorily.");

        }
    }
}
