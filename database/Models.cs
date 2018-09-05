using System;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class University
    {
        [Key]
        public int Id { get; set;}
        public string Name {get; set;}
    }

    public class UniversityUnit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        [Required]
        public University University { get; set; }
    }

    public class ExchangeUnit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public UniversityUnit Unit { get; set; }
        [Required]
        public string OutlineHref { get; set; }
    }
}
