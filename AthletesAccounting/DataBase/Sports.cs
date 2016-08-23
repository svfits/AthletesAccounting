using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace AthletesAccounting.DataBase
{
    public class Sports : INotifyPropertyChanged,IEditableObject
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _sport_code;
        private string _sport;     
     
        public string sport
        {
            get
            {
                return _sport;
            }
            set
            {
                string txt = value;              

                try
                {
                    ValidText dd = new ValidText();
                    txt = dd.textUpperandTrim(txt);

                    _sport = txt;
                    NotifyPropertyChanged();
                }
                catch
                {

                    NotifyPropertyChanged();
                }            
            }
        }
     
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sports_code
        {
            get
            {
                return _sport_code;
            }
            set
            {           
                _sport_code = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region IEditableObject
        public void BeginEdit()
        {
            return;
        }

        public void EndEdit()
        {
            return;
        }

        public void CancelEdit()
        {
            sport = _sport;
        }

        #endregion IEditableObject
    }
}