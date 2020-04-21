﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiCheckApp.Infrastruture.CrossCutting.IOC
{
    public class ModuleIOC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Carrega IOC

            ConfigurationIOC.Load(builder);

            #endregion
        }
    }
}
