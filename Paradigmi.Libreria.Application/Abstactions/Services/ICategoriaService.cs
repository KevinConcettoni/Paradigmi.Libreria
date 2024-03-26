using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Abstactions.Services
{
    public interface ICategoriaService
    {
        bool AggiungiCategoria(string nome);
        bool EliminaCategoria(string nome);
    }
}
