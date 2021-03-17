using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public struct UltrasoundResult
    {
        public DateTime Date { get; set; }
        public string GestationAge { get; set; }
        /// <summary>
        /// The estemated weight of the child at the scan
        /// </summary>
        public double USWeight { get; set; }
        /// <summary>
        /// The difference in weight in percentage (%) based on the optimal estimated weight of the child
        /// </summary>
        public double WeightDifference { get; set; }
        string FosterRepresentation { get; set; }
        public double AmnioticFluidAmount { get; set; }
        public string Flow { get; set; }
        public string ExaminationLocation { get; set; }
        public string Initials { get; set; }
    }
}
