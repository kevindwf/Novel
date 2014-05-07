using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class NovelInfo
    {
        public int NovelId {get;set;}

        public string NovelName { get; set; }

        public string NovelType { get; set; }

        public string NovelTypeUrl { get; set; }

        public string NovelUrl { get; set; }

        public string NovelImage { get; set; }

        public string NovelAuthor { get; set; }

        public int CharacterCount { get; set; }

        public DateTime LatestUpdateDate { get; set; }

        public bool IsFinished { get; set; }

        public string NovelDesc { get; set; }
    }
}
