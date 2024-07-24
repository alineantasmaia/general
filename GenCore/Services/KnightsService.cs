using GenCore.Domain;
using GenCore.Interface.Services;
using GenCore.Interface.Repositories;

namespace GenCore.Services
{
    public class KnightsService : KnightIService
    {
        KnightIRepository _repositorioKnight;
        
        public KnightsService(KnightIRepository repositorioKnight)
        {
            _repositorioKnight = repositorioKnight;
        }
        public bool Incluir(Knight knight)
        {
            ValidarObjeto(knight);
            return _repositorioKnight.Incluir(knight).IsCompletedSuccessfully;
        }

        public Task<IEnumerable<Knight>> Obter(string id)
        {
            return _repositorioKnight.Obter(id);
        }

        public bool Atualizar(Knight knight)
        {
            return _repositorioKnight.Alterar(knight).IsCompletedSuccessfully;
        }

        public bool Excluir(string id)
        {
            return _repositorioKnight.Excluir(id).IsCompletedSuccessfully;
        }

        private void ValidarObjeto(Knight knight)
        {
            if (knight.Id.Equals(null))
            {
                throw new Exception("Obrigatório informar a chave id!");
            }
        }
    }
}
