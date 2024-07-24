using GenCore.Domain;

namespace GenCore.Interface.Repositories
{
    public interface KnightIRepository
    {
        Task Incluir(Knight knight);
        Task<bool> Alterar(Knight knight);
        Task<IEnumerable<Knight>> Obter(string id);
        Task<bool> Excluir(string id);
    }
}
