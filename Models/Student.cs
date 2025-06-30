using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Operation_using_Code_First.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }

        [Column("StudentName", TypeName = "varchar(200)")]
        [Required]
        public string Name {get; set; }

        [Column("StudentAge")]
        [Required]
        public int Age { get; set; }

        [Column("StudentGander", TypeName = "varchar(20)")]
        [Required]
        public string Gander { get; set; }

        [Column("StudentClass")]
        [Required]
        public int Standard { get; set; }


    }
}
