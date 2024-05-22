﻿using System.Collections;
using System.Collections.Generic;
using Talabat.APIs.DTOs;

namespace Talabat.APIs.Helpers
{
    public class Pagination<T>
    {

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IEnumerable<T> Data { get; set; }



        public Pagination(int pageIndex, int pageSize, int count, IEnumerable<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }


    }
}
