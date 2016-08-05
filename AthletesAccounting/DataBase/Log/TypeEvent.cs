using System.ComponentModel.DataAnnotations;

namespace AthletesAccounting.DataBase.Log
{
    /// <summary>
    ////тип событие
    /// </summary>
    public class TypeEvent
    {
        [Key]
        public int id { get; set; }

        public string typeEvent {get ; set; }
    }
}