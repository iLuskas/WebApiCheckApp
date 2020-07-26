﻿using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryInspecao: IRepositoryBase<Inspecao>
    {
        Inspecao GetInspecaoByEquipIdAndAgeId(int equipamentoId, int agendamentoId);
    }
}
