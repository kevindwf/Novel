using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class NovelInfo
    {
        private string m_NovelUrl;

        public int NovelId
        {
            get
            {
                int id;
                int.TryParse(m_NovelUrl.TrimEnd('/').Split('/').Last(), out id);
                return IdMappingHelper.EncodeId(id);
            }
        }

        public string NovelName { get; set; }

        public NovelCategoryInfo NovelCategory { get; set; }

        public string NovelUrl
        {
            get
            {
                //output: /novel/[decoded Id]/
                return string.Format("/novel/{0}/", NovelId);
            }
            set
            {
                //input: http://www.cxzww.com/shtml/78/78344/
                m_NovelUrl = value;
            }
        }

        public string NovelImage { get; set; }

        public string NovelAuthor { get; set; }

        public int CharacterCount { get; set; }

        public DateTime LatestUpdateDate { get; set; }

        public bool IsFinished { get; set; }

        public string NovelDesc { get; set; }
    }
}
