using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn; /*Somente leitura / connection*/

        public SQLiteDatabaseHelper(string path) /*string define o caminho até onde está o arquivo de texto, o nome vc escolhe (aqui usamos path)*/
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }
        public Task<int> Insert(Produto p)/*Insere*/
        {
            return _conn.InsertAsync(p);
        }
        public Task<List<Produto>> Update(Produto p)/*Altera*/
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
                );
        }
        public Task<int> Delete(int id)/*Deleta apenas o id*/
        { 
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);/*Expressão lambida para exclusão de intens = i*/
        }
        public Task<List<Produto>> GetAll()/*Funcionalidade para listar os produtos*/
        {
            return _conn.Table<Produto>().ToListAsync();
        }
        public Task<List<Produto>> Search(string q) /*Funcionalidade de busca da tabela*/
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + q + "%'"; /*define o parametro para a pesquisa*/

            return _conn.QueryAsync<Produto>(sql);
        }
        
    }
}
