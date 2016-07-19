using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthletesAccounting.DataBase
{
   public class AnthropometricData
    {
        [Key]
        public int id { get; set; }

        /// <summary>
        ////дата осмотра
        /// </summary>
        public DateTime dateGreate { get; set; }

        /// <summary>
        /// возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        ////оценка для детей и подростков до 17 лет включительно
        /// </summary>
        public int evaluation { get; set; }

        /// <summary>
        //// вес
        /// </summary>
        public int weight { get; set; }

        /// <summary>
        ////рост стоя
        /// </summary>
        public int height { get; set; }

        #region Окружность грудной клетки

        /// <summary>
        /// вдох
        /// </summary>
        public int breath { get; set; }

        /// <summary>
        ////выдох
        /// </summary>
        public int exhalation { get; set; }

        /// <summary>
        ///  пауза
        /// </summary>
        public int pause { get; set; }

        /// <summary>
        ////размах
        /// </summary>
        public int sweep { get; set; }

        #endregion Окружность грудной клетки

        #region Спирометрия Динаномо-метрия

        /// <summary>
        /// правая кисть
        /// </summary>
        public int rightHand { get; set; }

        /// <summary>
        /// левая кисть
        /// </summary>
        public int leftHand { get; set; }

        /// <summary>
        /// становая 
        /// </summary>
        public int stanovaya { get; set; }

        #endregion Спирометрия Динаномо-метрия
    }
}
