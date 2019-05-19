using AspNetCore.Common.Identity;
using AspNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomains.Core
{
    public class EntityBase<TKeyType> : IVersionedEntity<TKeyType>
    {
        public TKeyType Id { set; get; }

        public DateTimeOffset CreatedDate { set; get; }
        public TKeyType CreatedByUserId { set; get; }
        public string CreateByUserName { set; get; }

        public DateTimeOffset UpdatedDate { set; get; }
        public TKeyType UpdatedByUserId { set; get; }
        public string UpdateByUserName { set; get; }

        public byte[] RowVersion { set; get; }
       
        public EntityBase<TKeyType> CreateBy(UserIdentity<TKeyType> issuer)
        {
            var now = DateTimeOffset.UtcNow;

            CreatedByUserId = issuer.Id;
            CreateByUserName = issuer.Username;
            CreatedDate = now;

            return this;
        }

        public EntityBase<TKeyType> UpdateBy(UserIdentity<TKeyType> issuer)
        {
            var now = DateTimeOffset.UtcNow;

            UpdatedByUserId = issuer.Id;
            UpdateByUserName = issuer.Username;
            UpdatedDate = now;

            return this;
        }
    }
}
