using System.Collections.Generic;

namespace CGI.SOAR.Intranet.Core.Announcements
{
    public interface IAnnouncementService
    {
        bool CreateAnnouncement(Announcement announcement);
        bool UpdateAnnouncement(Announcement announcement);
        bool RemoveAnnouncement(int id);
        IEnumerable<Announcement> GetActiveAnnouncements();
        IEnumerable<Announcement> GetAllAnnouncements();
    }
}
