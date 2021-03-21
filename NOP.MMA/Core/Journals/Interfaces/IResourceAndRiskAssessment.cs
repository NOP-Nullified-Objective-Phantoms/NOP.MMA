using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// A summary of a patients ressource and risk assessement
    /// </summary>
    public interface IResourceAndRiskAssessment
    {
        string Assessment { get; set; }
        /// <summary>
        /// The distrubution of propositions
        /// </summary>
        NiveauDist NiveauDistrubution { get; set; }
        bool NeedObstetricAssessment { get; set; }
        string ObstetricAssessmentNote { get; set; }
        bool NeedSocialAndHealthAdministration { get; set; }
        string SocialAndHealthAdministrationNote { get; set; }
    }
}