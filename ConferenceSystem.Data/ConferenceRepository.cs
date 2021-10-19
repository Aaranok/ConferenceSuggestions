using ConferencePlannerApp.Abstractions;
using ConferenceSystem.Models;
using Microsoft.EntityFrameworkCore;
using RatingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConferenceSystem.Data
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly SuggestionsDbContext _dbContext;

        public ConferenceRepository(SuggestionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ConferenceXAttendee>> GetConferencesAsync(int conferenceId, string atendeeEmail, CancellationToken cancellationToken = default)
        {
            var conferences = await _dbContext.ConferenceXAttendee
                .Where(c => c.ConferenceId != conferenceId && c.AttendeeEmail != atendeeEmail && c.StatusId == Status.Joined.Id)
                .ToListAsync(cancellationToken);

            return conferences;
        }

        public async Task<List<ConferenceXAttendee>> GetConferencesAsync(string[] atendeeEmails, CancellationToken cancellationToken = default)
        {
            var conferences = await _dbContext.ConferenceXAttendee
                .Where(c => atendeeEmails.Contains(c.AttendeeEmail) && c.StatusId == Status.Joined.Id)
                .Include(x => x.Conference)
                .ToListAsync(cancellationToken);

            return conferences;
        }

        public async Task<List<Conference>> GetConferencesAsync(int[] ids, CancellationToken cancellationToken = default)
        {
            var conferences = await _dbContext.Conferences
                .Where(c => ids.Contains(c.Id))
                .ToListAsync(cancellationToken);

            return conferences.ToList();
        }
    }
}
