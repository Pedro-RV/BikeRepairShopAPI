using Autofac;
using NUnit.Framework;
using Supplier_Bussiness;
using Supplier_Bussiness.Interfaces;
using Supplier_Entities.EntityModel;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Tests
{
    [TestFixture]
    class EmployeeBussiness_Tests
    {
        private IEmployeeBussiness employeeBussiness;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.employeeBussiness = scope.Resolve<IEmployeeBussiness>();

            this.employeeBussiness.InsertEmployee(new EmployeeSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));
            this.employeeBussiness.InsertEmployee(new EmployeeSpecific("Rodolfo", "Suarez", "88", "rodolf@correo", "Avnd Institucion", "123", "321"));
            this.employeeBussiness.InsertEmployee(new EmployeeSpecific("Marco", "Polo", "99", "marco@correo", "Avnd Marco Polo", "000", "000"));

        }

        [Test]
        public void AAEmployeesList_Test()
        {
            List<Employee> currentEmployee = this.employeeBussiness.EmployeesList();

            Assert.AreEqual(currentEmployee[0].EmployeeName, "Jacinto");
            Assert.AreEqual(currentEmployee[1].EmployeeName, "Rodolfo");
            Assert.AreEqual(currentEmployee[2].EmployeeName, "Marco");

        }

        [Test]
        public void InsertEmployee_Test()
        {
            bool correct;

            correct = this.employeeBussiness.InsertEmployee(new EmployeeSpecific("antonio", "carrasco", "22", "carrasco@correo", "calle malagon", "56", "87"));

            Employee employeeGotten = this.employeeBussiness.ReadEmployee(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(employeeGotten.EmployeeName, "antonio");
            Assert.AreEqual(employeeGotten.Surname, "carrasco");
            Assert.AreEqual(employeeGotten.DNI, "22");
            Assert.AreEqual(employeeGotten.Email, "carrasco@correo");
            Assert.AreEqual(employeeGotten.EmployeeAddress, "calle malagon");
            Assert.AreEqual(employeeGotten.CP, "56");
            Assert.AreEqual(employeeGotten.MobileNum, "87");

        }

        [Test]
        public void ReadEmployee_Test()
        {
            Employee employeeGotten = this.employeeBussiness.ReadEmployee(1);

            Assert.AreEqual(employeeGotten.EmployeeName, "Jacinto");
            Assert.AreEqual(employeeGotten.Email, "sierra@correo");

        }

        [Test]
        public void ReadEmployeeDNI_Test()
        {
            Employee employeeGotten = this.employeeBussiness.ReadEmployeeDNI("77");

            Assert.AreEqual(employeeGotten.EmployeeName, "Jacinto");
            Assert.AreEqual(employeeGotten.Email, "sierra@correo");

        }

        [Test]
        public void UpdateEmployee_Test()
        {
            bool correct;

            EmployeeSpecific change = new EmployeeSpecific();
            change.EmployeeId = 2;
            change.EmployeeName = "Domingo";
            change.MobileNum = "621";

            correct = this.employeeBussiness.UpdateEmployee(change);

            Employee employeeCompare = this.employeeBussiness.ReadEmployee(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(employeeCompare.EmployeeName, "Domingo");
            Assert.AreEqual(employeeCompare.MobileNum, "621");

        }

        [Test]
        public void DeleteEmployee_Test()
        {
            bool correct;

            correct = this.employeeBussiness.DeleteEmployee(3);

            Assert.AreEqual(true, correct);

        }

    }
}
