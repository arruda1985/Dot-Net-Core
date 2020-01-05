using Entity;
using System.Collections.Generic;

namespace Contract
{
    public interface IPacienteRepository
    {
        void Salvar(Paciente paciente);
        Paciente Obter(int id);
        ICollection<Paciente> Obter();
    }
}
