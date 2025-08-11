using System.ComponentModel.DataAnnotations;

namespace StudentAPICrud.Data
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public string stname { get; set; }
        public string course { get; set; }
        public string Email { get; set; }
        public int Age {  get; set; }
    }
}
