using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using ZeusERP.Core.Entities;

namespace ZeusERP.Entities.Concrete
{
    [Table("t_contacts")]
    public class Contact : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }
        public string JobPosition { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteLink { get; set; }
        public string PhotoPath { get; set; }
        public string ExtraInfo { get; set; }
    }
}
