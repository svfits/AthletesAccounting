using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AthletesAccounting.DataBase
{
  public  class Athletes : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _fam,_name,_parent,_sex,_adress,_telefon, _PlaceofStudyAndWork, _livingСonditions , _profAthlets , _alcohol, _housing ;
        DateTime _DateGreate;

        [Key]
        public int id { get; set; }

        /// <summary>
        /// фамилия
        /// </summary>
        public string fam
        {
            get
            {
                return _fam;
            }
            set
            {
                _fam = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        ////имя
        /// </summary>
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }
    
        /// <summary>
        /// отчество
        /// </summary>
        public string parent
        {
            get
            {
                return _parent;
            }
           set
            {
                _parent = value;
                NotifyPropertyChanged();
            }
        }   
           
        /// <summary>
        /// пол
        /// </summary>
        public string sex
        {
            get
            {
                return _sex;
            }
           set
            {
                _sex = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        ////адрес где проживает
        /// </summary>
        public string adress
        {
            get
            {
                return _adress;
            }
                set
            {
                _adress = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// телефон
        /// </summary>    
        public string telefon
        {
            get { return _telefon; }

            set
            {
                _telefon = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        ////обновим данные на форме
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
     
        /// <summary>
        /// место учебы или работы
        /// </summary>     
        public string PlaceofStudyAndWork
        {
            get
            { return _PlaceofStudyAndWork; }
                set
            {
                _PlaceofStudyAndWork = value;
                NotifyPropertyChanged();
            }
        }     
        
        /// <summary>
        /// жилищные условия
        /// </summary>
        public string livingСonditions
        {
            get
            {
                return _livingСonditions;
            }
                set
            {
                _livingСonditions = value;
                NotifyPropertyChanged();
            }
        }
        
        /// <summary>
        ////Спортколлектив ДЮСШ
        /// </summary>
        public int? sportTeam_code { get; set; }
        [ForeignKey("sportTeam_code")]
        public virtual SportTeam SportTeam { get; set; }

        /// <summary>
        /// профессия спортсмена
        /// </summary>
        public string profAthlets
        {
            get
            {
                return _profAthlets;
            }
            set
            {
                _profAthlets = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        ////образование
        /// </summary>
        public int? education_code { get; set; }
        [ForeignKey("education_code")]
        public virtual Education education { get; set; }

        /// <summary>
        /// алкоголь
        /// </summary>
        public string alcohol
        {
            get
            {
                return _alcohol;
            }

            set
            {
                _alcohol = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        ////жилищные условия
        /// </summary>
        public string housing
        {
            get
            {
                return _housing;
            }
            set
            {
                _housing = value;
                NotifyPropertyChanged();
            }
        }

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
        public int? sport_code { get; set; }
        [ForeignKey("sport_code")]
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
        public virtual MainSport MainSport { get; set; }

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
        public string rankDateGet { get; set; }
      
        /// <summary>
        /// дата заполнения карточки
        /// </summary>
        public DateTime DateGreate
        {
            get
            {
                return _DateGreate;
            }
            set
            {
                _DateGreate = value;
                NotifyPropertyChanged();
            }
        }

        public string notes { get; set; }

        /// <summary>
        /// дата следующей диспансеризация
        /// </summary>
        public DateTime? dateTimeNextProbe {get;set;}

        public int? id_AnthropometricData { get; set; }
        [ForeignKey("id_AnthropometricData")]
        public virtual AnthropometricData AnthropometricData { get; set; }

    }

}
