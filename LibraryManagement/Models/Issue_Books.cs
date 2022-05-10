using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Issue_Books
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int Student_Id { get; set; }

        [Required]

        [ForeignKey("BookNo")]
        public int BookNo { get; set; }
        
      
        [Required]
        public string BookName { get; set; }
       // public virtual AddBooks AddB { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
    }
}
