﻿using System;
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
using WpfApp1.Model;

namespace WpfApp1
{

    public partial class MedicalRecordWindow : Window
    {
        public static MedicalRecordWindow medicalRecordWindowInstance;
        public MedicalRecordController medicalRecordController;
        public ObservableCollection<MedicalRecord> MedicalRecords { get; set; }

        public MedicalRecordWindow()
        {

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            MedicalRecordFileHandler fileHandler = new MedicalRecordFileHandler();
            MedicalRecordRepository repository = new MedicalRecordRepository(fileHandler);
            MedicalRecordService service = new MedicalRecordService(repository);
            medicalRecordController = new MedicalRecordController(service);

            MedicalRecords = new ObservableCollection<MedicalRecord>(medicalRecordController.GetAll());
        }

        public static MedicalRecordWindow GetMedicalRecordWindow()
        {
            if (medicalRecordWindowInstance == null)
            {
                medicalRecordWindowInstance = new MedicalRecordWindow();

            }

            return medicalRecordWindowInstance;
        }

        public void refreshContentOfGrid()
        {
            dgMedicalRecords.ItemsSource = null;
            dgMedicalRecords.ItemsSource = medicalRecordController.GetAll();

        }

        public MedicalRecord getSelectedMedicalRecord()
        {
            return (MedicalRecord)dgMedicalRecords.SelectedItem; ;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            MedicalRecord medicalRecord = getSelectedMedicalRecord();
            if (!btn.Content.Equals("Create") && medicalRecord == null)
            {
                MessageBox.Show("You need to select a row!", "Error");
                return;
            }


            if (btn.Content.Equals("Create"))
            {
                this.Close();
                CreateMedicalRecord createMedicalRecord = new CreateMedicalRecord();
                createMedicalRecord.ShowDialog();
            }
            else if (btn.Content.Equals("Edit"))
            {
                //this.Close();
                MedicalRecordEdit medicalRecordEdit = new MedicalRecordEdit(medicalRecord);
                medicalRecordEdit.ShowDialog();

            }
            else if (btn.Content.Equals("Delete"))
            {
                MedicalRecordDelete medicalRecordDelete = new MedicalRecordDelete();
                medicalRecordDelete.ShowDialog();
            }

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            medicalRecordWindowInstance = null;
        }

    }
}
