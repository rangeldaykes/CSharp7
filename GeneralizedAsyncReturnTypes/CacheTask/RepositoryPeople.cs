using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace GeneralizedAsyncReturnTypes.CacheTask
{
    public interface IPeopleRepository
    {
        Task<People> GetPeopleAsync(string name);
        void AddPeople(People people);
    }

    public class RepositoryPeople : IPeopleRepository
    {
        ConcurrentDictionary<string, People> _dictionary = new ConcurrentDictionary<string, People>();
        public Task<People> GetPeopleAsync(string name)
        {
            // local function
            async Task<People> GetPeople(string namePeople)
            {
                await Task.Delay(5000);
                return _dictionary[namePeople]; 
            }

            var people = Task.Run(() => GetPeople(name));

            return people;
        }

        public void AddPeople(People people)
        {
            _dictionary[people.Nome] = people;
        }
    }
}
