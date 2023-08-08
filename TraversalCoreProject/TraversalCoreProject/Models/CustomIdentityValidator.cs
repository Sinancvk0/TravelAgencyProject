using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.X509Certificates;

namespace TraversalCoreProject.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parola minimum {length} karakter olmalıdır"

            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = "Şifreler en az bir rakam içermelidir."
            };
        }

    }

}

