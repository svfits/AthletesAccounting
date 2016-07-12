using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthletesAccounting.DataBase
{
    public class Rank : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _rank;

        public string rank
        {
            get
            {
                return _rank;
            }
            set
            {
                _rank = value;
                OnPropertyChanged("rank");
            }
        }

       
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rank_code { get; set; }

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