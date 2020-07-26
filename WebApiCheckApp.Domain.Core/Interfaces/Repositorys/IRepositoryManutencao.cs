using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryManutencao : IRepositoryBase<Manutencao>
    {
        public Manutencao GetManutencaoByEquipIdAndAgeId(int equipamentoId, int agendamentoId);
    }
}
