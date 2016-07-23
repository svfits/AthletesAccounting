using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthletesAccounting.DataBase
{
    public class Couch : INotifyPropertyChanged
    {
        private string _fam;
        private string _name;
        private string _parent;

        public event PropertyChangedEventHandler PropertyChanged;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_couch { get; set; }

        public string fam
        {
            get
            {
                return _fam;
            }
            set
            {
                _fam = value;
                OnPropertyChanged("Couch");
            }
        }

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Couch");
            }
        }

        public string parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
                OnPropertyChanged("Couch");
            }
        }

        public int sport_code { get; set; }
        [ForeignKey("sport_code")]
        public virtual Sports Sports { get; set; }

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