using GenCore.Services;
using GenCore.Interface.Repositories;
using GenCore.Domain;

namespace GenCore.Facade
{
    public class KnightFacade
    {
        KnightsService _knightsService;
        KnightIRepository repositorioKnight;
        public KnightFacade()
        {
            _knightsService = new KnightsService(repositorioKnight);            
        }

        public Task<IEnumerable<Knight>> ListKnights(string id)
        {
            return _knightsService.Obter(id);
        }

        public bool InsertKnights(Knight knight)
        {
            return _knightsService.Incluir(knight);
        }

        public bool UpdateKnights(Knight knight)
        {
            return _knightsService.Atualizar(knight);
        }
        public bool DeleteKnights(string id)
        {
            return _knightsService.Excluir(id);
        }
    }
}
