using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// A set of flags that defines the level of propositions for a patient
    /// </summary>
    public enum NiveauDist
    {
        BasicOffer,
        ExtendedBasicOffer,
        ExtendedBasicOfferAndInterdisciplinaryCollaboration,
        CollaborationWithSpecializedInstitutions
    }
}