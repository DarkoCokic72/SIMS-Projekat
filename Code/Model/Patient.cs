/***********************************************************************
 * Module:  Patient.cs
 * Author:  HP LAPTOP
 * Purpose: Definition of the Class Patient
 ***********************************************************************/

using System;

namespace Model
{
   public class Patient : UserAccount
   {
      private string middleName;
      private DateTime dateOfBirth;
      private string bloodGroup;
      
      public System.Collections.Generic.List<PatientExaminationAppointment> patientExaminationAppointment;
      
      /// <summary>
      /// Property for collection of PatientExaminationAppointment
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<PatientExaminationAppointment> PatientExaminationAppointment
      {
         get
         {
            if (patientExaminationAppointment == null)
               patientExaminationAppointment = new System.Collections.Generic.List<PatientExaminationAppointment>();
            return patientExaminationAppointment;
         }
         set
         {
            RemoveAllPatientExaminationAppointment();
            if (value != null)
            {
               foreach (PatientExaminationAppointment oPatientExaminationAppointment in value)
                  AddPatientExaminationAppointment(oPatientExaminationAppointment);
            }
         }
      }
      
      /// <summary>
      /// Add a new PatientExaminationAppointment in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddPatientExaminationAppointment(PatientExaminationAppointment newPatientExaminationAppointment)
      {
         if (newPatientExaminationAppointment == null)
            return;
         if (this.patientExaminationAppointment == null)
            this.patientExaminationAppointment = new System.Collections.Generic.List<PatientExaminationAppointment>();
         if (!this.patientExaminationAppointment.Contains(newPatientExaminationAppointment))
            this.patientExaminationAppointment.Add(newPatientExaminationAppointment);
      }
      
      /// <summary>
      /// Remove an existing PatientExaminationAppointment from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemovePatientExaminationAppointment(PatientExaminationAppointment oldPatientExaminationAppointment)
      {
         if (oldPatientExaminationAppointment == null)
            return;
         if (this.patientExaminationAppointment != null)
            if (this.patientExaminationAppointment.Contains(oldPatientExaminationAppointment))
               this.patientExaminationAppointment.Remove(oldPatientExaminationAppointment);
      }
      
      /// <summary>
      /// Remove all instances of PatientExaminationAppointment from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllPatientExaminationAppointment()
      {
         if (patientExaminationAppointment != null)
            patientExaminationAppointment.Clear();
      }
   
   }
}