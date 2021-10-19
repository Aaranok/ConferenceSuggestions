using MediatR;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConferenceSystem.Models;
using ConferencePlannerApp.Abstractions;

namespace ConferencePlannerApp.Queries
{
    public class SuggestionsQuery
    {
        public class Query : IRequest<List<Conference>>
        {
            public string AttendeeEmail { get; set; }
            public int ConferenceId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, List<Conference>>
        {
            private readonly IConferenceRepository _repository;
            private readonly IConfiguration _configuration;
            
            public QueryHandler(IConferenceRepository repository, IConfiguration configuration)
            {
                _repository = repository;
                _configuration = configuration;
            }
            
            public async Task<List<Conference>> Handle(Query request, CancellationToken cancellationToken)
            {

                var conferences = await _repository.GetConferencesAsync(request.ConferenceId, request.AttendeeEmail, cancellationToken);
                var attendeeEmails = conferences.Select(x => x.AttendeeEmail).ToArray();
                var listOfRecommendedConferences = conferences
                    .Where(c => c.ConferenceId != request.ConferenceId)
                    .ToList();
                var suggestionsCount = _configuration.GetValue("SuggestionsCount", 3);
                var ids = listOfRecommendedConferences.GroupBy(v => v.ConferenceId)
                    .ToDictionary(x => x.Key, y => y.Count())
                    .OrderByDescending(d => d.Value)
                    .Take(suggestionsCount)
                    .Select(keyValuePair => keyValuePair.Key)
                    .ToArray();
                var list =  await _repository.GetConferencesAsync(ids, cancellationToken);
                return list;
            }

        }
    }
}