using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Represents a summary of a patients resource and risk assessement
    /// </summary>
    internal class RRAssessement : IResourceAndRiskAssessment
    {
        public string Assessment { get; set; }
        public NiveauDist NiveauDistrubution { get; set; }
        public bool NeedObstetricAssessement { get; set; }
        public string ObstetricAssessmentNote { get; set; }
        public bool NeedSocialAndHealthAdministration { get; set; }
        public string SocialAndHealthAdministrationNote { get; set; }
    }
}
