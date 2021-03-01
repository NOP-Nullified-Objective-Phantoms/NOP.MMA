using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public interface IResourceAndRiskAssessment
    {
        string Assessment { get; set; }
        NiveauDist NiveauDistrubution { get; set; }
        bool NeedObstetricAssessment { get; set; }
        string ObstetricAssessmentNote { get; set; }
        bool NeedSocialAndHealthAdministration { get; set; }
        string SocialAndHealthAdministrationNote { get; set; }
    }
}