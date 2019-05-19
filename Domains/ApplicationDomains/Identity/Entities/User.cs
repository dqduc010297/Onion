using ApplicationDomains.Core;
using AspNetCore.Common.Identity;
using AspNetCore.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomains.Identity.Entities
{
    public class User : IdentityUser<string>, IVersionedEntity<string>
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }

        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }     // use to query/join
        public string CreatedByUserName { get; set; } // Use to display

        public DateTimeOffset UpdatedDate { get; set; }
        public string UpdatedByUserId { get; set; } // use to query/join
        public string UpdatedByUserName { get; set; } // Use to display

        public byte[] RowVersion { get; set; }
        public string Status { set; get; }

        public User CreateBy(UserIdentity<string> issuer)
        {
            var now = DateTimeOffset.UtcNow;

            CreatedByUserId = issuer.Id;
            CreatedByUserName = issuer.Username;
            CreatedDate = now;

            return this;
        }

        public User UpdateBy(UserIdentity<string> issuer)
        {
            var now = DateTimeOffset.UtcNow;

            UpdatedByUserId = issuer.Id;
            UpdatedByUserName = issuer.Username;
            UpdatedDate = now;

            return this;
        }
    }
}
