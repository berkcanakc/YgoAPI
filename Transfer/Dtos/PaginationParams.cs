using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transfer.Dtos
{
    public class PaginationParams
    {
        public const int _maxItemsPerPage = 50;
        public int Page { get; set; } = 1;

        private int _ItemsPerPage = 10;
        public int ItemsPerPage
        {
            get
            {
               return _ItemsPerPage;
            }
            set
            {
                _ItemsPerPage = (value > _maxItemsPerPage) ? _maxItemsPerPage : value;
            }

        }
    }
}
