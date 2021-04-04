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
            Allergies = new AllergyAssessement ();
            ChronicMedicalData = new ChronicMedicalHistory ();
            TobaccoInfo = new TobaccoHistory ();
            AlcoholInfo = new AlcoholHistory ();
        }

        public TermData TermInfo { get; set; }
        public FertilityTreatmentData FertilityInfo { get; set; }
        public PrenatalRiskAssessment RiskAssessment { get; set; }
        public WorkEnvironmentEffect WorkEnvironment { get; set; }
        public AllergyAssessement Allergies { get; set; }
        public ChronicMedicalHistory ChronicMedicalData { get; set; }
        public string Medicin { get; set; } = string.Empty;
        public MMRVaccinationStatus MMRVaccinated { get; set; }
        public string PastAdmittance { get; set; } = string.Empty;
        public TobaccoHistory TobaccoInfo { get; set; }
        public AlcoholHistory AlcoholInfo { get; set; }
        public bool OtherDrugs { get; set; }
        public string OtherDrugsComment { get; set; } = string.Empty;
        public string DietAndActivity { get; set; } = string.Empty;
    }
}
