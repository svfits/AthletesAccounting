using System.ComponentModel.DataAnnotations;

namespace AthletesAccounting.DataBase
{
    public class Templates
    {
        [Key]
        public int id { get; set; }

        public string templateFilename { get; set; }

        public byte[] template {get;set; }

        public string notesTemplate { get; set; }
    }
}