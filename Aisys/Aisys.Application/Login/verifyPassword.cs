using System;
using System.Collections.Generic;
using System.Text;

namespace Aisys.Application.Login
{
    public class VerifyPasswordInput
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool returnSecureToken { get; set; }
    }

    public class VerifyPasswordOutput
    {
        public string idToken { get; set; }
        public string localId { get; set; }
        public int expiresIn { get; set; }
    }
}
