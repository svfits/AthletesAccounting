using System.ComponentModel.DataAnnotations;

namespace AthletesAccounting.DataBase.Log
{
    /// <summary>
    ////где произошло событие исключение
    /// </summary>
    public class WhereEvent
    {
        [Key]
        public int id { get; set; }

        public string whereEvent { get; set; }

    }
}