using ManagementRegistration.Domain.Contracts.Services;
using ManagementRegistration.Domain.Models;
using ManagementRegistration.ServicesFactory.Enums;
using System;
using Xunit;

namespace ManagementRegistration.UnitTest
{
    public class RegistrationTest
    {
        IRegisterService service = ServicesFactory.ServicesFactory.GetServiceInstance(EnumServices.Register) as IRegisterService;

        [Fact]
        public void TestInsertRegistration()
        {
            RegisterModel register = new RegisterModel();
            register.Name = "João Silva";
            register.Email = "joao.silva@teste.com.br";
            register.Unemployed = false;
            register.DateBirth = DateTime.Parse("22/03/1984");
            register.ProfessionId = 1;
            service.InsertRegister(register);
        }
    }
}