using Autofac.Extras.FakeItEasy;
using FakeItEasy;
using Supplier_Service.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supplier_Entities.EntityModel;
using InterconnectServicesLibrary.Entities.SupplierSpecific;
using Autofac;
using Moq;
using System.Net.Http.Headers;
using Supplier_Helper.Authentication;
using Supplier_Bussiness.Interfaces;
using Supplier_Data.Interfaces;

namespace Service_Tests
{
    [TestFixture]
    class EmployeeController_Tests
    {
        [Test]
        public void AAEmployeesList_Test()
        {
            using (var fake = new AutoFake())
            {
                List<Employee> mockLista = new List<Employee>();
                mockLista.Add(new Employee()
                {                   
                    EmployeeName = "Jacinto",
                    Surname = "Sierra",
                    EmployeeAddress = "Calle falsa, 123",
                    EmployeeId = 666
                });

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IEmployeeBussiness>().EmployeesList()).Returns(mockLista);

                var mockService = fake.Resolve<EmployeeController>();

                List<Employee> lista = mockService.EmployeesList();
            }
        }

        [Test]
        public void InsertEmployee_Test()
        {
            using (var fake = new AutoFake())
            {

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IEmployeeBussiness>().InsertEmployee(A<EmployeeSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<EmployeeController>();

                string message = mockService.InsertEmployee(new EmployeeSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void GetEmployee_Test()
        {
            using (var fake = new AutoFake())
            {
                Employee mockEmployee = new Employee("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IEmployeeBussiness>().ReadEmployee(A<int>.Ignored)).Returns(mockEmployee);

                var mockService = fake.Resolve<EmployeeController>();

                Employee employee = mockService.GetEmployee(1);
            }
        }

        [Test]
        public void GetEmployeeDNI_Test()
        {
            using (var fake = new AutoFake())
            {
                Employee mockEmployee = new Employee("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");

                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IEmployeeBussiness>().ReadEmployeeDNI(A<string>.Ignored)).Returns(mockEmployee);

                var mockService = fake.Resolve<EmployeeController>();

                Employee employee = mockService.GetEmployeeDNI("77");
            }
        }

        [Test]
        public void UpdateEmployee_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IEmployeeBussiness>().UpdateEmployee(A<EmployeeSpecific>.Ignored)).Returns(true);

                var mockService = fake.Resolve<EmployeeController>();

                string message = mockService.UpdateEmployee(new EmployeeSpecific("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23"));

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }

        [Test]
        public void DeleteEmployee_Test()
        {
            using (var fake = new AutoFake())
            {
                A.CallTo(() => fake.Resolve<IAuthenticationProvider>().CheckAuthentication(A<HttpRequestHeaders>.Ignored)).Returns(true);
                A.CallTo(() => fake.Resolve<IEmployeeBussiness>().DeleteEmployee(A<int>.Ignored)).Returns(true);

                var mockService = fake.Resolve<EmployeeController>();

                string message = mockService.DeleteEmployee(1);

                Assert.AreEqual(message, "Action completed satisfactorily.");
            }
        }
    }
}
