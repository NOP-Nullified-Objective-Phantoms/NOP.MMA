using System;
using System.Collections.Generic;
using System.Text;

namespace NOP.MMA.Core.Journals
{
    public struct BirthplaceInformation
    {
        public string BirthplaceWish { get; set; }
        public string PrimaryExpectedBirthplace { get; set; }
        public string ChangedBirthplace { get; set; }
        public string MidwifeConsultationWish { get; set; }
        public string MidwifeCenterName { get; set; }
        public string MidwifeCenterStreet { get; set; }
        public string MidwifeCenterHouseNumber { get; set; }
        public string MidwifeCenterCity { get; set; }
        public string MidwifeCenterPostalCode { get; set; }
        public string MidwifeCenterPhone { get; set; }

        public bool BirthPreperationWish { get; set; }
        public ConsultationFormat ConFormat { get; set; }
    }
}
