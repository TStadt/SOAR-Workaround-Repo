using System.Linq;

namespace CGI.SOAR.Intranet.Core.Announcements
{
    public interface IAnnouncementRepository
    {
        void Add(Announcement announcement);
        bool Update(Announcement announcement);
        bool Delete(int id);
        Announcement GetById(int id);
        IQueryable<Announcement> GetAll();
        void Commit();
    }
}
