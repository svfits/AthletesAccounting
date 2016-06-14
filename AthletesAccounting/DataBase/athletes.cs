using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthletesAccounting.DataBase
{
  public  class athletes
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
        public string PlaceofStudy {get;set;}
              /// <summary>
              ////место работы 
              /// </summary>
        public string PlaceofWork { get; set; }
          /// <summary>
          ////перенесенные заболевания 
          /// </summary>
        public string PastIllnesses { get; set; }
        /// <summary>
        ////травмы
        /// </summary>
        public string Injury { get; set; }
        /// <summary>
        //// операции
        /// </summary>
        public string Operations { get; set; }
        /// <summary>
        ////вид спорта
        /// </summary>
        public string Sports { get; set; }

        /// <summary>
        ////разряд
        /// </summary>
        public string Rank { get; set; }
    }
}
