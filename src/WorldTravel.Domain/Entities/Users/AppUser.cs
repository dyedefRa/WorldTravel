//using WorldTravel.Entities.Adverts;
using WorldTravel.Entities.Files;
using WorldTravel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Users;

namespace WorldTravel.Entities.Users
{
    public class AppUser : FullAuditedAggregateRoot<Guid>, IUser
    {
        #region Base properties

        public virtual Guid? TenantId { get; private set; }
        public virtual string UserName { get; private set; }
        public virtual string Name { get; private set; }
        public virtual string Surname { get; private set; }
        public virtual string Email { get; private set; }
        public virtual bool EmailConfirmed { get; private set; }
        public virtual string PhoneNumber { get; private set; }
        public virtual bool PhoneNumberConfirmed { get; private set; }

        #endregion

        public UserType? UserType { get; set; }
        public GenderType? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public virtual int? ImageId { get; set; }
        [ForeignKey("ImageId")]
        public virtual File Image { get; set; }
        public Status? Status { get; set; }

        //public virtual ICollection<Advert> Adverts { get; set; }

    }
}
