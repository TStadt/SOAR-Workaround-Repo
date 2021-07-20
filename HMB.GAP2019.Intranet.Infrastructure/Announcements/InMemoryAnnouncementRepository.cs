using System.Collections.Generic;
using System.Linq;
using HMB.GAP2019.Intranet.Core.Announcements;

namespace HMB.GAP2019.Intranet.Infrastructure.Announcements
{
    public class InMemoryAnnouncementRepository : IAnnouncementRepository
    {
        private static readonly List<Announcement> _storage = new List<Announcement>();

        public void Add(Announcement announcement)
        {
            announcement.Id = _storage.Select(a => a.Id).DefaultIfEmpty(1).Max();
            _storage.Add(announcement);
        }

        public void Commit() { }

        public bool Delete(int id)
        {
            var itemToRemove = GetById(id);
            if (itemToRemove == null)
            {
                return false;
            }

            _storage.Remove(itemToRemove);
            return true;
        }


        public IQueryable<Announcement> GetAll()
            => _storage.AsQueryable();

        public Announcement GetById(int id)
            => _storage.FirstOrDefault(i => i.Id == id);

        public bool Update(Announcement announcement)
        {
            var updateIndex =_storage.FindIndex(a => a.Id == announcement.Id);
            if (updateIndex < 0)
            {
                return false;
            }

            _storage[updateIndex] = announcement;
            return true;
        }
    }
}
