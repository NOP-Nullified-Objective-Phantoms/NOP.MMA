using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Represents a medical history for a patient
    /// </summary>
    internal class Anamnese : IAnamnese
    {
        public Anamnese ()
        {
            TermInfo = new TermData ();
            FertilityInfo = new FertilityTreatmentData ();
            RiskAssessment = new PrenatalRiskAssessment ();
            WorkEnvironment = new WorkEnvironmentEffect ();
            Allergies = new AllergyAssessment ();
            ChronicMedicalData = new ChronicMedicalHistory ();
            TobaccoInfo = new TobaccoHistory ();
            AlcoholInfo = new AlcoholHistory ();
        }

        public TermData TermInfo { get; }
        public FertilityTreatmentData FertilityInfo { get; }
        public PrenatalRiskAssessment RiskAssessment { get; }
        public WorkEnvironmentEffect WorkEnvironment { get; }
        public AllergyAssessment Allergies { get; }
        public ChronicMedicalHistory ChronicMedicalData { get; }
        public string Medicin { get; set; }
        public MMRVaccinationStatus MMRVaccinated { get; set; }
        public string PastAdmittance { get; set; }
        public TobaccoHistory TobaccoInfo { get; }
        public AlcoholHistory AlcoholInfo { get; }
        public bool OtherDrugs { get; set; }
        public string OtherDrugsComment { get; set; }
        public string DietAndActivity { get; set; }
    }
}
