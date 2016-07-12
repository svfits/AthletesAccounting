using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthletesAccounting.DataBase
{
    public class SportTeam : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _sportTeam;

        public string sportTeam
        {
            get
            {
                return _sportTeam;
            }
            set
            {
                _sportTeam = value;
                OnPropertyChanged("sportTeam");
            }
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sportTeam_code { get; set; }
              

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