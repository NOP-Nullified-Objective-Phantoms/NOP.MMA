using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Represents the results of an ultrasound scanning
    /// </summary>
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
        public string FosterRepresentation { get; set; }
        public double AmnioticFluidAmount { get; set; }
        public string Flow { get; set; }
        public string ExaminationLocation { get; set; }
        /// <summary>
        /// The Initials of the persion, who performed the ultrasound scan
        /// </summary>
        public string Initials { get; set; }
    }
}
