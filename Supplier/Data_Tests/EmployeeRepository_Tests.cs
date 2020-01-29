using Moq;
using NUnit.Framework;
using Supplier_Data;
using Supplier_Data.Context;
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
        private SupplierContext dbContext;
        private ExceptionController exceptionController;

        public EmployeeRepository_Tests()
        {
            SupplierContextProvider.InitializeSupplierContext();
            dbContext = SupplierContextProvider.GetSupplierContext();
            exceptionController = new ExceptionController();
        }

        [TestFixtureSetUp]
        public void Init()
        {
            Employee employeeOne = new Employee("Jacinto", "Sierra", "77", "sierra@correo", "Calle Poeta", "34", "23");
            Employee employeeOneTwo = new Employee("Rodolfo", "Suarez", "88", "rodolf@correo", "Avnd Institucion", "123", "321");
            Employee employeeOneThree = new Employee("Marco", "Polo", "99", "marco@correo", "Avnd Marco Polo", "000", "000");
            EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);

            employeeRepository.Insert(employeeOne);
            employeeRepository.Insert(employeeOneTwo);
            employeeRepository.Insert(employeeOneThree);
        }

        [Test]
        public void Insert_Test()
        {
            Employee employeeAdd = new Employee("antonio", "carrasco", "22", "carrasco@correo", "calle malagon", "56", "87");
            bool correct;
            EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);

            correct = employeeRepository.Insert(employeeAdd);

            Employee employeeGotten = employeeRepository.Read(4);

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
            EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);

            Employee employeeGotten = employeeRepository.Read(3);

            Assert.AreEqual(employeeGotten.EmployeeName, "Marco");
            Assert.AreEqual(employeeGotten.Email, "marco@correo");

        }

        [Test]
        public void Update_Test()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);
            bool correct;
            Employee employeeGotten = employeeRepository.Read(2);

            employeeGotten.EmployeeName = "Domingo";
            employeeGotten.MobileNum = "621";

            correct = employeeRepository.Update(employeeGotten);

            Employee employeeCompare = employeeRepository.Read(2);

            Assert.AreEqual(true, correct);
            Assert.AreEqual(employeeCompare.EmployeeName, employeeGotten.EmployeeName);
            Assert.AreEqual(employeeCompare.MobileNum, employeeGotten.MobileNum);

        }

        [Test]
        public void Delete_Test()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository(dbContext, exceptionController);
            bool correct;
            Employee employeeGotten = employeeRepository.Read(1);

            correct = employeeRepository.Delete(employeeGotten);

            Assert.AreEqual(true, correct);

        }
    }
}
