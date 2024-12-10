using Domain.DTOs;
using Infrastructure.ExternalClients.Dictionary.Models;

namespace Infrastructure.Mappers
{
    public static class MeaningMappers
    {
        public static List<MeaningDto> ToDto(this List<WordData> data) {
            var result = new List<MeaningDto>();

            foreach (var word in data)
            {
                if(string.IsNullOrEmpty(word.Phonetic))
                    continue;   

                var phoneticsAudio = word.Phonetics.FirstOrDefault(p => !string.IsNullOrEmpty(p.Audio))?.Audio ?? string.Empty;

                foreach (var meaning in word.Meanings)
                {
                    if (string.IsNullOrEmpty(meaning.PartOfSpeech))
                        continue;

                    foreach (var definition in meaning.Definitions)
                    {
                        if (string.IsNullOrEmpty(definition.Definition))
                            continue;

                        result.Add(new MeaningDto
                        {
                            Type = meaning.PartOfSpeech,
                            Definition = definition.Definition,
                            Example = definition.Example,
                            Phonetics = word.Phonetic,
                            PhoneticsAudio = phoneticsAudio
                        });
                    }
                }
            }

            return result;
        }
    }
}
