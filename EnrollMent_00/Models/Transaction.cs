using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollMent_00.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Enrollment Id")]
        public int EnrollmentID { get; set; }
        [Required]
        [Display(Name = "Transaction Id")]
        public string TransactionId { get; set; }
        [Required]
        [Display(Name = "Payment Mobile No")]
        public string MobileNo { get; set; }
        [Required]
        public float Amount { get; set; }

        public bool Received { get; set; }

        public Enrollment Enrollment { get; set; }
    }
}
