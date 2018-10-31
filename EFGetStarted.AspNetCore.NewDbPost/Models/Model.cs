using EFGetStarted.AspNetCore.NewDbPost.Recursos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EFGetStarted.AspNetCore.NewDbPost.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Local> Locals { get; set; }
    }

    public enum TypeCompanies
    {
        Comercial=1,
        Residential=2
    }


    public class Company
    {
        //private const string campReq = "El campo {0} es obligatorio";

        public int CompanyId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Recurso), ErrorMessageResourceName = "Message_Error_Required")]
        [Display(ResourceType = typeof(Recurso), Name = "Company_nombre_mostrar")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Recurso), ErrorMessageResourceName = "Message_Error_Required")]
        [Display(ResourceType = typeof(Recurso), Name = "Company_type_mostrar")]
        [DisplayFormat(NullDisplayText = "No type")]
        public TypeCompanies? Type { get; set; }

        [Required(ErrorMessageResourceType = typeof(Recurso), ErrorMessageResourceName = "Message_Error_Required")]
        [Display(ResourceType = typeof(Recurso), Name = "Company_SSN_mostrar")]
        public string SSNCompany { get; set; }

        public ICollection<Local> Locals { get; set; }
    }

    public class Local:IValidatableObject
    {
        private const string email = "El {0} es incorrecto";
        
        public int LocalId { get; set; }


        [Required(ErrorMessageResourceType = typeof(Recurso), ErrorMessageResourceName = "Message_Error_Required")]
        [Display(ResourceType = typeof(Recurso), Name = "Local_ID_mostrar")]
        public string SpaceID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Recurso), ErrorMessageResourceName = "Message_Error_Required")]
        [Display(ResourceType = typeof(Recurso), Name = "Local_SquareFoot")]
        public int SquareFoot { get; set; }

        [Required(ErrorMessageResourceType = typeof(Recurso), ErrorMessageResourceName = "Message_Error_Required")]
        [Display(ResourceType = typeof(Recurso), Name = "Local_PriceSF")]
        public double PricebySF { get; set; }


        [Required(ErrorMessageResourceType = typeof(Recurso), ErrorMessageResourceName = "Message_Error_Required")]
        [Display(ResourceType = typeof(Recurso), Name = "Local_MonthlyPayment")]
        public double MonthlyPayment { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Recurso), ErrorMessageResourceName = "Message_Error_Required")]
        [Display(ResourceType = typeof(Recurso), Name = "Local_AnnualPayment")]
        public double AnnualPayment { get; set; }
       

        [Display(ResourceType = typeof(Recurso), Name = "Local_Deposit")]
        public double Deposit { get; set; }

        [Display(ResourceType = typeof(Recurso), Name = "Local_BussinesName")]
        public string BussinesName { get; set; }

        [Display(ResourceType = typeof(Recurso), Name = "Local_ContractStart")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ContractStart { get; set; }

        [Display(ResourceType = typeof(Recurso), Name = "Local_ContractEnd")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ContractEnd { get; set; }

        [Display(ResourceType = typeof(Recurso), Name = "Local_NameOwner")]
        public string NameOwner { get; set; }
        [EmailAddress(ErrorMessage = email)]
        public string Email { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ContractEnd <= ContractStart)
            {
                yield return new ValidationResult("The contract date must be after to start date", new[] { "ContractEnd" });
            }
            
        }
    }
}
