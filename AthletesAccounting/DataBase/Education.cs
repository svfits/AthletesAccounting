
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthletesAccounting.DataBase
{
    public class Education : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _education;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int education_code { get; set; }
             
        public string education {
            get
            {
                return _education;
            }
            set
            {
                _education = value;
                OnPropertyChanged("education");
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

    }
}