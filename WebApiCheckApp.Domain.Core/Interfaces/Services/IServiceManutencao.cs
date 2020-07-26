using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Core.Interfaces.Services
{
    public interface IServiceManutencao : IServiceBase<Manutencao>
    {
        public Manutencao GetManutencaoByEquipIdAndAgeId(int equipamentoId, int agendamentoId);
    }
}
