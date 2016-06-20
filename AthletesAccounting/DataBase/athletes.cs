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
        /// возраст
        /// </summary>
        public int age { get; set; }
        /// <summary>
        ////адресс где проживает
        /// </summary>
        public string adress {get; set;}

        public string telefon { get; set; }
        /// <summary>
        /// место учебы 
         /// </summary>
        public int? placeStudy { get; set; }
        //[ForeignKey("id")]
        public virtual PlaceofStudy PlaceofStudy { get; set; }
        /// <summary>
        ////место работы 
        /// </summary>
        public int? placeWork { get; set; }
        //[ForeignKey("id")]
        public virtual PlaceofWork PlaceofWork { get; set; }
        /// <summary>
        ////перенесенные заболевания 
            /// </summary>
        public int? pastIllnesses { get; set; }
        //[ForeignKey("id")]
        public virtual PastIllness PastIllness { get; set; }
        /// <summary>
        ////травмы
        /// </summary>
        public int? injury { get; set; }
        //[ForeignKey("id")]
        public virtual Injuries Injuries { get; set; }
        /// <summary>
        //// операции
        /// </summary>
        public int? operations { get; set; }
        //[ForeignKey("id")]
        public virtual Operations Operations { get; set; }
        /// <summary>
        ////вид спорта
        /// </summary>
        public int? sports { get; set; }
        //[ForeignKey("id")]
        public virtual Sports Sports { get; set; }
        /// <summary>
        ////разряд
        /// </summary>
        public int? rank { get; set; }
        //[ForeignKey("id")]
        public virtual Rank Rank { get; set; }        
        /// <summary>
        ////дата рождения
        /// </summary>
        public DateTime DOB { get; set; }         
    }
}
