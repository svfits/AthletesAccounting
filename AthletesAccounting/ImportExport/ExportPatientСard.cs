using AthletesAccounting.DataBase;
using AthletesAccounting.DataBase.Settings;
using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace AthletesAccounting.ImportExport
{
    public  class ExportPatientСard
    {      
        private Athletes _athletes = new Athletes();
        private Settings _settings = new Settings();
        
        public ExportPatientСard(int? id)
        {
           getDirCard(id);
           string _dirCard = Path.Combine(_settings.homeDirCard, "Карты спортсменов");

            loadTemlateinBD();
            templateFromBD();
            
            try
            {
                var wordApp = new Microsoft.Office.Interop.Word.Application();
                var wordDoc = wordApp.Documents.Add(
                    @"\\isea.ru\Homes\Employee\afanasievdv\My Documents\Visual Studio 2015\Projects\AthletesAccounting\AthletesAccounting\bin\Debug\шаблон.docx"
                         );
                #region замена в шаблоне меток на то что надо 

                ReplaceStub("{date}", _athletes.DateGreate.ToString("yyyy/MM/dd"), wordDoc);
                ReplaceStub("{наименование учреждения}", _settings.nameOrg, wordDoc);
                ReplaceStub("{спортколлектив}", _athletes.SportTeam.sportTeam, wordDoc);
                ReplaceStub("{вид спорта}", _athletes.Sports.sport, wordDoc);
                ReplaceStub("{фамилия}", _athletes.fam, wordDoc);
                ReplaceStub("{имя}", _athletes.name, wordDoc);
                ReplaceStub("{отчество}", _athletes.parent, wordDoc);
                ReplaceStub("{дата рождения}", _athletes.DOB.ToString("yyyy/MM/dd"), wordDoc);
                ReplaceStub("{пол}", _athletes.sex, wordDoc);
                ReplaceStub("{домашний адрес}", _athletes.adress, wordDoc);
                ReplaceStub("{телефон}", _athletes.telefon, wordDoc);
                ReplaceStub("{место работы}", _athletes.PlaceofStudyAndWork, wordDoc);
                ReplaceStub("{профессия должность}", _athletes.profAthlets, wordDoc);
                ReplaceStub("{образование}", _athletes.education.education, wordDoc);
                ReplaceStub("{жилищные условия}", _athletes.livingСonditions, wordDoc);
                ReplaceStub("{пищевой режим}", _athletes.telefon, wordDoc);
                ReplaceStub("{болезни}", _athletes.pastIllnes, wordDoc);
                ReplaceStub("{травмы}", _athletes.injuries, wordDoc);
                ReplaceStub("{операции}", _athletes.operations, wordDoc);
                ReplaceStub("{употребление алкоголя}", _athletes.alcohol, wordDoc);
                ReplaceStub("{курение}", _athletes.smoke, wordDoc);
               
                ReplaceStub("{12}", _athletes.MainSport.Sports.sport, wordDoc);
                ReplaceStub("{13}",/* _athletes.MainSport.dateOnSports.ToString("yyyy/MM/dd")*/ (DateTime.Now.Year - _athletes.MainSport.dateOnSports.Year).ToString(), wordDoc);
                ReplaceStub("{14}", _athletes.otherSports, wordDoc);
                ReplaceStub("{15}", _athletes.sportsGame, wordDoc);
                ReplaceStub("{16}", _athletes.rankDateGet, wordDoc);


                //_athletes.DateGreate.ToString()    _athletes.DateGreate.ToString() DateTime.Now.ToString("yyyy/MM/dd")

                #endregion замена в шаблоне меток на то что надо

                object SaveAsFile = (object)@_dirCard  + "\\" + _athletes.fam + " " + _athletes.name + " " + _athletes.parent;

                wordDoc.SaveAs2(SaveAsFile);
                wordDoc.Close();
                string ss = @_dirCard + "\\" + _athletes.fam + " " + _athletes.name + " " + _athletes.parent + ".docx";
                System.Diagnostics.Process.Start(ss.ToString());
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
                _settings = db.Settings.FirstOrDefault();

                _athletes = db.Athletes                              
                           .Include("Sports")
                           .Include("SportTeam")
                           .Include("Rank")
                           .Include("Education")
                           .Include("MainSport")
                           .AsEnumerable()
                           .Where(c => c.id == id)
                           .FirstOrDefault()
                           ;
              
                if (!Directory.Exists(_settings.homeDirCard))
                {
                    DirectoryInfo di = Directory.CreateDirectory(_settings.homeDirCard);
                }

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

        private void loadTemlateinBD()
        {                
            string filename = @"\\isea.ru\Homes\Employee\afanasievdv\My Documents\Карты спортсменов\шаблон формы 061у.docx";

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
                    notesTemplate = "шаблон для распечатки карточек спортсменов"
                };
                var conn = db.Templates.FirstOrDefault();
                if (conn == null)
                {
                    db.Templates.Add(
                                      template
                                      );
                    db.SaveChanges();
                    return;
                }

                conn.notesTemplate = "шаблон для распечатки карточек спортсменов";
                conn.template = imageData;
                conn.templateFilename = templateFileName;
                db.Entry(conn).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

        }

       private void templateFromBD()
        {          
            using (UserContext db = new UserContext())
            {
                var result = db.Templates.FirstOrDefault().template;

                using (System.IO.FileStream fs = new System.IO.FileStream("шаблон.docx", FileMode.OpenOrCreate))
                {
                    fs.Write(result, 0, result.Length);
                }
            }            
        }
    }
}
