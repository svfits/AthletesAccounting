
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace AthletesAccounting.DataBase
{
    public class Education : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        public int education_id { get; set; }

        private string _education;
        public string education {
            get { return _education; }
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