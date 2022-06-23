using System;

namespace Produtos.Domain.Models
{
    public class Produto : BaseEntity
    {
        public Produto(string descricao, bool situacao, DateTime dataFabricacao, DateTime dataValidade, string codigoFornecedor, string descricaoFornecedor, string cnpjFornecedor)
        {
            ValidarDatas(dataFabricacao, dataValidade);
            Descricao = descricao;
            Situacao = situacao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            CodigoFornecedor = codigoFornecedor;
            DescricaoFornecedor = descricaoFornecedor;
            CnpjFornecedor = cnpjFornecedor;
        }

        public string Descricao{ get; private set; }
        public bool Situacao { get; private set; }
        public DateTime DataFabricacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public string CodigoFornecedor { get; private set; }
        public string DescricaoFornecedor { get; private set; }
        public string CnpjFornecedor { get; private set; }

        public void Update(string descricao, bool situacao, DateTime dataFabricacao, DateTime dataValidade, string codigoFornecedor, string descricaoFornecedor, string cnpjFornecedor)
        {
            ValidarDatas(dataFabricacao, dataValidade);
        }

        public void Delete(bool situacao)
        {
            Situacao = situacao;
        }

        private void ValidarDatas(DateTime dataFabricacao, DateTime dataValidade)
        {
            if (dataFabricacao.Date >= dataValidade.Date)
                throw new InvalidOperationException("data de fabricação que não pode ser maior ou igual a data de validade");
        }
    }
}