using FluentValidation;
using Paradigmi.Libreria.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Validators
{
    public class EliminaLibroValidator : AbstractValidator<EliminaLibroRequest>
    {
        public EliminaLibroValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Il campo Id non pò essere vuoto")
                .GreaterThan(0)
                .WithMessage("Il campo Id deve essere maggiore di 0"); 
        }
    }
}
