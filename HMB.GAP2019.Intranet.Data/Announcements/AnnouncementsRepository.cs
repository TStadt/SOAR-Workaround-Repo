using HMB.GAP2019.Intranet.Core.Announcements;
using HMB.GAP2019.Intranet.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMB.GAP2019.Intranet.Data.Announcements
{
    public class AnnouncementsRepository : IAnnouncementRepository 
    {
        /* dependency injection */
        private readonly IntranetContext _context;

        public AnnouncementsRepository(IntranetContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public void Add(Announcement announcement)
        {
            _context.Announcements.Add(announcement);
        }

        public bool Update(Announcement announcement)
        {
            var result = _context.Announcements.Update(announcement).State;
            if (result.Equals(EntityState.Modified))
            {
                return true;
            } else
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            Announcement entity = _context.Announcements.Find(id);
            var result = _context.Announcements.Remove(entity).State;
            if (result.Equals(EntityState.Deleted))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Announcement GetById(int id)
        {
            return _context.Announcements.Find(id);
        }

        public IQueryable<Announcement> GetAll()
        {
            return _context.Announcements.AsQueryable();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
