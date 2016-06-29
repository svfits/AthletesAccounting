
using System.ComponentModel.DataAnnotations;
namespace AthletesAccounting.DataBase
{
    public class Education
    {
        [Key]
        public int education_id { get; set; }
        public string education { get; set; }
    }
}