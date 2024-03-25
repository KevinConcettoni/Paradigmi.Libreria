using FluentValidation;
using Paradigmi.Libreria.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Validators
{
    public class ModificaLibroValidator : AbstractValidator<ModificaLibroRequest>
    {
        public ModificaLibroValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Il campo Id non pò essere vuoto")
                .GreaterThan(0)
                .WithMessage("Il campo Id deve essere maggiore di 0");
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Il campo Nome non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Nome non può essere nullo");
            RuleFor(x => x.Autore)
               .NotEmpty()
               .WithMessage("Il campo Autore non può essere vuoto")
               .NotNull()
               .WithMessage("Il campo Autore non può essere nullo");
            RuleFor(x => x.Editore)
                .NotEmpty()
                .WithMessage("Il campo Il campo Editore non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Editore non può essere nullo");
            RuleFor(x => x.DataPubblicazione)
               .NotEmpty()
               .WithMessage("Il campo DataPubblicazione non può essere vuoto")
               .NotNull()
               .WithMessage("Il campo DataPubblicazione non può essere nullo");
        }
    }
}
