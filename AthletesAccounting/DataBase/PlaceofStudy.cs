using System.ComponentModel.DataAnnotations;

namespace AthletesAccounting.DataBase
{
    public class PlaceofStudy
    {
        [Key]
        public int Id { get; set; }

        public string Place_Study { get; set; }
    }
}