using System.Collections.Generic;

namespace HMB.GAP2019.Intranet.Core.Announcements
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
