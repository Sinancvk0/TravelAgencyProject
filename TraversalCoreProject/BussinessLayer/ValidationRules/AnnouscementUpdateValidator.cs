using DTOLayer.DTOs.AnnouscementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class AnnouscementUpdateValidator:AbstractValidator<AnnounscementUpdateDto>
    {
        public AnnouscementUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen başlık değeri giriniz");
            RuleFor(y => y.Content).NotEmpty().WithMessage("Lütfen duyuru içeriği giriniz...");
        }
    }
}
