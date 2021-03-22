using NOP.MMA.Core.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Represents the medical history of an <see cref="IPatient"/>
    /// </summary>
    public interface IAnamnese
    {
        /// <summary>
        /// The expected date of birth
        /// </summary>
        TermData TermInfo { get; set; }
        /// <summary>
        /// The information about fertility treatment
        /// </summary>
        FertilityTreatmentData FertilityInfo { get; set; }
        /// <summary>
        /// The prenatal risk assessement
        /// </summary>
        PrenatalRiskAssessment RiskAssessment { get; set; }
        /// <summary>
        /// The information about the <see cref="IPatient"/>s work environment
        /// </summary>
        WorkEnvironmentEffect WorkEnvironment { get; }
        /// <summary>
        /// The allergy assessements report
        /// </summary>
        AllergyAssessment Allergies { get; set; }
        /// <summary>
        /// The data about a <see cref="IPatient"/>s chronic health issues
        /// </summary>
        ChronicMedicalHistory ChronicMedicalData { get; set; }
        /// <summary>
        /// The <see cref="IPatient"/>s disposed medicine
        /// </summary>
        string Medicin { get; set; }
        /// <summary>
        /// The <see cref="IPatient"/>s vaccination status
        /// </summary>
        MMRVaccinationStatus MMRVaccinated { get; set; }
        /// <summary>
        /// A summary of past admittances and treatment related to pregnancy
        /// </summary>
        string PastAdmittance { get; set; }
        /// <summary>
        /// Data on a <see cref="IPatient"/> tobacco habits
        /// </summary>
        TobaccoHistory TobaccoInfo { get; set; }
        /// <summary>
        /// Data on a <see cref="IPatient"/> alcohol habits
        /// </summary>
        AlcoholHistory AlcoholInfo { get; set; }
        /// <summary>
        /// Whether or not other drugs where consumed during pregnancy
        /// </summary>
        bool OtherDrugs { get; set; }
        /// <summary>
        /// A comment elaborating on the result of the <see cref="OtherDrugs"/> property
        /// </summary>
        string OtherDrugsComment { get; set; }
        /// <summary>
        /// A decribtion of the diet and level of activity of the <see cref="IPatient"/>
        /// </summary>
        string DietAndActivity { get; set; }
    }
}