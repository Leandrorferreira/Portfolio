using System.Collections.Generic;

namespace Model.Dao
{
    public interface ICrud<Classe>
    {

        void cadastrar(Classe obj);

        void excluir(Classe obj);

        void alterar(Classe obj);

        bool buscar(Classe obj);

        List<Classe> buscarTudo();
    }
}
