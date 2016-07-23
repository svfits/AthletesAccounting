using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

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
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
            }
        }

        public int sport_code { get; set; }
        [ForeignKey("sport_code")]
        public virtual Sports Sports { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}