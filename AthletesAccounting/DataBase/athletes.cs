using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthletesAccounting.DataBase
{
  public  class Athletes
    {
        [Key]
        public int id { get; set; }
        /// <summary>
        ////имя
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// фамилия
        /// </summary>
        public string fam { get; set; }
        /// <summary>
        /// отчество
        /// </summary>
        public string parent { get; set; }      
        /// <summary>
        /// пол
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        ////адрес где проживает
        /// </summary>
        public string adress {get; set;}
        /// <summary>
        /// телефон
        /// </summary>
        public string telefon { get; set; }      
        /// <summary>
        /// место учебы или работы
        /// </summary>     
        public string PlaceofStudyAndWork { get; set; }     
        
        /// <summary>
        ////Спортколлектив ДЮСШ
        /// </summary>
        public int? sportTeam { get; set; }
        public virtual SportTeam SportTeam { get; set; }
        /// <summary>
        /// профессия спортсмена
        /// </summary>
        public string profAthlets { get; set; }
        /// <summary>
        ////образование
        /// </summary>
        public int? education { get; set; }
        public virtual Education Education { get; set; }

        /// <summary>
        /// алкоголь
        /// </summary>
        public string alcphol { get; set; }

        /// <summary>
        ////жилищные условия
        /// </summary>
        public string housing { get; set; }
        /// <summary>
        // курение
        /// </summary>
       public string  smoke { get; set; }
        /// <summary>
        ////перенесенные заболевания 
        /// </summary>
        public int? pastIllnesses_id { get; set; }
        [ForeignKey("pastIllnesses_id")]
        public virtual PastIllness PastIllness { get; set; }
        /// <summary>
        ////травмы
        /// </summary>      
        public string Injuries { get; set; }

        /// <summary>
        //// операции
        /// </summary>
        public int? operations_id { get; set; }
        [ForeignKey("operations_id")]
        public virtual Operations Operations { get; set; }

        /// <summary>
        ////вид спорта
        /// </summary>
        public int? sports_id { get; set; }
        [ForeignKey("sports_id")]
        public virtual Sports Sports { get; set; }


        /// <summary>
        ////разряд
        /// </summary>
        public int? rank_id { get; set; }
        [ForeignKey("rank_id")]
        public virtual Rank Rank { get; set; }        
        /// <summary>
        ////дата рождения
        /// </summary>
        public DateTime DOB { get; set; } 

        //public int? mainSport { get; set; }
        //[ForeignKey("idAthlets")]
        //public virtual MainSports MainSports { get; set; }


        /// <summary>
        ////другие виде спорта
        /// </summary>
        public string otherSports { get; set; }
        /// <summary>
        /// По каким видам спорта участвовал в соревнованиях
        /// </summary>
        public string otherSportsGames { get; set; }
        
         
    }
  
}
