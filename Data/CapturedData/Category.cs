using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Data.CapturedData
{
    public class Category
    {
        
        public List<Tuple<int, string, string>> GetNovelCategoryLookupList()
        {
            return Model.NovelCategoryInfo.GetCategoryLookupList();
        }

        public int GetCategoryIdByUrl(string url)
        {
            return NovelCategoryInfo.GetCategoryIdByUrl(url);
        }
    }
}
