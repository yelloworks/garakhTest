using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace garakhTest.Models
{
    [Serializable]
    [JsonObject]
    public class JsonResponse<T>
    {
        public int current = 1;
        public int rowCount = 10;
        public List<T> rows;
        public int total;

        public JsonResponse(IEnumerable<T> items)
        {
            rows = items.ToList();
            total = rows.Count;
        }

    }
}