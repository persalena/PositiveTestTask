﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public static class IoC
    {

        private static IContainer _container;

        private static readonly object _sync = new object();

        public static IContainer Instance
        {
            get
            {
                if (_container != null)
                {
                    return _container;
                }

                lock (_sync)
                {
                    if (_container == null)
                    {
                        _container = new ContainerBuilder().Build();
                    }
                }

                return _container;
            }
        }

        public static void Initialize(params Module[] modules)
        {
            var builder = new ContainerBuilder();
            foreach (var module in modules)
            {
                builder.RegisterModule(module);
            }

            lock (_sync)
            {
                _container = builder.Build();
            }
        }

        public static void Update(params Module[] modules)
        {
            var builder = new ContainerBuilder();
            foreach (var module in modules)
            {
                builder.RegisterModule(module);
            }

            lock (_sync)
            {
                builder.Update(_container);
            }
        }
    }
}

