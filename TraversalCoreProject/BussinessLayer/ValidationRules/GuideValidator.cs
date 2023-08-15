using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{

    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Ad Soyad Giriniz");
            RuleFor(x => x.Descripition).NotEmpty().WithMessage("Lütfen Açıklama Giriniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen Rehber Görselini Giriniz");

        }

    }
}
