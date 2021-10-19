using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ConferenceSystem.Models;

namespace ConferencePlannerApp.Abstractions
{
    public interface IConferenceRepository
    {
        Task<List<ConferenceXAttendee>> GetConferencesAsync(int conferenceId, string atendeeEmail, CancellationToken cancellationToken = default);
        Task<List<ConferenceXAttendee>> GetConferencesAsync(string[] atendeeEmail, CancellationToken cancellationToken = default);
        Task<List<Conference>> GetConferencesAsync(int[] ids, CancellationToken cancellationToken = default);

    }
}