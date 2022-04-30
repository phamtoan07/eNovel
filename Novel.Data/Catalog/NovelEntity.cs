using Novel.Data.Security;
using Novel.Data.Author;
using System;
using System.Collections.Generic;

namespace Novel.Data.Catalog
{
    public partial class NovelEntity : BaseEntity, IAclSupported, IAuthorMappingSupported
    {
        public string Title { get; set; }
        public int VolumeNum { get; set; }
        public string VolumeTile { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Status { get; set; }
        public bool IsFinished { get; set; }
        public bool ShowOnHomePage { get; set; }
        public double AvgRate { get; set; }
        public string Icon { get; set; }
        public string LongDescImg { get; set; }
        public ICollection<string> NovelTags { get; set; }
        public ICollection<NovelChapterEntity> NovelChapter { get; set; }

        /// <summary>
        /// Gets or sets the available start date and time
        /// </summary>
        public DateTime? AvailableStartDateTimeUtc { get; set; }
        /// <summary>
        /// Gets or sets the available end date and time
        /// </summary>
        public DateTime? AvailableEndDateTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets a required product identifiers (comma separated)
        /// </summary>
        public string RequiredNovelIds { get; set; }

        public bool SubjectToAcl { get; set; }

        public IList<string> CustomerRoles { get; set; }

        public bool LimitedToAuthor { get; set; }
        public IList<string> Authors { get; set; }

        public NovelEntity(string title = null, int volumeNum = 0, string shortDesc = null, string longDesc = null, DateTime publishedDate = default, string status = null, bool isFinished = false, bool showOnHomePage = false, double avgRate = 0, string icon = null, string longDescImg = null, ICollection<string> novelTags = null, ICollection<NovelChapterEntity> novelChapter = null)
        {
            Title = title;
            VolumeNum = volumeNum;
            ShortDesc = shortDesc;
            LongDesc = longDesc;
            PublishedDate = publishedDate;
            Status = status;
            IsFinished = isFinished;
            ShowOnHomePage = showOnHomePage;
            AvgRate = avgRate;
            Icon = icon;
            LongDescImg = longDescImg;
            NovelTags = novelTags;
            NovelChapter = novelChapter;
        }
    }
}
