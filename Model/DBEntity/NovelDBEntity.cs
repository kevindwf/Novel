using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.DBEntity
{
    public class NovelDBEntity
    {
        public int NovelId;

        public string NovelName;

        public string NovelAuthor;

        public int CharacterCount;

        public DateTime LatestUpdateDate;

        public bool IsFinished;

        public string NovelDesc;
    }
}
