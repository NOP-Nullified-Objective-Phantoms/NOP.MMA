using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public interface IAnamnese
    {
        TermData TermInfo { get; }
        FertilityTreatmentData FertilityInfo { get; }
        PrenatalRiskAssessment RiskAssessment { get; }
        WorkEnvironmentEffect WorkEnvironment { get; }
        AllergyAssessment Allergies { get; }
        ChronicMedicalHistory ChronicMedicalData { get; }
        string Medicin { get; set; }
        MMRVaccinationStatus MMRVaccinated { get; set; }
        string PastAdmittance { get; set; }
        TobaccoHistory TobaccoInfo { get; }
        AlcoholHistory AlcoholInfo { get; }
        bool OtherDrugs { get; set; }
        string OtherDrugsComment { get; set; }
        string DietAndActivity { get; set; }
    }
}