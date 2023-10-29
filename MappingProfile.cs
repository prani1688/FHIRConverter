extern alias R3;
using AutoMapper;

using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class R3ToR4MappingProfile : Profile
{
    public R3ToR4MappingProfile()
    {
        CreateMap<R3.Hl7.Fhir.Model.MedicationStatement, MedicationStatement>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id property to generate a new one for R4
            .ForMember(dest => dest.Meta, opt => opt.Ignore()) // Ignore Meta property for simplicity
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text)) // Map Text property directly
            .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject)) // Map Subject property directly
            .ForMember(dest => dest.DateAsserted, opt => opt.MapFrom(src => src.DateAsserted)) // Map DateAsserted property directly
            .ForMember(dest => dest.TakenElement, opt => opt.MapFrom(src => new Code<Hl7.Fhir.Model.MedicationStatement.MedicationStatementTaken>((Hl7.Fhir.Model.MedicationStatement.MedicationStatementTaken)Enum.Parse(typeof(Hl7.Fhir.Model.MedicationStatement.MedicationStatementTaken), src.Taken.ToString())))
            // Map Taken property with custom logic to handle changes in R4
            .ForMember(dest => dest.ReasonCode, opt => opt.MapFrom(src => src.ReasonCode)) // Map ReasonCode property directly
            .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note)) // Map Note property directly
            .ForMember(dest => dest.Dosage, opt => opt.MapFrom(src => src.Dosage)); // Map Dosage property directly

        CreateMap<Dosage, Dosage>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id property to generate a new one for R4
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text)) // Map Text property directly
            .ForMember(dest => dest.Sequence, opt => opt.MapFrom(src => src.Sequence)) // Map Sequence property directly
            .ForMember(dest => dest.AdditionalInstruction, opt => opt.MapFrom(src => src.AdditionalInstruction)) // Map AdditionalInstruction property directly
            .ForMember(dest => dest.Timing, opt => opt.MapFrom(src => src.Timing)) // Map Timing property directly
            .ForMember(dest => dest.AsNeededCodeableConcept, opt => opt.MapFrom(src => src.AsNeededCodeableConcept)) // Map AsNeededCodeableConcept property directly
            .ForMember(dest => dest.Route, opt => opt.MapFrom(src => src.Route)) // Map Route property directly
            .ForMember(dest => dest.DoseAndRate, opt => opt.MapFrom(src => src.DoseAndRate)); // Map DoseAndRate property directly
    }
}
