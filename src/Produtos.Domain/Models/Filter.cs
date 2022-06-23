using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Domain.Models
{
    public class Filter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string CodigoFornecedor { get; set; }

        public Filter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public Filter(int pageNumber, int pageSize, string codigoFornecedor)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
            this.CodigoFornecedor = codigoFornecedor;
        }
    }
}
