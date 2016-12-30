using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Models
{
    public class CMIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            IdentityError error = base.DuplicateUserName(email);
            error.Description = $"Adres e-mail {email} jest już zajęty";

            return error;
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            IdentityError error = base.DuplicateUserName(userName);
            error.Description = $"Nazwa użytkownika {userName} jest już zajęta";

            return error;
        }


        public override IdentityError PasswordTooShort(int length)
        {
            IdentityError error = base.PasswordTooShort(length);
            error.Description = $"Hasło musi mieć co najmniej {length} znaków";

            return error;
        }
    }
}
