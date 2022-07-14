using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Controller;
using FileHandler;
using Model;
using Repo;
using Service;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using WpfApp1.Model;
using WpfApp1.View.Manager;

namespace WpfApp1
{

    public partial class AppointmentsWindow : Window
    {
        public static AppointmentsWindow appointmentsWindowInstance;
        public static AppointmentController appointmentController;
        public ObservableCollection<Appointment> Appointments { get; set; }
        Physician physician;
        DateTime startDate;
        DateTime endDate;

        public AppointmentsWindow(Physician physician, DateTime startDate, DateTime endDate)
        {

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            AppointmentFileHandler fileHandler = new AppointmentFileHandler();
            AppointmentRepository repository = new AppointmentRepository(fileHandler);
            AppointmentService service = new AppointmentService(repository);
            appointmentController = new AppointmentController(service);

            this.physician = physician;
            this.startDate = startDate;
            this.endDate = endDate;



            Appointments = new ObservableCollection<Appointment>(appointmentController.GetByPhysician(physician, startDate, endDate));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

                AppointmentFileHandler fileHandler = new AppointmentFileHandler();
                AppointmentRepository repository = new AppointmentRepository(fileHandler);
                AppointmentService service = new AppointmentService(repository);
                AppointmentController appointmentController = new AppointmentController(service);
                List<Appointment> appointment = appointmentController.GetByPhysician(physician,startDate,endDate);
                // Adding a new Table
                WTable table = section.AddTable() as WTable;
                table.TableFormat.Paddings.All = 2;
                table.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                // Inserting rows to the table.
                table.ResetCells(appointment.Count + 2, 4);

                //Appends paragraph with header.
                IWParagraph paragraphTable = table[0, 0].AddParagraph();

                paragraphTable = table[0, 1].AddParagraph();
                paragraphTable.AppendText("Patient");

                paragraphTable = table[0, 2].AddParagraph();
                paragraphTable.AppendText("Physician");

                paragraphTable = table[0, 3].AddParagraph();
                paragraphTable.AppendText("Room");

                paragraphTable = table[0, 3].AddParagraph();
                paragraphTable.AppendText("Date and time");

                paragraphTable = table[0, 3].AddParagraph();
                paragraphTable.AppendText("Type");


                // Dodavnje kroz for petlju
                for (int red = 1; red < appointment.Count + 1; red++)
                {
                    int kolona = 0;
                    int indexElementaNiza = red - 1;

                    paragraphTable = table[red, kolona++].AddParagraph();
                    paragraphTable.AppendText(red.ToString());

                    paragraphTable = table[red, kolona++].AddParagraph();
                    paragraphTable.AppendText(appointment[indexElementaNiza].Patient.ToString());

                    paragraphTable = table[red, kolona++].AddParagraph();
                    paragraphTable.AppendText(appointment[indexElementaNiza].Physician.ToString());

                    paragraphTable = table[red, kolona++].AddParagraph();
                    paragraphTable.AppendText(appointment[indexElementaNiza].Room.Id);

                    //paragraphTable = table[red, kolona++].AddParagraph();
                    //paragraphTable.AppendText(appointment[indexElementaNiza].DateOfAppointment.ToString());

                   // paragraphTable = table[red, kolona++].AddParagraph();
                    //paragraphTable.AppendText(appointment[indexElementaNiza].Type.ToString());
                }

                int redova = appointment.Count + 1;
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
                pdfDocument.Save("D:\\sims\\SIMS-Projekat\\HospitalApp\\IzvestajLekara.pdf");
                pdfDocument.Close(true);
                //Close the document
                document.Save("D:\\sims\\SIMS-Projekat\\HospitalApp\\IzvestajLekara.docx");
                document.Close();
            }

            //new SuccessfulActionWindow("Equipment report successfully created");
        }
    }
    }

