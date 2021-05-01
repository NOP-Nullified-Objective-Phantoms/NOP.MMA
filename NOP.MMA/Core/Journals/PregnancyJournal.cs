using NOP.MMA.Core.Patients;
using NOP.MMA.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Represents a <see cref="Journal"/> extended to include information about an <see cref="IPatient"/>s pregnancy history
    /// </summary>
    internal class PregnancyJournal : Journal, IPregnancyJournal
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="PregnancyJournal"/> with its <see langword="default"/> values. An ID will be generated if one is not provided
        /// </summary>
        /// <param name="_id">The ID to assign the new <see cref="IJournal"/> <see langword="object"/></param>
        public PregnancyJournal ( int? _id = null ) : base (_id)
        {
            Pregnancies = new PregnancyHistory ();
            Abortions = new AbortionHistory ();
            Anamnese = new Anamnese ();
            Investegations = new Investigation ();
            ResAndRiskAssessement = new RRAssessement ();
            Pregnancies = new PregnancyHistory ();
            Abortions = new AbortionHistory ();
        }

        public IPregnancyHistory Pregnancies { get; }
        public IAbortionHistory Abortions { get; }
        public IAnamnese Anamnese { get; }
        public IInvestigation Investegations { get; }
        public IResourceAndRiskAssessment ResAndRiskAssessement { get; }

        public override void BuildEntity ( string _data )
        {
            string[] data = _data.Split (Environment.NewLine);

            if ( data.Length - 1 == 6 )
            {
                #region Core Journal data [Line 0]
                string[] coreJournalData = data[ 0 ].Split (",");

                if ( int.TryParse (coreJournalData[ 0 ].Replace ("JournalID", string.Empty), out int _id) && int.TryParse (coreJournalData[ 2 ], out int _journalDest) )
                {
                    if ( int.TryParse (coreJournalData[ 1 ].Replace ("PatientID", string.Empty), out int _patientID) )
                    {
                        ID = _id;
                    }
                    else
                    {
                        Debug.LogWarning ($"Invalid Journal ({ID}) build from storage; No Patient Attached!");
                    }

                    JournalDestination = ( JournalDest ) _journalDest;
                    PatientData = PatientRepo.Link.GetDataByIdentifier (_patientID);
                    JournalDestination = ( JournalDest ) _journalDest;
                }
                else
                {
                    throw new Exception ($"One or more fields couldn't be retrived from: { ( data[ 0 ] ?? "Null" )}");
                }
                #endregion

                if ( PatientData != null )
                {
                    #region Pregnancy History Record [Line 1]
                    string[] pEntries = data[ 1 ].Split (COLITEMSEPERATOR);

                    foreach ( string pEntryDataStream in pEntries )
                    {
                        string[] pEntryData = pEntryDataStream.Split (",");
                        if ( pEntryDataStream != string.Empty )
                        {
                            if ( pEntryData.Length == 10 && bool.TryParse (pEntryData[ 0 ], out bool _bornAlive) && bool.TryParse (pEntryData[ 3 ], out bool _male) && int.TryParse (pEntryData[ 5 ], out int _pregnancyExperience) && bool.TryParse (pEntryData[ 7 ], out bool _stillBorn) && double.TryParse (pEntryData[ 8 ], NumberStyles.AllowDecimalPoint, new CultureInfo ("en-US"), out double _weight) && int.TryParse (pEntryData[ 9 ], out int _year) )
                            {
                                PregnancyHistoryEntry pEntry = new PregnancyHistoryEntry ()
                                {
                                    BornAlive = _bornAlive,
                                    CurrentStatusOfChild = pEntryData[ 1 ].Replace (COMMAIDENTIFIER, ","),
                                    GestationAge = pEntryData[ 2 ].Replace (COMMAIDENTIFIER, ","),
                                    Male = _male,
                                    PlaceOfBirth = pEntryData[ 4 ].Replace (COMMAIDENTIFIER, ","),
                                    PregnancyExperience = ( Experience ) _pregnancyExperience,
                                    PregnancyProgress = pEntryData[ 6 ].Replace (COMMAIDENTIFIER, ","),
                                    StillBorn = _stillBorn,
                                    Weight = _weight,
                                    Year = _year
                                };

                                Pregnancies.AddHistory (pEntry);
                            }
                            else
                            {
                                throw new Exception ($"One or more fields couldn't be retrived from: { ( data[ 1 ] ?? "Null" )}");
                            }
                        }
                    }
                    #endregion

                    #region Abortion History Record [Line 2]
                    string[] aEntries = data[ 2 ].Split (COLITEMSEPERATOR);

                    foreach ( string aEntryDataStream in aEntries )
                    {
                        string[] aEntryData = aEntryDataStream.Split (",");

                        if ( aEntryDataStream != string.Empty )
                        {
                            if ( aEntryData.Length == 3 && int.TryParse (aEntryData[ 2 ], out int _year) )
                            {
                                AbortionHistoryEntry aEntry = new AbortionHistoryEntry ()
                                {
                                    PlannedAbortionGA = aEntryData[ 0 ].Replace (COMMAIDENTIFIER, ","),
                                    UnplannedAbortionGA = aEntryData[ 1 ].Replace (COMMAIDENTIFIER, ","),
                                    Year = _year
                                };

                                Abortions.AddHistory (aEntry);
                            }
                            else
                            {
                                throw new Exception ($"One or more fields couldn't be retrived from: { ( data[ 2 ] ?? "Null" )}");
                            }
                        }
                    }
                    #endregion

                    #region Anamnese [Line 3]
                    string[] anamDataStream = data[ 3 ].Split (OBJECTSEPERATOR);
                    if ( anamDataStream.Length == 14 )
                    {
                        #region Alcohol History [Line 0]
                        string[] alcoHistoryStream = anamDataStream[ 0 ].Split (",");
                        if ( alcoHistoryStream.Length == 3 && int.TryParse (alcoHistoryStream[ 0 ], out int _amountPrWeek) && bool.TryParse (alcoHistoryStream[ 1 ], out bool _duringPregnancy) && bool.TryParse (alcoHistoryStream[ 2 ], out bool _multiplePrSession) )
                        {
                            Anamnese.AlcoholInfo = new AlcoholHistory (_duringPregnancy, _amountPrWeek, _multiplePrSession);
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Anamnese): { ( anamDataStream[ 0 ] ?? "Null" )}");
                        }
                        #endregion

                        #region Allergies [Line 1]
                        string[] allergyStream = anamDataStream[ 1 ].Split (",");
                        if ( allergyStream.Length == 2 && int.TryParse (allergyStream[ 1 ], out int _childAllergyRisk) )
                        {
                            Anamnese.Allergies = new AllergyAssessement (allergyStream[ 0 ].Replace (COMMAIDENTIFIER, ","), ( ChildDisposedAllergy ) _childAllergyRisk);
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Anamnese): { ( anamDataStream[ 1 ] ?? "Null" )}");
                        }
                        #endregion

                        #region Chronic Medical Data [Line 2]
                        string[] chronicDataStream = anamDataStream[ 2 ].Split (",");
                        if ( chronicDataStream.Length == 8 && bool.TryParse (chronicDataStream[ 0 ], out bool _airways) && bool.TryParse (chronicDataStream[ 1 ], out bool _circulation) && bool.TryParse (chronicDataStream[ 2 ], out bool _diabetes) && bool.TryParse (chronicDataStream[ 3 ], out bool _epilepsy) && bool.TryParse (chronicDataStream[ 4 ], out bool _herpesGenitalis) && bool.TryParse (chronicDataStream[ 5 ], out bool _psychologicalIllness) && bool.TryParse (chronicDataStream[ 6 ], out bool _recurrentUTI) && bool.TryParse (chronicDataStream[ 7 ], out bool _thyroidea) )
                        {
                            Anamnese.ChronicMedicalData = new ChronicMedicalHistory (_circulation, _airways, _thyroidea, _diabetes, _epilepsy, _psychologicalIllness, _herpesGenitalis, _recurrentUTI);
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Anamnese): { ( anamDataStream[ 2 ] ?? "Null" )}");
                        }
                        #endregion

                        Anamnese.DietAndActivity = anamDataStream[ 3 ].Replace (COMMAIDENTIFIER, ",");

                        #region Fertility Info [Line 4]
                        string[] fertilityStream = anamDataStream[ 4 ].Split (",");
                        if ( fertilityStream.Length == 2 && bool.TryParse (fertilityStream[ 0 ], out bool _recievedFertilityTreatment) )
                        {
                            Anamnese.FertilityInfo = new FertilityTreatmentData (_recievedFertilityTreatment, fertilityStream[ 1 ].Replace (COMMAIDENTIFIER, ","));
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Anamnese): { ( anamDataStream[ 4 ] ?? "Null" )}");
                        }
                        #endregion

                        Anamnese.Medicin = anamDataStream[ 5 ].Replace (COMMAIDENTIFIER, ",");

                        #region MMR Vaccinated [Line 6]
                        if ( int.TryParse (anamDataStream[ 6 ], out int _mMRVaccinated) )
                        {
                            Anamnese.MMRVaccinated = ( MMRVaccinationStatus ) _mMRVaccinated;
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Anamnese): { ( anamDataStream[ 6 ] ?? "Null" )}");
                        }
                        #endregion

                        #region Other Drugs [Line 7]
                        if ( bool.TryParse (anamDataStream[ 7 ], out bool _otherDrugs) )
                        {
                            Anamnese.OtherDrugs = _otherDrugs;
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Anamnese): { ( anamDataStream[ 7 ] ?? "Null" )}");
                        }
                        #endregion

                        Anamnese.OtherDrugsComment = anamDataStream[ 8 ].Replace (COMMAIDENTIFIER, ",");
                        Anamnese.PastAdmittance = anamDataStream[ 9 ].Replace (COMMAIDENTIFIER, ",");

                        #region Risk Assessement [Line 10]
                        string[] riskStream = anamDataStream[ 10 ].Split (",");
                        if ( riskStream.Length == 5 && bool.TryParse (riskStream[ 0 ], out bool _doubleTestTaken) && bool.TryParse (riskStream[ 2 ], out bool _requestedMalformationScan) && bool.TryParse (riskStream[ 3 ], out bool _requestedNuchalFoldScan) && bool.TryParse (riskStream[ 4 ], out bool _tripleTestTaken) )
                        {
                            Anamnese.RiskAssessment = new PrenatalRiskAssessment (riskStream[ 1 ].Replace (COMMAIDENTIFIER, ","), _doubleTestTaken, _tripleTestTaken, _requestedNuchalFoldScan, _requestedMalformationScan);
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Anamnese): { ( anamDataStream[ 10 ] ?? "Null" )}");
                        }
                        #endregion

                        #region Term Data [Line 11]
                        string[] termStream = anamDataStream[ 11 ].Split (",");
                        if ( termStream.Length == 3 && DateTime.TryParse (termStream[ 1 ], out DateTime _expectedBirthDate) )
                        {
                            #region Menstrual Cycle Info [Line 0]
                            string[] mensInfoStream = termStream[ 0 ].Split (COLITEMSEPERATOR);
                            MenstrualCycleInfo mensInfo;
                            if ( bool.TryParse (mensInfoStream[ 0 ], out bool _isCalculationSafe) && DateTime.TryParse (mensInfoStream[ 1 ], out DateTime _lastMenstrualDay) )
                            {
                                mensInfo = new MenstrualCycleInfo (_lastMenstrualDay, mensInfoStream[ 2 ].Replace (COMMAIDENTIFIER, ","), _isCalculationSafe);
                            }
                            else
                            {
                                throw new Exception ($"One or more fields couldn't be retrived from (Term Data): { ( termStream[ 0 ] ?? "Null" )}");
                            }
                            #endregion

                            Anamnese.TermInfo = new TermData (mensInfo, _expectedBirthDate, termStream[ 2 ].Replace (COMMAIDENTIFIER, ","));
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Anamnese): { ( anamDataStream[ 11 ] ?? "Null" )}");
                        }
                        #endregion

                        #region TobaccoInfo [Line 12]
                        string[] tobaccoStream = anamDataStream[ 12 ].Split (",");
                        if ( tobaccoStream.Length == 4 && int.TryParse (tobaccoStream[ 0 ], out int _amountPrDay) && DateTime.TryParse (tobaccoStream[ 1 ], out DateTime _quitDate) && bool.TryParse (tobaccoStream[ 2 ], out bool _requestedRehab) && bool.TryParse (tobaccoStream[ 3 ], out bool _smoker) )
                        {
                            Anamnese.TobaccoInfo = new TobaccoHistory (_smoker, _amountPrDay, _quitDate, _requestedRehab);
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Anamnese): { ( anamDataStream[ 12 ] ?? "Null" )}");
                        }
                        #endregion

                        #region WorkEnvironment [Line 13]
                        string[] environmentStream = anamDataStream[ 13 ].Split (",");
                        if ( environmentStream.Length >= 8 && bool.TryParse (environmentStream[ 1 ], out bool _leaveNotification) && bool.TryParse (environmentStream[ 3 ], out bool _partialLeaveNotification) && bool.TryParse (environmentStream[ 4 ], out bool _referedToOMClinic) && int.TryParse (environmentStream[ 6 ], out int _workHoursPrWeek) )
                        {
                            Anamnese.WorkEnvironment.FathersWorkPosition = environmentStream[ 0 ].Replace (COMMAIDENTIFIER, ",");
                            Anamnese.WorkEnvironment.LeaveNotification = _leaveNotification;
                            Anamnese.WorkEnvironment.NatureAndPeriod = environmentStream[ 2 ].Replace (COMMAIDENTIFIER, ",");
                            Anamnese.WorkEnvironment.PartialLeaveNotification = _partialLeaveNotification;
                            Anamnese.WorkEnvironment.ReferedToOMClinic = _referedToOMClinic;

                            #region WorkEnvironment flag build [Line 5]
                            string[] environmentflags = environmentStream[ 5 ].Split (COLITEMSEPERATOR);
                            for ( int i = 0; i < environmentflags.Length; i++ )
                            {
                                if ( int.TryParse (environmentflags[ i ], out int _flag) )
                                {
                                    Anamnese.WorkEnvironment.WorkEnvironments[ i ] = ( WorkEnvironment ) _flag;
                                }
                                else
                                {
                                    throw new Exception ($"One or more fields couldn't be retrived from (Environment Flags): { ( environmentStream[ 5 ] ?? "Null" )}");
                                }
                            }
                            #endregion 

                            Anamnese.WorkEnvironment.WorkHoursPrWeek = _workHoursPrWeek;
                            Anamnese.WorkEnvironment.WorkPosition = environmentStream[ 7 ].Replace (COMMAIDENTIFIER, ",");
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Anamnese): { ( anamDataStream[ 13 ] ?? "Null" )}");
                        }
                        #endregion
                    }
                    else
                    {
                        throw new Exception ($"One or more fields couldn't be retrived from (Anamnese): { ( data[ 3 ] ?? "Null" )}");
                    }
                    #endregion

                    #region Investigations [Line 4]
                    string[] investigationStream = data[ 4 ].Split (OBJECTSEPERATOR);
                    if ( investigationStream.Length == 9 )
                    {
                        #region Clamydia Data [Line 0]
                        string[] claDataStream = investigationStream[ 0 ].Split (",");
                        if ( DateTime.TryParse (claDataStream[ 0 ], out DateTime _claDate) && int.TryParse (claDataStream[ 1 ], out int _claResult) )
                        {
                            Investegations.Clamydia = new Screening (_claDate, ( ScreeningInfo ) _claResult);
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Investigations): { ( investigationStream[ 0 ] ?? "Null" )}");
                        }
                        #endregion

                        #region DVataminReadingDate Data [Line 1]
                        if ( DateTime.TryParse (investigationStream[ 1 ], out DateTime _dVatDate) )
                        {
                            Investegations.DVataminReadingDate = _dVatDate;
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Investigations): { ( investigationStream[ 1 ] ?? "Null" )}");
                        }
                        #endregion

                        Investegations.DVataminReadingResult = investigationStream[ 2 ].Replace (COMMAIDENTIFIER, ",");

                        #region Gonore Data [Line 3]
                        string[] gonDataStream = investigationStream[ 3 ].Split (",");
                        if ( DateTime.TryParse (gonDataStream[ 0 ], out DateTime _gonDate) && int.TryParse (gonDataStream[ 1 ], out int _gonResult) )
                        {
                            Investegations.Gonore = new Screening (_gonDate, ( ScreeningInfo ) _gonResult);
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Investigations): { ( investigationStream[ 3 ] ?? "Null" )}");
                        }
                        #endregion

                        #region Hemoglobinopathy Data [Line 4]
                        string[] hemDataStream = investigationStream[ 0 ].Split (",");
                        if ( DateTime.TryParse (hemDataStream[ 0 ], out DateTime _hemDate) && int.TryParse (hemDataStream[ 1 ], out int _hemResult) )
                        {
                            Investegations.Hemoglobinopathy = new Screening (_hemDate, ( ScreeningInfo ) _hemResult);
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Investigations): { ( investigationStream[ 4 ] ?? "Null" )}");
                        }
                        #endregion

                        #region HepB Data [Line 5]
                        string[] hepDataStream = investigationStream[ 5 ].Split (",");
                        if ( DateTime.TryParse (hepDataStream[ 0 ], out DateTime _hepDate) && int.TryParse (hepDataStream[ 1 ], out int _hepResult) )
                        {
                            Investegations.HepB = new Screening (_hepDate, ( ScreeningInfo ) _hepResult);
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Investigations): { ( investigationStream[ 5 ] ?? "Null" )}");
                        }
                        #endregion

                        #region HIV Data [Line 6]
                        string[] hivDataStream = investigationStream[ 6 ].Split (",");
                        if ( DateTime.TryParse (hivDataStream[ 0 ], out DateTime _hivDate) && int.TryParse (hivDataStream[ 1 ], out int _hivResult) )
                        {
                            Investegations.HIV = new Screening (_hivDate, ( ScreeningInfo ) _hivResult);
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Investigations): { ( investigationStream[ 6 ] ?? "Null" )}");
                        }
                        #endregion

                        #region Syphilis Data [Line 7]
                        string[] sypDataStream = investigationStream[ 7 ].Split (",");
                        if ( DateTime.TryParse (sypDataStream[ 0 ], out DateTime _sypDate) && int.TryParse (sypDataStream[ 1 ], out int _sypResult) )
                        {
                            Investegations.Clamydia = new Screening (_sypDate, ( ScreeningInfo ) _sypResult);
                        }
                        else
                        {
                            throw new Exception ($"One or more fields couldn't be retrived from (Investigations): { ( investigationStream[ 7 ] ?? "Null" )}");
                        }
                        #endregion
                    }
                    else
                    {
                        throw new Exception ($"One or more fields couldn't be retrived from (Investigation): { ( data[ 4 ] ?? "Null" )}");
                    }
                    #endregion

                    #region Resource and Risk Assessement [Line 5]
                    string[] resAndRiskStream = data[ 5 ].Split (",");
                    if ( bool.TryParse (resAndRiskStream[ 1 ], out bool _needObstetricAssessement) && bool.TryParse (resAndRiskStream[ 2 ], out bool _needSocialAndHealthAdministration) && int.TryParse (resAndRiskStream[ 3 ], out int _niveauDistrubution) )
                    {
                        ResAndRiskAssessement.Assessment = resAndRiskStream[ 0 ].Replace (COMMAIDENTIFIER, ",");
                        ResAndRiskAssessement.NeedObstetricAssessement = _needObstetricAssessement;
                        ResAndRiskAssessement.NeedSocialAndHealthAdministration = _needSocialAndHealthAdministration;
                        ResAndRiskAssessement.NiveauDistrubution = ( NiveauDist ) _niveauDistrubution;
                        ResAndRiskAssessement.ObstetricAssessmentNote = resAndRiskStream[ 4 ].Replace (COMMAIDENTIFIER, ",");
                        ResAndRiskAssessement.SocialAndHealthAdministrationNote = resAndRiskStream[ 5 ].Replace (COMMAIDENTIFIER, ",");
                    }
                    else
                    {
                        throw new Exception ($"One or more fields couldn't be retrived from (Resource and Risk Assessement): { ( data[ 5 ] ?? "Null" )}");
                    }
                    #endregion
                }
                else
                {
                    try
                    {
                        throw new Exception ($"No Patient found!");
                    }
                    catch ( Exception _e )
                    {
                        Debug.LogWarning (_e.ToString ());
                    }
                }

                return;
            }

            throw new Exception ($"One or more fields couldn't be retrived from: { ( _data ?? "Null" )}");
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage ("Style", "IDE0071:Simplify interpolation", Justification = "Better readability")]
        public override string SaveEntity ()
        {
            if ( PatientData == null )
            {
                Debug.LogWarning ($"Journal({ID}) without a patient was stored!");
            }
            string journalString = $"JournalID{ID},PatientID{( ( PatientData != null ) ? ( PatientData.ID.ToString () ) : ( "Null" ) )},{( int ) JournalDestination}{Environment.NewLine}";

            #region Pregancy History record build [Line 1]
            string pregnanciesString = string.Empty;

            for ( int i = 0; i < Pregnancies.History.Count; i++ )
            {
                pregnanciesString += $"{Pregnancies.History[ i ].BornAlive.ToString ()},{( ( Pregnancies.History[ i ].CurrentStatusOfChild != null ) ? ( Pregnancies.History[ i ].CurrentStatusOfChild.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )},{( ( Pregnancies.History[ i ].GestationAge != null ) ? ( Pregnancies.History[ i ].GestationAge.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )},{Pregnancies.History[ i ].Male.ToString ()},{( ( Pregnancies.History[ i ].PlaceOfBirth != null ) ? ( Pregnancies.History[ i ].PlaceOfBirth.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )},{( int ) Pregnancies.History[ i ].PregnancyExperience},{( ( Pregnancies.History[ i ].PregnancyProgress != null ) ? ( Pregnancies.History[ i ].PregnancyProgress.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )},{Pregnancies.History[ i ].StillBorn.ToString ()},{Pregnancies.History[ i ].Weight.ToString (new CultureInfo ("en-US"))},{Pregnancies.History[ i ].Year}";

                if ( i != Pregnancies.History.Count - 1 )
                {
                    pregnanciesString += COLITEMSEPERATOR;
                }
            }
            #endregion

            #region Abortion History record build [Line 2]
            string abortionsString = string.Empty;

            for ( int i = 0; i < Abortions.History.Count; i++ )
            {
                abortionsString += $"{( ( Abortions.History[ i ].PlannedAbortionGA != null ) ? ( Abortions.History[ i ].PlannedAbortionGA.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )},{( ( Abortions.History[ i ].UnplannedAbortionGA != null ) ? ( Abortions.History[ i ].UnplannedAbortionGA.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )},{Abortions.History[ i ].Year}";

                if ( i != Abortions.History.Count - 1 )
                {
                    abortionsString += COLITEMSEPERATOR;
                }
            }
            #endregion

            #region Anamnsese record build [Line 3]
            string anamnseseString = string.Empty;
            anamnseseString += $"{Anamnese.AlcoholInfo.AmountPrWeek},{Anamnese.AlcoholInfo.DuringPregnancy.ToString ()},{Anamnese.AlcoholInfo.MultiplePrSession.ToString ()}{OBJECTSEPERATOR}";
            anamnseseString += $"{( ( Anamnese.Allergies.Allergies != null ) ? ( Anamnese.Allergies.Allergies.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )},{( int ) Anamnese.Allergies.ChildAllergyRisk}{OBJECTSEPERATOR}";
            anamnseseString += $"{Anamnese.ChronicMedicalData.Airways.ToString ()},{Anamnese.ChronicMedicalData.Circulation.ToString ()},{Anamnese.ChronicMedicalData.Diabetes.ToString ()},{Anamnese.ChronicMedicalData.Epilepsy.ToString ()},{Anamnese.ChronicMedicalData.HerpesGenitalis.ToString ()},{Anamnese.ChronicMedicalData.PsychologicalIllness.ToString ()},{Anamnese.ChronicMedicalData.RecurrentUTI.ToString ()},{Anamnese.ChronicMedicalData.Thyroidea.ToString ()}{OBJECTSEPERATOR}";
            anamnseseString += $"{( ( Anamnese.DietAndActivity != null ) ? ( Anamnese.DietAndActivity.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )}{OBJECTSEPERATOR}";
            anamnseseString += $"{Anamnese.FertilityInfo.RecievedFertilityTreatment.ToString ()},{( ( Anamnese.FertilityInfo.Comment != null ) ? ( Anamnese.FertilityInfo.Comment.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )}{OBJECTSEPERATOR}";
            anamnseseString += $"{( ( Anamnese.Medicin != null ) ? ( Anamnese.Medicin.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )}{OBJECTSEPERATOR}";
            anamnseseString += $"{( int ) Anamnese.MMRVaccinated}{OBJECTSEPERATOR}";
            anamnseseString += $"{Anamnese.OtherDrugs.ToString ()}{OBJECTSEPERATOR}";
            anamnseseString += $"{( ( Anamnese.OtherDrugsComment != null ) ? ( Anamnese.OtherDrugsComment.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )}{OBJECTSEPERATOR}";
            anamnseseString += $"{( ( Anamnese.PastAdmittance != null ) ? ( Anamnese.PastAdmittance.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )}{OBJECTSEPERATOR}";
            anamnseseString += $"{Anamnese.RiskAssessment.DoubleTestTaken.ToString ()},{( ( Anamnese.RiskAssessment.FamiliyHistory != null ) ? ( Anamnese.RiskAssessment.FamiliyHistory.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )},{Anamnese.RiskAssessment.RequestedMalformationScan.ToString ()},{Anamnese.RiskAssessment.RequestedNuchalFoldScan.ToString ()},{Anamnese.RiskAssessment.TripleTestTaken.ToString ()}{OBJECTSEPERATOR}";
            #region Term Data record build
            anamnseseString += $"{Anamnese.TermInfo.MenstrualInfo.IsCalculationSafe.ToString ()}{COLITEMSEPERATOR}{Anamnese.TermInfo.MenstrualInfo.LastMentruationalDay.ToString ()}{COLITEMSEPERATOR}{( ( Anamnese.TermInfo.MenstrualInfo.MenstruationalCycle != null ) ? ( Anamnese.TermInfo.MenstrualInfo.MenstruationalCycle.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )},";
            anamnseseString += $"{Anamnese.TermInfo.ExpectedBirthDate.ToString ()},{( ( Anamnese.TermInfo.Comment != null ) ? ( Anamnese.TermInfo.Comment.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )}{OBJECTSEPERATOR}";
            #endregion
            anamnseseString += $"{Anamnese.TobaccoInfo.AmountPrDay},{Anamnese.TobaccoInfo.QuitDate.ToString ()},{Anamnese.TobaccoInfo.RequestedRehab.ToString ()},{Anamnese.TobaccoInfo.Smoker.ToString ()}{OBJECTSEPERATOR}";
            #region WorkEnvironment record build
            anamnseseString += $"{( ( Anamnese.WorkEnvironment.FathersWorkPosition != null ) ? ( Anamnese.WorkEnvironment.FathersWorkPosition.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )},{Anamnese.WorkEnvironment.LeaveNotification.ToString ()},{( ( Anamnese.WorkEnvironment.NatureAndPeriod != null ) ? ( Anamnese.WorkEnvironment.NatureAndPeriod.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )},{Anamnese.WorkEnvironment.PartialLeaveNotification.ToString ()},{Anamnese.WorkEnvironment.ReferedToOMClinic.ToString ()},";
            #region WorkEnvironment flag build
            for ( int i = 0; i < Anamnese.WorkEnvironment.WorkEnvironments.Length; i++ )
            {
                anamnseseString += $"{( int ) Anamnese.WorkEnvironment.WorkEnvironments[ i ]}";

                if ( i != Anamnese.WorkEnvironment.WorkEnvironments.Length - 1 )
                {
                    anamnseseString += COLITEMSEPERATOR;
                }
                else
                {
                    anamnseseString += ",";
                }
            }
            #endregion
            anamnseseString += $"{Anamnese.WorkEnvironment.WorkHoursPrWeek},{( ( Anamnese.WorkEnvironment.WorkPosition != null ) ? ( Anamnese.WorkEnvironment.WorkPosition.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )}";
            #endregion
            #endregion

            #region Investigations [Line 4]
            string investigationString = string.Empty;
            investigationString += $"{Investegations.Clamydia.Date.ToString ()},{( int ) Investegations.Clamydia.Result}{OBJECTSEPERATOR}";
            investigationString += $"{Investegations.DVataminReadingDate.ToString ()}{OBJECTSEPERATOR}";
            investigationString += $"{( ( Investegations.DVataminReadingResult != null ) ? ( Investegations.DVataminReadingResult.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )}{OBJECTSEPERATOR}";
            investigationString += $"{Investegations.Gonore.Date.ToString ()},{( int ) Investegations.Gonore.Result}{OBJECTSEPERATOR}";
            investigationString += $"{Investegations.Hemoglobinopathy.Date.ToString ()},{( int ) Investegations.Hemoglobinopathy.Result}{OBJECTSEPERATOR}";
            investigationString += $"{Investegations.HepB.Date.ToString ()},{( int ) Investegations.HepB.Result}{OBJECTSEPERATOR}";
            investigationString += $"{Investegations.HIV.Date.ToString ()},{( int ) Investegations.HIV.Result}{OBJECTSEPERATOR}";
            investigationString += $"{Investegations.Syphilis.Date.ToString ()},{( int ) Investegations.Syphilis.Result}{OBJECTSEPERATOR}";
            #endregion

            #region ResAndRiskAssessement record build [Line 5] (No object Seperator)
            string resAndRiskString = $"{( ( ResAndRiskAssessement.Assessment != null ) ? ( ResAndRiskAssessement.Assessment.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )},{ResAndRiskAssessement.NeedObstetricAssessement.ToString ()},{ResAndRiskAssessement.NeedSocialAndHealthAdministration.ToString ()},{( int ) ResAndRiskAssessement.NiveauDistrubution},{( ( ResAndRiskAssessement.ObstetricAssessmentNote != null ) ? ( ResAndRiskAssessement.ObstetricAssessmentNote.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )},{( ( ResAndRiskAssessement.SocialAndHealthAdministrationNote != null ) ? ( ResAndRiskAssessement.SocialAndHealthAdministrationNote.Replace (",", COMMAIDENTIFIER) ) : ( string.Empty ) )}";
            #endregion

            journalString += $"{pregnanciesString}{Environment.NewLine}{abortionsString}{Environment.NewLine}{anamnseseString}{Environment.NewLine}{investigationString}{Environment.NewLine}{resAndRiskString}";

            return journalString;
        }
    }
}
