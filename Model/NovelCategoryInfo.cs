using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Model
{
    public class NovelCategoryInfo
    {
        private static readonly List<Tuple<int, string, string>> _categoryLookUpList=new List<Tuple<int, string, string>>()
                                                                                        {
                                                                                            new Tuple<int, string, string>(8, "其他小说","others"),
                                                                                            new Tuple<int, string, string>(1, "玄幻小说","xuanhuan"),
                                                                                            new Tuple<int, string, string>(2, "修真小说","xiuzhen"),
                                                                                            new Tuple<int, string, string>(3, "都市小说","doushi"),
                                                                                            new Tuple<int, string, string>(4, "穿越小说","chuanyue"),
                                                                                            new Tuple<int, string, string>(5, "网游小说","wangyou"),
                                                                                            new Tuple<int, string, string>(6, "科幻小说","kehuan"),
                                                                                            new Tuple<int, string, string>(7, "美文同人","meiwen"),
                                                                                        };
        private string _categoryName;
        private string _categoryUrl;
        private int _categoryId;

        public NovelCategoryInfo(string categoryName)
        {
            _categoryName = categoryName;
            _categoryId = GetCategoryId(_categoryName);
            _categoryUrl = GetCategoryUrl(_categoryName);
        }

        public string CategoryName
        {
            get { return _categoryName; }
        }

        public string CategoryUrl
        {
            get { return _categoryUrl; }
        }

        public int CategoryId
        {
            get { return _categoryId; }
        }

        public static List<Tuple<int, string, string>> GetCategoryLookupList()
        {
            return _categoryLookUpList;
        }

        private string GetCategoryUrl(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName)) return "";

            return _categoryLookUpList.FirstOrDefault(t => string.Compare(t.Item2, categoryName) == 0 ).Item2;
            
        }

        private int GetCategoryId(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName)) return 0;

            return _categoryLookUpList.FirstOrDefault(t => string.Compare(t.Item2, categoryName) == 0).Item1;
        }

        public static int GetCategoryIdByUrl(string url)
        {
            return _categoryLookUpList.FirstOrDefault(t => string.Compare(t.Item3, url) == 0).Item1;
            
        }

    }
}
