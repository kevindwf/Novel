using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public static class IdMappingHelper
    {
        private static readonly List<KeyValuePair<int, int>> _IdMapping = new List<KeyValuePair<int, int>>()
                                                                              {
                                                                                  new KeyValuePair<int, int>(0, 4),
                                                                                  new KeyValuePair<int, int>(1, 3),
                                                                                  new KeyValuePair<int, int>(2, 9),
                                                                                  new KeyValuePair<int, int>(3, 7),
                                                                                  new KeyValuePair<int, int>(4, 1),
                                                                                  new KeyValuePair<int, int>(5, 0),
                                                                                  new KeyValuePair<int, int>(6, 8),
                                                                                  new KeyValuePair<int, int>(7, 2),
                                                                                  new KeyValuePair<int, int>(8, 5),
                                                                                  new KeyValuePair<int, int>(9, 6)
                                                                              };

        public static int EncodeId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id should larger than 0");
            }

            var sb = new StringBuilder();
            id.ToString().ToList().ForEach(i => sb.Append(_IdMapping.Find(k => k.Key == int.Parse(i.ToString())).Value));

            return int.Parse(sb.ToString());
        }

        public static int DecodeId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id should larger than 0");
            }

            var sb = new StringBuilder();
            id.ToString().ToList().ForEach(i=>sb.Append(_IdMapping.Find(v=>v.Value==int.Parse(i.ToString())).Key));

            return int.Parse(sb.ToString());
        }
    }
}
