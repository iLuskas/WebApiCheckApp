﻿using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Core.Interfaces.Services
{
    public interface IServiceInspecao : IServiceBase<Inspecao>
    {
        Inspecao GetInspecaoByEquipIdAndAgeId(int equipamentoId, int agendamentoId);
    }
}
