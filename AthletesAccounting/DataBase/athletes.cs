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
        public int Id { get; set; }
        /// <summary>
        ////имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// фамилия
        /// </summary>
        public string Fam { get; set; }
        /// <summary>
        /// отчество
        /// </summary>
        public string parent { get; set; }
        /// <summary>
        /// возраст
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        ////адресс где проживает
        /// </summary>
        public string Adress {get; set;}

        public string Telefon { get; set; }
        /// <summary>
        /// место учебы 
        /// </summary>
        public string Place_Study { get;set;}
        [ForeignKey("id")]        
        public virtual PlaceofStudy PlaceofStudy { get;set;}
        /// <summary>
        ////место работы 
        /// </summary>
        public string Place_Work { get; set; }
        [ForeignKey("id")]
        public virtual PlaceofWork PlaceofWork { get; set; }
        /// <summary>
        ////перенесенные заболевания 
        /// </summary>
        public string Past_Illnesses { get; set; }
        [ForeignKey("id")]
        public virtual PastIllnesses PastIllnesses { get; set; }
        /// <summary>
        ////травмы
        /// </summary>
        public string _Injury { get; set; }
        [ForeignKey("id")]
        public virtual Injury Injury { get; set; }
        /// <summary>
        //// операции
        /// </summary>
        public string _Operations { get; set; }
        [ForeignKey("id")]
        public virtual Operations Operations { get; set; }
        /// <summary>
        ////вид спорта
        /// </summary>
        public string _Sports { get; set; }
        [ForeignKey("id")]
        public virtual Sports Sports { get; set; }
        /// <summary>
        ////разряд
        /// </summary>
        public string _Rank { get; set; }
        [ForeignKey("id")]
        public virtual Rank Rank { get; set; }
    }
}
