using System;
using System.Linq;
using HMB.GAP2019.Intranet.Core.Announcements;
using HMB.GAP2019.Intranet.Data.Contexts;

namespace HMB.GAP2019.Intranet.Data.Announcements
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly IntranetContext _context;
        public AnnouncementRepository(IntranetContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Announcement announcement)
            => _context.Announcements.Add(announcement);

        public bool Update(Announcement announcement)
        {
            var existingAnnouncement = GetById(announcement.Id);
            if (existingAnnouncement == null)
            {
                return false;
            }

            existingAnnouncement.StartDate = announcement.StartDate;
            existingAnnouncement.EndDate = announcement.EndDate;
            existingAnnouncement.IsHighPriority = announcement.IsHighPriority;
            existingAnnouncement.Title = announcement.Title;
            existingAnnouncement.Body = announcement.Body;

            _context.Announcements.Update(existingAnnouncement);

            return true;
        }

        public bool Delete(int id)
        {
            var announcement = GetById(id);
            if (announcement == null)
            {
                return false;
            }

            _context.Announcements.Remove(announcement);

            return true;
        }

        public Announcement GetById(int id)
            => _context.Announcements.Find(id);

        public IQueryable<Announcement> GetAll()
            => _context.Announcements;

        public void Commit()
            => _context.SaveChanges();
    }
}
