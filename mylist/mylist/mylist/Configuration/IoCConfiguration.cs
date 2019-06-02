using Autofac;
using mylist.Viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace mylist.Configuration
{
    public class IoCConfiguration
    {
        public IContainer Container;

        public IoCConfiguration() {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<LoginViewModel>();

            this.Container = builder.Build();
        }

        public LoginViewModel LoginViewModel
        {
            get { return this.Container.Resolve<LoginViewModel>(); }
        }



    }
}
