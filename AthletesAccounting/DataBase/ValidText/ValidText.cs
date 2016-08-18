using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthletesAccounting.DataBase
{
    /// <summary>
    ////класс предназначенный для проверки того что ввел пользователь
    /// </summary>
    public class ValidText
    {
        /// <summary>
        /// проверим язык ввода. удалим лишний пробел 
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string  textUpperandTrim(string txt)
        {
            txt = txt.TrimStart();
            txt = char.ToUpper(txt[0]) + txt.Substring(1).ToLower();
            System.Text.StringBuilder sb = new System.Text.StringBuilder(txt);

            string _tempStr = "";
            
            for (int i=0; i < sb.Length ;i++)
            {
                if (( sb[i] >= 'а' && sb[i] <= 'я' ) || (sb[i] >= 'А' && sb[i] <= 'Я') || (sb[i] == ' ' ))
                {
                    _tempStr = _tempStr + sb[i];
                }
                else
                {
                   return "Только русские буквы";
                }
            }
                       
            return _tempStr;
        }
    }
}
