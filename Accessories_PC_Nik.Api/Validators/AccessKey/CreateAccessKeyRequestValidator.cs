﻿using FluentValidation;
using Accessories_PC_Nik.Api.ModelsRequest.Discipline;

namespace Accessories_PC_Nik.Api.Validators.Discipline
{
    /// <summary>
    /// Валидатор класса <see cref="CreateAccessKeyRequest"/>
    /// </summary>
    public class CreateAccessKeyRequestValidator : AbstractValidator<CreateAccessKeyRequest>
    {
        /// <summary>
        /// Инициализирую <see cref="CreateAccessKeyRequestValidator"/>
        /// </summary>
        public CreateAccessKeyRequestValidator()
        {
            RuleFor(x=>x.Key)
                .NotNull()
                .NotEmpty()
                .WithMessage("Ключ не должен быть пустым или null");

            RuleFor(x => x.Types)
                .NotNull()
                .WithMessage("Уровень доступа не должен быть null");
        }
    }
}
