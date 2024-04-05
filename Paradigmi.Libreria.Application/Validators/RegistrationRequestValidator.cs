using FluentValidation;
using Paradigmi.Libreria.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Validators
{
    public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
    {
        public RegistrationRequestValidator() 
        {
            RuleFor(m => m.Email)
                .NotNull()
                .WithMessage("Il campo Email non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo Email non può essere vuoto")
                .Custom((email, context) =>
                {
                    var regEx = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
                    if (regEx.IsMatch(email) == false)
                        context.AddFailure("Il campo deve contenere una mail del formato corretto");
                });
            RuleFor(m => m.Password)
                .NotNull()
                .WithMessage("Il campo Password non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo Password non può essere vuoto")
                .Custom((value, context) =>
                {
                    var regEx = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$");
                    if (regEx.IsMatch(value) == false)
                    {
                        context.AddFailure("Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale");
                    }
                });
            RuleFor(m => m.Nome)
                .NotNull()
                .WithMessage("Il campo Nome non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo Nome non può essere vuoto");
            RuleFor(m => m.Cognome)
                .NotNull()
                .WithMessage("Il campo Cognome non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo Cognome non può essere vuoto");

        }
             
    }
}
