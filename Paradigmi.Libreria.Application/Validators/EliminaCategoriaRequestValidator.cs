﻿using FluentValidation;
using Paradigmi.Libreria.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Validators
{
    public class EliminaCategoriaRequestValidator : AbstractValidator<EliminaCategoriaRequest>
    {
        public EliminaCategoriaRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Il campo Nome non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Nome non può essere nullo");
        }
    }
}
