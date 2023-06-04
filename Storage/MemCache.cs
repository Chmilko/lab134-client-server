using System;
using System.Collections.Generic;
using System.Linq;
using lab123.Models;

namespace lab123.Storage
{
    public class MemCache : IStorage<Data>
    {
        private object _sync = new object();
        private List<Data> _memCache = new List<Data>();
        public Data this[Guid id]
        {
            get
            {
                lock (_sync)
                {
                    if (!Has(id)) throw new IncorrectDataException($"No Data with id {id}");

                    return _memCache.Single(x => x.Id == id);
                }
            }
            set
            {
                if (id == Guid.Empty) throw new IncorrectDataException("Cannot request Data with an empty id");

                lock (_sync)
                {
                    if (Has(id))
                    {
                        RemoveAt(id);
                    }

                    value.Id = id;
                    _memCache.Add(value);
                }
            }
        }

        public System.Collections.Generic.List<Data> All => _memCache.Select(x => x).ToList();

        public void Add(Data value)
        {
            if (value.Id != Guid.Empty) throw new IncorrectDataException($"Cannot add value with predefined id {value.Id}");

            value.Id = Guid.NewGuid();
            this[value.Id] = value;
        }

        public bool Has(Guid id)
        {
            return _memCache.Any(x => x.Id == id);
        }

        public void RemoveAt(Guid id)
        {
            lock (_sync)
            {
                _memCache.RemoveAll(x => x.Id == id);
            }
        }
    }
}