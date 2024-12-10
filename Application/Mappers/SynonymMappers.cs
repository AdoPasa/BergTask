using Application.Synonyms.Models;
using Domain.Entities;

namespace Application.Mappers
{
    public static class SynonymMappers
    {
        public static SynonymResponse ToResponse(this Synonym model) {
            return new SynonymResponse
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Meanings = model.Meanings.Select(m => new MeaningResponse { 
                    Type = m.Type,
                    Definition = m.Definition,
                    Example = m.Example,
                    Phonetics = m.Phonetics,
                    PhoneticsAudio = m.PhoneticsAudio,
                }).ToList(),
            };
        }
    }
}
