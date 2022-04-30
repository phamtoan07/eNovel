using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Data.Catalog
{
    public partial class NovelChapterEntity
    {
        private string _title;
        private string _content;
        private int _chapterNum;
        public NovelChapterEntity(string title = null, string content = null, int chapterNum = 0)
        {
            Title = title;
            Content = content;
            ChapterNum = chapterNum;
        }

        public string Title { get => _title; set => _title = value; }
        public string Content { get => _content; set => _content = value; }
        public int ChapterNum { get => _chapterNum; set => _chapterNum = value; }
    }
}
