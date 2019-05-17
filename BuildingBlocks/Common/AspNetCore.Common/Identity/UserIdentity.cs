using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Common.Identity
{
    public class UserIdentity<TType>
    {
        public TType Id { set; get; }
        public string Username { set; get; }
    }
}
