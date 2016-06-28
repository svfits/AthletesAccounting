using System.ComponentModel.DataAnnotations;

namespace AthletesAccounting.DataBase
{
    public class PastIllness
    {
        [Key]
        public int pastIllnesses_id { get; set; }

        public string pastIllnesses { get; set; }
    }
}