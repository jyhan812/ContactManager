using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace DataEntity.Models
{
    public class ContactModel
    {       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ContactID { get; set; }

        [Required(ErrorMessage = "*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "*")]
        public string Email { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }

    public class ContactViewAudit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int auditID { get; set; }

        public int ContactID { get; set; }

        public DateTime LastUpdateDateTime { get; set; }

        public string TransactionType { get; set; }
    }
}
