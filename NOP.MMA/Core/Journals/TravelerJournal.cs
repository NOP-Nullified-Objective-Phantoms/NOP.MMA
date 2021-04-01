﻿using NOP.MMA.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Represents an <see cref="IJournal"/> extended to include information about an <see cref="IPatient"/>s progression through a pregnancy
    /// </summary>
    internal class TravelerJournal : Journal, ITravelerJournal
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="TravelerJournal"/> with its <see langword="default"/> values
        /// </summary>
        /// <param name="_id"></param>
        public TravelerJournal ( int? _id = null ) : base (_id)
        {
            MenstrualInfo = new MenstrualCycleInfo ();
            WeightInfo = new WeightInfo ();
            HepB = new Screening ();
            AntiDImmunoglobulinGiven = new JournalData ();
            UrineCulture = new JournalData ();
            journalStamps = new List<JournalStamp> ();
            journalComments = new List<JournalComment> ();
            ultraSoundScans = new List<UltrasoundResult> ();
            OddsForDS = new JournalData ();
            PlacentaTest = new JournalData ();
            AmnioticFluidTest = new JournalData ();
            OralGlukoseToleranceTest = new OGTTScreening ();
            BirthplaceInfo = new BirthplaceInformation ();
        }

        public MenstrualCycleInfo MenstrualInfo { get; set; }
        public DateTime NaegelsRule { get; set; }
        public DateTime UltrasoundTermin { get; set; }
        public WeightInfo WeightInfo { get; set; }
        public bool MothersRhesusFactor { get; set; }
        public bool ChildsRhesusFactor { get; set; }
        public Screening HepB { get; set; }
        public bool BloodTypeDetermined { get; set; }
        public bool AntibodyByRhesusNegative { get; set; }
        public bool IrregularAntibody { get; set; }
        public JournalData AntiDImmunoglobulinGiven { get; set; }
        public JournalData UrineCulture { get; set; }
        private readonly List<JournalStamp> journalStamps;
        public IReadOnlyList<JournalStamp> JournalStamps
        {
            get
            {
                return journalStamps;
            }
        }
        private readonly List<JournalComment> journalComments;
        public IReadOnlyList<JournalComment> JournalComments
        {
            get
            {
                return journalComments;
            }
        }
        private readonly List<UltrasoundResult> ultraSoundScans;
        public IReadOnlyList<UltrasoundResult> UltraSoundScans
        {
            get
            {
                return ultraSoundScans;
            }
        }
        public DateTime NuchalFoldScan { get; set; }
        public DateTime DoubleTest { get; set; }
        public DateTime TripleTest { get; set; }
        public JournalData OddsForDS { get; set; }
        public JournalData PlacentaTest { get; set; }
        public JournalData AmnioticFluidTest { get; set; }
        public OGTTScreening OralGlukoseToleranceTest { get; set; }
        public string AdditonalContext { get; set; }
        public BirthplaceInformation BirthplaceInfo { get; set; }

        public bool AddJournalSComment ( JournalComment _comment )
        {
            journalComments.Add (_comment);

            return true;
        }

        public bool AddJournalStamp ( JournalStamp _stamp )
        {
            journalStamps.Add (_stamp);

            return true;
        }

        public bool AddUltraSoundScan ( UltrasoundResult _scan )
        {
            ultraSoundScans.Add (_scan);

            return true;
        }

        public override void BuildEntity ( string _data )
        {
            string[] data = _data.Split (Environment.NewLine);

            if ( data.Length == 19 )
            {
                #region Core Journal data [Line 0]
                string[] coreJournalData = data[ 0 ].Split (",");

                if ( int.TryParse (coreJournalData[ 0 ].Replace ("JournalData", string.Empty), out int _id) && int.TryParse (coreJournalData[ 1 ].Replace ("PatientID", string.Empty), out int _patientID) && int.TryParse (coreJournalData[ 2 ], out int _journalDest) )
                {
                    ID = _id;
                    PatientData = PatientRepo.Link.GetDataByIdentifier (_patientID);
                    JournalDestination = ( JournalDest ) _journalDest;
                }
                #endregion

                #region MenstrualInfo [Line 1]
                string[] mensStream = data[ 1 ].Split (",");
                if ( mensStream.Length == 3 && DateTime.TryParse (mensStream[ 0 ], out DateTime _date) && bool.TryParse (data[ 2 ], out bool _isCalculationSafe) )
                {
                    MenstrualInfo = new MenstrualCycleInfo (_date, mensStream[ 1 ].Replace (COMMAIDENTIFIER, ","), _isCalculationSafe);
                }
                #endregion

                #region NaegelsRule & UltraSoundTermin [Line 2]
                string[] dateDataStream = data[ 2 ].Split (",");
                if ( dateDataStream.Length == 2 && DateTime.TryParse (dateDataStream[ 0 ], out DateTime _naegelsRule) && DateTime.TryParse (dateDataStream[ 1 ], out DateTime _ultraSoundTermin) )
                {
                    NaegelsRule = _naegelsRule;
                    UltrasoundTermin = _ultraSoundTermin;
                }
                #endregion

                #region WeightInfo [Line 3]
                string[] weightStream = data[ 3 ].Split (",");
                if ( weightStream.Length == 3 && double.TryParse (weightStream[ 0 ], out double _weightbeforePregnancy) && double.TryParse (weightStream[ 1 ], out double _height) && double.TryParse (weightStream[ 2 ], out double _bmi) )
                {
                    WeightInfo = new WeightInfo (_weightbeforePregnancy, _height, _bmi);
                }
                #endregion

                #region Rhesus Values [Line 4]
                string[] rhesusStream = data[ 4 ].Split (",");
                if ( rhesusStream.Length == 2 && bool.TryParse (rhesusStream[ 0 ], out bool _mothersRhesusFactor) && bool.TryParse (rhesusStream[ 1 ], out bool _childsRhesusFactor) )
                {
                    MothersRhesusFactor = _mothersRhesusFactor;
                    ChildsRhesusFactor = _childsRhesusFactor;
                }
                #endregion

                #region HepB [Line 5]
                string[] hepBStream = data[ 5 ].Split (",");
                if ( hepBStream.Length == 2 && DateTime.TryParse (hepBStream[ 0 ], out DateTime _hepBDate) && int.TryParse (hepBStream[ 1 ], out int _result) )
                {
                    HepB = new Screening (_hepBDate, ( ScreeningInfo ) _result);
                }
                #endregion

                #region BloodtypeDetermined, AntibodyRhesusNegative & IrregularAntibody [Line 6]
                string[] antibodyDataStream = data[ 6 ].Split (",");
                if ( antibodyDataStream.Length == 3 && bool.TryParse (antibodyDataStream[ 0 ], out bool _bloodTypeDetermined) && bool.TryParse (antibodyDataStream[ 0 ], out bool _antibodyRhesusNegative) && bool.TryParse (antibodyDataStream[ 0 ], out bool _irregularAntibody) )
                {
                    BloodTypeDetermined = _bloodTypeDetermined;
                    AntibodyByRhesusNegative = _antibodyRhesusNegative;
                    IrregularAntibody = _irregularAntibody;
                }
                #endregion

                #region AntiDImmunoglobulinGiven [Line 7]
                string[] antiDStream = data[ 7 ].Split (",");
                if ( antiDStream.Length == 3 && DateTime.TryParse (antiDStream[ 0 ], out DateTime _antiDDate) )
                {
                    AntiDImmunoglobulinGiven = new JournalData (_antiDDate, antiDStream[ 1 ].Replace (COMMAIDENTIFIER, ","), antiDStream[ 2 ].Replace (COMMAIDENTIFIER, ","));
                }
                #endregion

                #region UrinCulture [Line 8]
                string[] urinCultureStream = data[ 8 ].Split (",");

                if ( urinCultureStream.Length == 2 && DateTime.TryParse (urinCultureStream[ 0 ], out DateTime _urinCulturedate) )
                {
                    UrineCulture = new JournalData (_urinCulturedate, urinCultureStream[ 1 ].Replace (COMMAIDENTIFIER, ","), urinCultureStream[ 2 ].Replace (COMMAIDENTIFIER, ","));
                }
                #endregion

                #region journalStamps [Line 9]
                string[] stampsStream = data[ 9 ].Split (COLITEMSEPERATOR);
                foreach ( string stampData in stampsStream )
                {
                    string[] stampDataStream = stampData.Split (",");
                    if ( stampDataStream.Length == 12 && DateTime.TryParse (stampDataStream[ 1 ], out DateTime _stampDate) && bool.TryParse (stampDataStream[ 2 ], out bool _edema) && bool.TryParse (stampDataStream[ 4 ], out bool _fetusActivity) && double.TryParse (stampDataStream[ 10 ], NumberStyles.AllowDecimalPoint, new CultureInfo ("en-US"), out double _uterusSizeInCM) && double.TryParse (stampDataStream[ 11 ], NumberStyles.AllowDecimalPoint, new CultureInfo ("en-US"), out double _weight) )
                    {
                        JournalStamp stamp = new JournalStamp ()
                        {
                            BloodPressure = stampDataStream[ 0 ].Replace (COMMAIDENTIFIER, ","),
                            Date = _stampDate,
                            Edema = _edema,
                            ExaminationLocation = stampDataStream[ 3 ].Replace (COMMAIDENTIFIER, ","),
                            FetusActivity = _fetusActivity,
                            FetusGender = stampDataStream[ 5 ].Replace (COMMAIDENTIFIER, ","),
                            FosterRepresentation = stampDataStream[ 6 ].Replace (COMMAIDENTIFIER, ","),
                            GestationAge = stampDataStream[ 7 ].Replace (COMMAIDENTIFIER, ","),
                            Initials = stampDataStream[ 8 ].Replace (COMMAIDENTIFIER, ","),
                            UrinSample = stampDataStream[ 9 ].Replace (COMMAIDENTIFIER, ","),
                            UterusSizeInCM = _uterusSizeInCM,
                            Weight = _weight

                        };

                        AddJournalStamp (stamp);
                    }

                }
                #endregion

                #region JournalComments [Line 10]
                string[] commentsStream = data[ 10 ].Split (COLITEMSEPERATOR);
                foreach ( string commentData in commentsStream )
                {
                    string[] commentDataStream = commentData.Split (",");
                    if ( commentDataStream.Length == 2 && DateTime.TryParse (commentDataStream[ 1 ], out DateTime _commentDate) )
                    {
                        JournalComment comment = new JournalComment ()
                        {
                            Comment = commentDataStream[ 0 ].Replace (COMMAIDENTIFIER, ","),
                            Date = _commentDate
                        };

                        AddJournalSComment (comment);
                    }

                }
                #endregion

                #region UltraSoundScans [Line 11]
                string[] ultraStream = data[ 11 ].Split (COLITEMSEPERATOR);
                foreach ( string ultraData in ultraStream )
                {
                    string[] ultraDataStream = ultraData.Split (",");
                    if ( ultraDataStream.Length == 9 && double.TryParse (ultraDataStream[ 0 ], NumberStyles.AllowDecimalPoint, new CultureInfo ("en-US"), out double _amnioticFluidAmount) && DateTime.TryParse (ultraDataStream[ 1 ], out DateTime _ultraResultDate) && double.TryParse (ultraDataStream[ 7 ], NumberStyles.AllowDecimalPoint, new CultureInfo ("en-US"), out double _usWeight) && double.TryParse (ultraDataStream[ 8 ], NumberStyles.AllowDecimalPoint, new CultureInfo ("en-US"), out double _weightDifference) )
                    {
                        UltrasoundResult ultraSoundScan = new UltrasoundResult ()
                        {
                            AmnioticFluidAmount = _amnioticFluidAmount,
                            Date = _ultraResultDate,
                            ExaminationLocation = ultraDataStream[ 2 ].Replace (COMMAIDENTIFIER, ","),
                            Flow = ultraDataStream[ 3 ].Replace (COMMAIDENTIFIER, ","),
                            FosterRepresentation = ultraDataStream[4].Replace(COMMAIDENTIFIER, ","),
                            GestationAge = ultraDataStream[ 5 ].Replace (COMMAIDENTIFIER, ","),
                            Initials = ultraDataStream[ 6 ].Replace (COMMAIDENTIFIER, ","),
                            USWeight = _usWeight,
                            WeightDifference = _weightDifference
                        };

                        AddUltraSoundScan (ultraSoundScan);
                    }

                }
                #endregion

                #region NuchalFoldScan, DoubleTest & TripleTest [Line 12]
                string[] testData = data[ 12 ].Split (",");
                if ( testData.Length == 3 && DateTime.TryParse (testData[ 0 ], out DateTime _nuchalFoldScan) && DateTime.TryParse (testData[ 1 ], out DateTime _doubleTest) && DateTime.TryParse (testData[ 2 ], out DateTime _tripleTest) )
                {
                    NuchalFoldScan = _nuchalFoldScan;
                    DoubleTest = _doubleTest;
                    TripleTest = _tripleTest;
                }
                #endregion

                #region OddsForDS [Line 13]
                string[] oddsForDSStream = data[ 13 ].Split (",");
                if ( oddsForDSStream.Length == 3 && DateTime.TryParse (oddsForDSStream[ 0 ], out DateTime _oddsForDSDate) )
                {
                    OddsForDS = new JournalData (_oddsForDSDate, oddsForDSStream[ 1 ].Replace (COMMAIDENTIFIER, ","), oddsForDSStream[ 2 ].Replace (COMMAIDENTIFIER, ","));
                }
                #endregion

                #region PlacentaTest [Line 14]
                string[] placentaTestStream = data[ 14 ].Split (",");
                if ( placentaTestStream.Length == 3 && DateTime.TryParse (placentaTestStream[ 0 ], out DateTime _placentaTestSDate) )
                {
                    OddsForDS = new JournalData (_placentaTestSDate, placentaTestStream[ 1 ].Replace (COMMAIDENTIFIER, ","), placentaTestStream[ 2 ].Replace (COMMAIDENTIFIER, ","));
                }
                #endregion

                #region AmnioticFluidTest [Line 15]
                string[] amnioticFluidTestStream = data[ 15 ].Split (",");
                if ( amnioticFluidTestStream.Length == 3 && DateTime.TryParse (amnioticFluidTestStream[ 0 ], out DateTime _amnioticFluidTestSDate) )
                {
                    OddsForDS = new JournalData (_amnioticFluidTestSDate, amnioticFluidTestStream[ 1 ].Replace (COMMAIDENTIFIER, ","), amnioticFluidTestStream[ 2 ].Replace (COMMAIDENTIFIER, ","));
                }
                #endregion

                #region OralGlukoseToleranceTest [Line 16]
                string[] oralGTTStream = data[ 16 ].Split (OBJECTSEPERATOR);
                if ( oralGTTStream.Length == 3 )
                {
                    #region Glycosuria [Line 0]
                    string[] glycosuriaStream = data[ 0 ].Split (",");
                    if ( glycosuriaStream.Length == 3 && DateTime.TryParse (glycosuriaStream[ 0 ], out DateTime _glycosuriaStreamDate) )
                    {
                        OddsForDS = new JournalData (_glycosuriaStreamDate, glycosuriaStream[ 1 ].Replace (COMMAIDENTIFIER, ","), glycosuriaStream[ 2 ].Replace (COMMAIDENTIFIER, ","));
                    }
                    #endregion

                    #region Week18_20 [Line 1]
                    string[] week18_20Stream = data[ 1 ].Split (",");
                    if ( week18_20Stream.Length == 3 && DateTime.TryParse (week18_20Stream[ 0 ], out DateTime _week18_20StreamDate) )
                    {
                        OddsForDS = new JournalData (_week18_20StreamDate, week18_20Stream[ 1 ].Replace (COMMAIDENTIFIER, ","), week18_20Stream[ 2 ].Replace (COMMAIDENTIFIER, ","));
                    }
                    #endregion

                    #region Week28_30 [Line 2]
                    string[] week28_30Stream = data[ 2 ].Split (",");
                    if ( week28_30Stream.Length == 3 && DateTime.TryParse (week28_30Stream[ 0 ], out DateTime _Week28_30Date) )
                    {
                        OddsForDS = new JournalData (_Week28_30Date, week28_30Stream[ 1 ].Replace (COMMAIDENTIFIER, ","), week28_30Stream[ 2 ].Replace (COMMAIDENTIFIER, ","));
                    }
                    #endregion
                }
                #endregion

                #region AdditonalContext [Line 17]
                AdditonalContext = data[ 17 ].Replace (COMMAIDENTIFIER, ",");
                #endregion

                #region BirthplaceInfo [Line 18]
                string[] birthPlaceInfoStream = data[ 18 ].Split (",");
                if ( bool.TryParse (birthPlaceInfoStream[ 1 ], out bool _birthWish) && int.TryParse (birthPlaceInfoStream[ 3 ], out int _conFormat) )
                {
                    BirthplaceInfo = new BirthplaceInformation ()
                    {
                        BirthplaceWish = birthPlaceInfoStream[ 0 ].Replace (COMMAIDENTIFIER, ","),
                        BirthPreperationWish = _birthWish,
                        ChangedBirthplace = birthPlaceInfoStream[ 2 ].Replace (COMMAIDENTIFIER, ","),
                        ConFormat = ( ConsultationFormat ) _conFormat,
                        MidwifeCenterCity = birthPlaceInfoStream[ 4 ].Replace (COMMAIDENTIFIER, ","),
                        MidwifeCenterHouseNumber = birthPlaceInfoStream[ 5 ].Replace (COMMAIDENTIFIER, ","),
                        MidwifeCenterName = birthPlaceInfoStream[ 6 ].Replace (COMMAIDENTIFIER, ","),
                        MidwifeCenterPhone = birthPlaceInfoStream[ 7 ].Replace (COMMAIDENTIFIER, ","),
                        MidwifeCenterPostalCode = birthPlaceInfoStream[8].Replace (COMMAIDENTIFIER, ","),
                        MidwifeCenterStreet = birthPlaceInfoStream[9].Replace(COMMAIDENTIFIER, ","),
                        MidwifeConsultationWish = birthPlaceInfoStream[10].Replace (COMMAIDENTIFIER, ","),
                        PrimaryExpectedBirthplace = birthPlaceInfoStream[11].Replace(COMMAIDENTIFIER, ",")
                    };
                }
                #endregion
            }
        }

        public bool RemoveJournalComment ( DateTime _commentDate )
        {
            return journalComments.Remove (journalComments.Find (item => item.Date == _commentDate));
        }

        public bool RemoveJournalStamp ( DateTime _stampDate )
        {
            return journalStamps.Remove (journalStamps.Find (item => item.Date == _stampDate));
        }

        public bool RemoveUltrasoundScan ( DateTime _scanDate )
        {
            return ultraSoundScans.Remove (ultraSoundScans.Find (item => item.Date == _scanDate));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage ("Style", "IDE0071:Simplify interpolation", Justification = "Better Readability")]
        public override string SaveEntity ()
        {
            string journalString = $"JournalID{ID},PatientID{PatientData.ID},{( int ) JournalDestination}{Environment.NewLine}";

            #region MenstrualInfo [Line 1]
            journalString += $"{MenstrualInfo.IsCalculationSafe.ToString ()},{MenstrualInfo.LastMentruationalDay.ToString ()},{MenstrualInfo.MenstruationalCycle.Replace (",", COMMAIDENTIFIER)}{Environment.NewLine}";
            #endregion

            journalString += $"{NaegelsRule.ToString ()},{UltrasoundTermin.ToString ()}{Environment.NewLine}";

            #region WeightInfo [Line 3]
            journalString += $"{WeightInfo.BMI.ToString (new CultureInfo ("en-US"))},{WeightInfo.HeightInCM.ToString (new CultureInfo ("en-US"))},{WeightInfo.WeightBeforePregnancyInKG.ToString (new CultureInfo ("en-US"))}{Environment.NewLine}";
            #endregion

            journalString += $"{MothersRhesusFactor.ToString ()},{ChildsRhesusFactor.ToString ()}{Environment.NewLine}";

            #region HepB [Line 5]
            journalString += $"{HepB.Date.ToString ()},{( int ) HepB.Result}{Environment.NewLine}";
            #endregion 

            journalString += $"{BloodTypeDetermined.ToString ()},{AntibodyByRhesusNegative.ToString ()},{IrregularAntibody.ToString ()}{Environment.NewLine}";

            #region AntiDImmunoglobulinGiven [Line 7]
            journalString += $"{AntiDImmunoglobulinGiven.Date.ToString ()},{AntiDImmunoglobulinGiven.Initials.Replace (",", COMMAIDENTIFIER)},{AntiDImmunoglobulinGiven.Value.Replace (",", COMMAIDENTIFIER)}{Environment.NewLine}";
            #endregion

            #region UrinCulture [Line 8]
            journalString += $"{UrineCulture.Date.ToString ()},{UrineCulture.Initials.Replace (",", COMMAIDENTIFIER)},{UrineCulture.Value.Replace (",", COMMAIDENTIFIER)}{Environment.NewLine}";
            #endregion

            #region journalStamps [Line 9]
            string stampsData = string.Empty;
            for ( int i = 0; i < journalStamps.Count; i++ )
            {
                stampsData += $"{journalStamps[ i ].BloodPressure.Replace (",", COMMAIDENTIFIER)},{journalStamps[ i ].Date.ToString ()},{journalStamps[ i ].Edema.ToString ()},{journalStamps[ i ].ExaminationLocation.Replace (",", COMMAIDENTIFIER)},{journalStamps[ i ].FetusActivity.ToString ()},{journalStamps[ i ].FetusGender.Replace (",", COMMAIDENTIFIER)},{journalStamps[ i ].FosterRepresentation.Replace (",", COMMAIDENTIFIER)},{journalStamps[ i ].GestationAge.Replace (",", COMMAIDENTIFIER)},{journalStamps[ i ].Initials.Replace (",", COMMAIDENTIFIER)},{journalStamps[ i ].UrinSample.Replace (",", COMMAIDENTIFIER)},{journalStamps[ i ].UterusSizeInCM.ToString (new CultureInfo ("en-US"))},{journalStamps[ i ].Weight.ToString (new CultureInfo ("en-US"))}";

                if ( i != journalStamps.Count - 1 )
                {
                    stampsData += COLITEMSEPERATOR;
                }
            }
            #endregion

            #region JournalComments [Line 10]
            string commentsData = string.Empty;
            for ( int i = 0; i < journalComments.Count; i++ )
            {
                commentsData += $"{journalComments[ i ].Comment.Replace (",", COMMAIDENTIFIER)},{journalComments[ i ].Date.ToString ()}";

                if ( i != journalComments.Count - 1 )
                {
                    commentsData += COLITEMSEPERATOR;
                }
            }
            #endregion

            #region UltraSoundScans [Line 11]
            string ultraData = string.Empty;
            for ( int i = 0; i < journalComments.Count; i++ )
            {
                ultraData += $"{ultraSoundScans[ i ].AmnioticFluidAmount.ToString (new CultureInfo ("en-US"))},{ultraSoundScans[ i ].Date.ToString ()},{ultraSoundScans[ i ].ExaminationLocation.Replace (",", COMMAIDENTIFIER)},{ultraSoundScans[ i ].Flow.Replace (",", COMMAIDENTIFIER)},{ultraSoundScans[ i ].FosterRepresentation.Replace(",", COMMAIDENTIFIER)},{ultraSoundScans[ i ].GestationAge.Replace (",", COMMAIDENTIFIER)},{ultraSoundScans[ i ].Initials.Replace (",", COMMAIDENTIFIER)},{ultraSoundScans[ i ].USWeight.ToString (new CultureInfo ("en-US"))},{ultraSoundScans[ i ].WeightDifference.ToString (new CultureInfo ("en-US"))}";

                if ( i != journalComments.Count - 1 )
                {
                    ultraData += COLITEMSEPERATOR;
                }
            }
            #endregion

            journalString += $"{stampsData}{Environment.NewLine}{commentsData}{Environment.NewLine}{ultraData}{Environment.NewLine}";

            journalString += $"{NuchalFoldScan.ToString ()},{DoubleTest.ToString ()},{TripleTest.ToString ()}{Environment.NewLine}";

            #region OddsForDS [Line 13]
            journalString += $"{OddsForDS.Date.ToString ()},{OddsForDS.Initials.Replace (",", COMMAIDENTIFIER)},{OddsForDS.Value.Replace (",", COMMAIDENTIFIER)}{Environment.NewLine}";
            #endregion 

            #region PlacentaTest [Line 14]
            journalString += $"{PlacentaTest.Date.ToString ()},{PlacentaTest.Initials.Replace (",", COMMAIDENTIFIER)},{PlacentaTest.Value.Replace (",", COMMAIDENTIFIER)}{Environment.NewLine}";
            #endregion 

            #region AmnioticFluidTest [Line 15]
            journalString += $"{AmnioticFluidTest.Date.ToString ()},{AmnioticFluidTest.Initials.Replace (",", COMMAIDENTIFIER)},{AmnioticFluidTest.Value.Replace (",", COMMAIDENTIFIER)}{Environment.NewLine}";
            #endregion

            #region OralGlukoseToleranceTest [Line 16]
            string glycData = $"{OralGlukoseToleranceTest.Glycosuria.Date.ToString ()},{OralGlukoseToleranceTest.Glycosuria.Initials.Replace (",", COMMAIDENTIFIER)},{OralGlukoseToleranceTest.Glycosuria.Value.Replace (",", COMMAIDENTIFIER)}";
            string Week18Data = $"{OralGlukoseToleranceTest.Week18_20.Date.ToString ()},{OralGlukoseToleranceTest.Week18_20.Initials.Replace (",", COMMAIDENTIFIER)},{OralGlukoseToleranceTest.Week18_20.Value.Replace (",", COMMAIDENTIFIER)}";
            string Week28Data = $"{OralGlukoseToleranceTest.Week28_30.Date.ToString ()},{OralGlukoseToleranceTest.Week28_30.Initials.Replace (",", COMMAIDENTIFIER)},{OralGlukoseToleranceTest.Week28_30.Value.Replace (",", COMMAIDENTIFIER)}";

            string oralData = $"{glycData}{OBJECTSEPERATOR}{Week18Data}{OBJECTSEPERATOR}{Week28Data}{Environment.NewLine}";

            journalString += oralData;
            #endregion

            journalString += $"{AdditonalContext.Replace (",", COMMAIDENTIFIER)}{Environment.NewLine}";

            journalString += $"{BirthplaceInfo.BirthplaceWish.Replace (",", COMMAIDENTIFIER)},{BirthplaceInfo.BirthPreperationWish.ToString ()},{BirthplaceInfo.ChangedBirthplace.Replace (",", COMMAIDENTIFIER)},{( int ) BirthplaceInfo.ConFormat},{BirthplaceInfo.MidwifeCenterCity.Replace (",", COMMAIDENTIFIER)},{BirthplaceInfo.MidwifeCenterHouseNumber.Replace (",", COMMAIDENTIFIER)},{BirthplaceInfo.MidwifeCenterName.Replace (",", COMMAIDENTIFIER)},{BirthplaceInfo.MidwifeCenterPhone.Replace (",", COMMAIDENTIFIER)},{BirthplaceInfo.MidwifeCenterPostalCode.Replace (",", COMMAIDENTIFIER)},{BirthplaceInfo.MidwifeCenterStreet.Replace (",", COMMAIDENTIFIER)},{BirthplaceInfo.MidwifeConsultationWish.Replace (",", COMMAIDENTIFIER)},{BirthplaceInfo.PrimaryExpectedBirthplace.Replace (",", COMMAIDENTIFIER)}{Environment.NewLine}";

            return journalString;
        }
    }
}