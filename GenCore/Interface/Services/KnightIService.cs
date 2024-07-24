using GenCore.Domain;

namespace GenCore.Interface.Services
{
    public interface KnightIService
    {
        Task<IEnumerable<Knight>> Obter(string id);
        bool Incluir(Knight knight);
        bool Atualizar(Knight knight);
        bool Excluir(string id);
    }
}
