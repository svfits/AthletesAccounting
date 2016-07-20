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

        public string weight_evaluation { get; set; }

        /// <summary>
        ////рост стоя
        /// </summary>
        public int height { get; set; }

        public string height_evaluation { get; set; }

        #region Окружность грудной клетки

        /// <summary>
        /// вдох
        /// </summary>
        public int breath { get; set; }

        public string breath_evaluation { get; set; }

        /// <summary>
        ////выдох
        /// </summary>
        public int exhalation { get; set; }

        public string exhalation_evaluation { get; set; }

        /// <summary>
        ///  пауза
        /// </summary>
        public int pause { get; set; }

        public string pause_evaluation { get; set; }

        /// <summary>
        ////размах
        /// </summary>
        public int sweep { get; set; }

        public string sweep_evaluation { get; set; }

        #endregion Окружность грудной клетки

        #region Спирометрия Динаномо-метрия

        /// <summary>
        /// правая кисть
        /// </summary>
        public int rightHand { get; set; }

        public string rightHand_evaluation { get; set; }

        /// <summary>
        /// левая кисть
        /// </summary>
        public int leftHand { get; set; }

        public string leftHand_evaluation { get; set; }

        /// <summary>
        /// становая 
        /// </summary>
        public int stanovaya { get; set; }

        public string stanovaya_evaluation { get; set; }

        #endregion Спирометрия Динаномо-метрия

        #region Данные наружного осмотра

        /// <summary>
        ////Кожа
        /// </summary>
        public string skin { get; set; }

        public string skin_evaluation { get; set; }

        /// <summary>
        /// видимые слизистые
        /// </summary>
        public string visibleMucousMembranes { get; set; }

        public string visibleMucousMembranes_evaluation { get; set; }

        /// <summary>
        /// лимфатическая система
        /// </summary>
        public string lymphaticSystem { get; set; }

        public string lymphaticSystem_evaluation { get; set; }

        /// <summary>
        //  жироотложение
        /// </summary>
        public string fatDeposition { get; set; }

        public string fatDeposition_evaluation { get; set; }

        /// <summary>
        /// мускулатура
        /// </summary>
        public string  musculature { get; set; }

        public string musculature_evaluation { get; set; }

        /// <summary>
        ////сост. груж ворот
        /// </summary>
        public string sosGrugVorot { get; set; }

        public string sosGrugVorot_evaluation { get; set; }

        /// <summary>
        /// грудная клетка
        /// </summary>
        public string thorax { get; set; }

        public string thorax_evaluation { get; set; }

        /// <summary>
        /// спина 
        /// </summary>
        public string back { get; set; }

        public string back_evaluation { get; set; }

        /// <summary>
        ////стопа
        /// </summary>
        public string ream { get; set; }

        public string ream_evaluation { get; set; }

        /// <summary>
        //// ноги
        /// </summary>
        public string foots { get; set; }
        public string foots_evaluation { get; set; }

        #endregion
    }
}
