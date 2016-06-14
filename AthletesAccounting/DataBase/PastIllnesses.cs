using System.ComponentModel.DataAnnotations;

namespace AthletesAccounting.DataBase
{
    public class PastIllnesses
    {
        [Key]
        public int Id { get; set; }

        public string Past_Illnesses { get; set; }
    }
}