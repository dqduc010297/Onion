using AspNetCore.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomains.Identity.Entities
{
    public class Role : IdentityRole<string>, IVersionedEntity<string>
    {
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }     // use to query/join
        public string CreatedByUserName { get; set; } // Use to display

        public DateTimeOffset ModifiedDate { get; set; }
        public string ModifiedByUserId { get; set; }     // use to query/join
        public string ModifiedByUserName { get; set; } // Use to display
        public byte[] RowVersion { get; set; }
    }
}
