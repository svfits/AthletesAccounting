using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthletesAccounting.DataBase
{
  public  class Athletes : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
        public string adress { get; set; }

        /// <summary>
        /// телефон
        /// </summary>
        private string _telefon;

        public string telefon
        {
            get { return _telefon; }

            set
            {
                _telefon = value;
                OnPropertyChanged("telefon");             
            }
        }     

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

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
        public int? rank_code { get; set; }
        [ForeignKey("rank_code")]
        public virtual Rank Rank { get; set; }

        /// <summary>
        ////дата рождения
        /// </summary>
        public DateTime DOB { get; set; }

        /// <summary>
        ///  основной вид спрота дата начала
        /// Каким видом спорта преимущественно занимается 
        /// сколько времени
        ///// </summary>
        public int? mainSport_id { get; set; }
        [ForeignKey("mainSport_id")]
        public virtual MainSport mainSport { get; set; }

        /// <summary>
        ////другие виде спорта
        /// Какими другими видами спорта занимался 
        /// </summary>
        public string otherSports { get; set; }

        /// <summary>
        ////  По каким видам спорта участвовал в соревнованиях 
        /// </summary>
        public string sportsGame { get; set; }

        /// <summary>
        /// Разряд дата получения каждого разряда,
        /// </summary>
        public int? rankDateGet_id { get; set; }
        [ForeignKey("rankDateGet_id")]
        public virtual RankDateGet rankDateGet { get; set; }

      
    }
  
}
