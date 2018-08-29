using MongoDB.Bson;
using System;
using System.Text.RegularExpressions;

namespace ManagementRegistration.Domain.Models
{
    public class RegisterModel : BaseModel
    {
        private string name { get; set; }
        private string email { get; set; }
        private int professionId { get; set; }
        public string ProfessionDescription { get; set; }
        private DateTime dateBirth;

        public ObjectId Id { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                ValidateName();
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                ValidateEmail();
            }
        }
        public int ProfessionId
        {
            get { return professionId; }
            set
            {
                professionId = value;
                ValidateProfession();
            }
        }
        public DateTime DateBirth
        {
            get { return dateBirth; }
            set
            {
                dateBirth = value;
                CalculateAge();
            }
        }
        public bool Unemployed { get; set; }
        public int Age { get; set; }

        private void ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                this.Error = true;
                this.Message = string.IsNullOrEmpty(this.Message) ? "Informe o nome." : this.Message + "\nInforme o nome.";
                return;
            }
        }

        private void ValidateEmail()
        {
            if (string.IsNullOrEmpty(Email))
            {
                this.Error = true;
                this.Message = string.IsNullOrEmpty(this.Message)? "Informe o e-mail." : this.Message + "\nInforme o e-mail.";
                return;
            }

            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            if (!rg.IsMatch(Email))
            {
                this.Error = true;
                this.Message = string.IsNullOrEmpty(this.Message) ? "E-mail inválido." : this.Message + "\nE-mail inválido.";
                return;
            }
        }

        private void ValidateProfession()
        {
            if (ProfessionId <= 0)
            {
                this.Error = true;
                this.Message = string.IsNullOrEmpty(this.Message) ? "Escolha a profissão." : this.Message + "\nEscolha a profissão.";
                return;
            }
        }

        private void CalculateAge()
        {
            if (DateBirth == null)
            {
                this.Error = true;
                this.Message = string.IsNullOrEmpty(this.Message) ? "Informe a data de nascimento." : this.Message + "\nInforme a data de nascimento.";
                return;
            }

            Age = DateTime.Now.Year - DateBirth.Year;

            if (DateTime.Now.Month < DateBirth.Month)
                Age--;

            if (DateTime.Now.Month == DateBirth.Month
                && DateTime.Now.Day < DateBirth.Day)
                Age--;
        }
    }
}