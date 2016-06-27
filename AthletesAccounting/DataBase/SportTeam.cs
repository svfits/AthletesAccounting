using System.ComponentModel.DataAnnotations;
namespace AthletesAccounting.DataBase
{
    public class SportTeam
    {
        [Key]
        public int id { get; set; }
        public string sportTeam { get; set; }
    }
}