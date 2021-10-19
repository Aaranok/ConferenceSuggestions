using RatingSystem.Data;
using System.Collections.Generic;
using System.Linq;

namespace RatingSystem.Application.Services
{
    public class NewIban
    {
        private readonly SuggestionsDbContext _dbContext;

        public NewIban(SuggestionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetNewIban()
        {
            List<string> ibans = _dbContext.BankAccounts.Select(x => x.Iban).ToList();
           
            if (ibans.Count == 0)
                return "1";

            return (long.Parse(ibans.Last()) + 1).ToString();
        }
    }
}
