using Autofac;
using Moq;
using NUnit.Framework;
using Supplier_Data;
using Supplier_Data.Context;
using Supplier_Data.Interfaces;
using Supplier_Entities.EntityModel;
using Supplier_Helper.ExceptionController;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Data_Tests
{
    [TestFixture]
    class EmployeeRepository_Tests
    {
        private IEmployeeRepository employeeRepository;

        [TestFixtureSetUp]
        public void Init()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();

            this.employeeRepository = scope.Resolve<IEmployeeRepository>();

            Employee employeeOne = new Employee("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            Employee employeeOneTwo = new Employee("Rodolfo", "Suarez", "88", "rodolf@correo", "Avnd Institucion", "123", "321");
            Employee employeeOneThree = new Employee("Marco", "Polo", "99", "marco@correo", "Avnd Marco Polo", "000", "000");

            this.employeeRepository.Insert(employeeOne);
            this.employeeRepository.Insert(employeeOneTwo);
            this.employeeRepository.Insert(employeeOneThree);
        }

        [Test]
        public void Insert_Test()
        {
            Employee employeeAdd = new Employee("antonio", "carrasco", "22", "carrasco@correo", "calle malagon", "56", "87");
            bool correct;

            correct = this.employeeRepository.Insert(employeeAdd);

            Employee employeeGotten = this.employeeRepository.Read(4);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(employeeGotten.EmployeeName, employeeAdd.EmployeeName);
            Assert.AreEqual(employeeGotten.Surname, employeeAdd.Surname);
            Assert.AreEqual(employeeGotten.DNI, employeeAdd.DNI);
            Assert.AreEqual(employeeGotten.Email, employeeAdd.Email);
            Assert.AreEqual(employeeGotten.EmployeeAddress, employeeAdd.EmployeeAddress);
            Assert.AreEqual(employeeGotten.CP, employeeAdd.CP);
            Assert.AreEqual(employeeGotten.MobileNum, employeeAdd.MobileNum);

        }

        [Test]
        public void Read_Test()
        {
            Employee employeeGotten = this.employeeRepository.Read(3);

            Assert.AreEqual(employeeGotten.EmployeeName, "Marco");
            Assert.AreEqual(employeeGotten.Email, "marco@correo");

        }

        [Test]
        public void Update_Test()
        {
            bool correct;
            Employee employeeGotten = this.employeeRepository.Read(2);

            employeeGotten.EmployeeName = "Domingo";
            employeeGotten.MobileNum = "621";

            correct = this.employeeRepository.Update(employeeGotten);

            Employee employeeCompare = this.employeeRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(employeeCompare.EmployeeName, employeeGotten.EmployeeName);
            Assert.AreEqual(employeeCompare.MobileNum, employeeGotten.MobileNum);

        }

        [Test]
        public void Delete_Test()
        {
            bool correct;
            Employee employeeGotten = this.employeeRepository.Read(1);

            correct = this.employeeRepository.Delete(employeeGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
