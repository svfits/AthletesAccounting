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
        /// фамилия
        /// </summary>
        public string fam { get; set; }

        /// <summary>
        ////имя
        /// </summary>
        public string name { get; set; }
    
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
        /// жилищные условия
        /// </summary>
        public string livingСonditions { get; set; }
        
        /// <summary>
        ////Спортколлектив ДЮСШ
        /// </summary>
        public int? sportTeam_id { get; set; }
        [ForeignKey("sportTeam_id")]
        public virtual SportTeam SportTeam { get; set; }

        /// <summary>
        /// профессия спортсмена
        /// </summary>
        public string profAthlets { get; set; }

        /// <summary>
        ////образование
        /// </summary>
        public int? education_id { get; set; }
        [ForeignKey("education_id")]
        public virtual Education education { get; set; }

        /// <summary>
        /// алкоголь
        /// </summary>
        public string alcohol { get; set; }

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
        public string pastIllnes { get; set; }

        /// <summary>
        ////травмы
        /// </summary>
        public string injuries { get; set; }

        /// <summary>
        //// операции
        /// </summary>
        public string operations { get; set;}

        /// <summary>
        ////вид спорта
        /// </summary>
        public int? sports_id { get; set; }
        [ForeignKey("sports_id")]
        public virtual Sports Sports { get; set; }
        
        /// <summary>
        ////разряд
        /// </summary>
        public int?  rank_id { get; set; }
        [ForeignKey("rank_id")]
        public virtual Rank rank { get; set; }
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
