using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeneralizedAsyncReturnTypes.CacheTask
{
    public interface IPeopleService
    {
        ValueTask<People> GetPeopleAsync(string name);
        void AddPeople(People people);
    }

    public class PeopleService : IPeopleService
    {
        private ConcurrentDictionary<string, People> _dictionary = new ConcurrentDictionary<string, People>();
        private readonly IPeopleRepository _repository;        

        public PeopleService(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public void AddPeople(People people)
        {
            _repository.AddPeople(people);
        }

        public ValueTask<People> GetPeopleAsync(string name)
        {            
            //if (_dictionary.TryGetValue(name, out var people))
                //return new ValueTask<People>(people);

            Task<People> task = _repository.GetPeopleAsync(name);
            task.ContinueWith(x => _dictionary.TryAdd(x.Result.Nome, x.Result));
            
            return new ValueTask<People>(task);
        }
    }
}
