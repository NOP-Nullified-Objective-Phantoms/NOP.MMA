using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    /// <summary>
    /// Defines a set of weight related properties
    /// </summary>
    public struct WeightInfo
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="WeightInfo"/>
        /// </summary>
        /// <param name="_weightBeforePregnancyInKG"></param>
        /// <param name="_heightInCM"></param>
        /// <param name="_bmi"></param>
        public WeightInfo ( double _weightBeforePregnancyInKG, double _heightInCM, double _bmi )
        {
            WeightBeforePregnancyInKG = _weightBeforePregnancyInKG;
            HeightInCM = _heightInCM;
            BMI = _bmi;
        }
        public double WeightBeforePregnancyInKG { get; set; }
        public double HeightInCM { get; set; }
        public double BMI { get; set; }
    }
}
