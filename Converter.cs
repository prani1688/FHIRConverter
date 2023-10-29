extern alias R3;

using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHIR.HL7
{
    internal class Converter
    {
        public void ConvertR3ToR4()
        {
            var r3=new R3.Hl7.Fhir.Model.MedicationRequest();
            var r4 = new MedicationRequest();
        }
    }
}
