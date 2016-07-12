using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthletesAccounting.DataBase
{
    public class Sports : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _sport;

        public string sport
        {
            get
            {
                return _sport;
            }
            set
            {
                _sport = value;
                OnPropertyChanged("sport");
            }
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sports_code { get; set; }

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