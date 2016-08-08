using AthletesAccounting.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AthletesAccounting.ImportExport
{
  public  class ExportPatientСard
    {
        private string _dirCard, _fam, _name, _parent;
        
        public ExportPatientСard(int? id)
        {
           getDirCard(id);

            #region сохранение шаблона в БД         

            string filename = @"C:\Users\afanasievdv\Downloads\шаблон формы 061у.doc";

            string templateFileName = "шаблон формы для печати";

            byte[] imageData;
            using (System.IO.FileStream fs = new System.IO.FileStream(filename, FileMode.Open))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
            }

            using (UserContext db = new UserContext())
            {
                DataBase.Templates template = new DataBase.Templates
                {
                    templateFilename = templateFileName,
                    template = imageData,
                    notesTemplate = "примечание"
                };

                db.Templates.Add(
                    template
                    );
                db.SaveChanges();
            }

            #endregion сохранение шаблона

            #region извлечение из БД
            using (UserContext db = new UserContext())
            {
                var result = db.Templates.FirstOrDefault().template;

                using (System.IO.FileStream fs = new System.IO.FileStream("шаблон.doc", FileMode.OpenOrCreate))
                {
                    fs.Write(result, 0, result.Length);

                }

            }
            #endregion извлечение из БД

            try
            {
                var wordApp = new Microsoft.Office.Interop.Word.Application();
                var wordDoc = wordApp.Documents.Add(
                    @"\\isea.ru\Homes\Employee\afanasievdv\My Documents\Visual Studio 2015\Projects\AthletesAccounting\AthletesAccounting\bin\Debug\шаблон.doc"
                         );

                ReplaceStub("{date}", DateTime.Now.ToString("yyyy/MM/dd"), wordDoc); //Заменяем метку на данные из формы(здесь конкретно из текстбокса с именем textBox_fio)
                                                                                   ///Может быть много таких меток
                object SaveAsFile = (object)@_dirCard  + "\\" + _fam + " " + _name + " " + _parent;

                wordDoc.SaveAs2(SaveAsFile);
                wordDoc.Close();

                System.Diagnostics.Process.Start(@_dirCard  + "\\" + _fam + " " + _name + " " + _parent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getDirCard(int? id)
        {
           
            using (UserContext db = new UserContext())
            {
                var result = db.Settings.FirstOrDefault().HomeDirCard;

                var result1 = db.Athletes                           
                            .AsEnumerable()
                            .Where(c => c.id == id)
                            .FirstOrDefault()
                            ;
                _name = result1.name;
                _fam = result1.fam;
                _parent = result1.parent;
            }

            _dirCard = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Карты спортсменов");
            if (!Directory.Exists(_dirCard))
            {
                DirectoryInfo di = Directory.CreateDirectory(_dirCard);

            }         

        }

        public ExportPatientСard(int athletesAddorUpdate)
        {
            //this.athletesAddorUpdate = athletesAddorUpdate;
        }

        private void ReplaceStub(string stubToReplace, string text, Microsoft.Office.Interop.Word.Document worldDocument)
        {
            var range = worldDocument.Content;
            range.Find.ClearFormatting();
            object wdReplaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text, Replace: wdReplaceAll);
        }
    }
}
