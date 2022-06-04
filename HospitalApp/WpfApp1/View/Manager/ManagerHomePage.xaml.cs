using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Model;
using WpfApp1.View.Manager.Drugs;
using WpfApp1.View.Manager.Equipment;
using WpfApp1.View.Manager.Rooms;
using WpfApp1.View.Manager.SurveysWindows;
using WpfApp1.ViewModel;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Pdf.Graphics;
using System.ComponentModel;
using Syncfusion.Pdf.Tables;
using System.Data;
using Syncfusion.DocToPDFConverter;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Controller;
using Syncfusion.Pdf;

namespace WpfApp1.View.Manager
{
    /// <summary>
    /// Interaction logic for ManagerHomePage.xaml
    /// </summary>
    public partial class ManagerHomePage : UserControl
    {
        public static ManagerHomePage managerHomePageInstance = null;
        public ManagerHomePage()
        {
            InitializeComponent();
            
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            DrugsWindow.SelectedDrug = null;
            RoomsWindowViewModel.SelectedRoom = null;
        }

        public static ManagerHomePage GetManagerHomePage()
        {
            if(managerHomePageInstance == null)
            {
                managerHomePageInstance = new ManagerHomePage();
            }

            return managerHomePageInstance;
        }

        private void Button_Click_Rooms(object sender, RoutedEventArgs e)
        {
            this.Content = RoomsWindow.GetRoomsWindow();   
        }

        private void Button_Click_Equipment(object sender, RoutedEventArgs e)
        {
            this.Content = new AllEquipment();   
        }

        private void MenuItem_SchedulingRenovation(object sender, RoutedEventArgs e)
        {
            this.Content = new BasicRenovation1(null, null);
           
        }

        private void MenuItem_DownloadReport(object sender, RoutedEventArgs e)
        {
            using (WordDocument document = new WordDocument())
            {
                //Adding a new section to the document.
                WSection section = document.AddSection() as WSection;
                //Set Margin of the section
                section.PageSetup.Margins.All = 20;

                WParagraphStyle style = document.AddParagraphStyle("Normal") as WParagraphStyle;
                style.CharacterFormat.FontName = "Calibri";
                style.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Justify;
                style.CharacterFormat.FontSize = 11f;
                style.ParagraphFormat.AfterSpacing = 8;
                style.ParagraphFormat.FirstLineIndent = 36f;

                style = document.AddParagraphStyle("Heading 1") as WParagraphStyle;
                style.ApplyBaseStyle("Normal");
                style.CharacterFormat.FontName = "Calibri Light";
                style.CharacterFormat.FontSize = 16f;
                style.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(46, 116, 181);

                IWParagraph paragraph = section.AddParagraph();
                paragraph.ApplyStyle("Heading 1");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                paragraph.ParagraphFormat.AfterSpacing = 10;
                WTextRange textRange = paragraph.AppendText("\nIzve\u0161taj stanja opreme Zdravo Korporacije") as WTextRange;
                textRange.CharacterFormat.FontSize = 18f;
                textRange.CharacterFormat.FontName = "Calibri";
                string text =
                " Datum kreiranja izve\u0161taja: " + DateTime.Now.ToShortDateString() + "\n Vreme kreiranja izve\u0161taja: " + DateTime.Now.ToShortTimeString();
                //Appends paragraph.
                paragraph = section.AddParagraph();
                textRange = paragraph.AppendText(text) as WTextRange;

                EquipmentController equipmentController = new EquipmentController();
                List<Model.Equipment> equipment = equipmentController.GetAll();
                // Adding a new Table
                WTable table = section.AddTable() as WTable;
                table.TableFormat.Paddings.All = 2;
                table.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                // Inserting rows to the table.
                table.ResetCells(equipment.Count + 2, 4);

                //Appends paragraph with header.
                IWParagraph paragraphTable = table[0, 0].AddParagraph();

                paragraphTable = table[0, 1].AddParagraph();
                paragraphTable.AppendText("Name");

                paragraphTable = table[0, 2].AddParagraph();
                paragraphTable.AppendText("Room");

                paragraphTable = table[0, 3].AddParagraph();
                paragraphTable.AppendText("Quantity");


                // Dodavnje kroz for petlju
                for (int red = 1; red < equipment.Count + 1; red++)
                {
                    int kolona = 0;
                    int indexElementaNiza = red - 1;

                    paragraphTable = table[red, kolona++].AddParagraph();
                    paragraphTable.AppendText(red.ToString());

                    paragraphTable = table[red, kolona++].AddParagraph();
                    paragraphTable.AppendText(equipment[indexElementaNiza].Name);

                    paragraphTable = table[red, kolona++].AddParagraph();
                    paragraphTable.AppendText(equipment[indexElementaNiza].Room.Id);

                    paragraphTable = table[red, kolona++].AddParagraph();
                    paragraphTable.AppendText(equipment[indexElementaNiza].Quantity.ToString());
                }

                int redova = equipment.Count + 1;
                table[redova, 0].CellFormat.HorizontalMerge = CellMerge.Start;
                for (int kolona = 1; kolona < 4; kolona++)
                {
                    table[redova, kolona].CellFormat.HorizontalMerge = CellMerge.Continue;
                }

                //Apply built-in table style to the table.
                table.ApplyStyle(BuiltinTableStyle.MediumShading1Accent1);

                //Creates an instance of the DocToPDFConverter
                DocToPDFConverter converter = new DocToPDFConverter();
                //Converts Word document into PDF document
                PdfDocument pdfDocument = converter.ConvertToPDF(document);

                //Save and close the PDF document 
                pdfDocument.Save("C:\\Users\\smvul\\Desktop\\simssss\\SIMS-Projekat\\HospitalApp\\IzvestajOpreme.pdf");
                pdfDocument.Close(true);
                //Close the document
                document.Save("C:\\Users\\smvul\\Desktop\\simssss\\SIMS-Projekat\\HospitalApp\\IzvestajOpreme.docx");
                document.Close();
            }

            new SuccessfulActionWindow("Equipment report successfully created");
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            App.CheckNotification = true;
            this.Content = new Login();
        }

        private void MenuItem_Drugs(object sender, RoutedEventArgs e)
        {
            this.Content = new DrugsWindow();
            
        }

        private void MenuItem_SchedulingMerge(object sender, RoutedEventArgs e)
        {
            this.Content = new MergeRooms1(null, null, null, RoomType.Warehouse);
        }

        private void MenuItem_SchedulingSplit(object sender, RoutedEventArgs e)
        {
            this.Content = new SplitRooms1(null, null, RoomType.ExaminationRoom, null, RoomType.ExaminationRoom);
            
        }

        private void Button_Click_Hospital(object sender, RoutedEventArgs e)
        {
            this.Content = new HospitalSurveysCategories();
        }

        private void Button_Click_Doctors(object sender, RoutedEventArgs e)
        {
            ChooseDoctor chooseDoctor = new ChooseDoctor();
            chooseDoctor.ShowDialog();
        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerProfile();
        }
    }
}
