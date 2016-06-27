using System.ComponentModel.DataAnnotations;

namespace AthletesAccounting.DataBase
{
    public class PlaceofStudyAndWork
    {
        [Key]
        public int Id { get; set; }

        public string placeStudy { get; set; }
    }
}