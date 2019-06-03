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
            builder.RegisterType<MasterPageItemViewModel>();
            builder.RegisterType<ProductListsViewModel>();
            builder.RegisterType<ProductListViewModel>();

            this.Container = builder.Build();
        }

        public LoginViewModel LoginViewModel
        {
            get { return this.Container.Resolve<LoginViewModel>(); }
        }

        public MasterPageItemViewModel MasterPageItemViewModel
        {
            get { return this.Container.Resolve<MasterPageItemViewModel>(); }
        }
        public ProductListsViewModel ProductListViewModel
        {
            get
            {
                return this.Container.Resolve<ProductListsViewModel>();
            }
        }
        public ProductListViewModel ProductListView
        {
            get
            {
                return this.Container.Resolve<ProductListViewModel>();
            }
        }

    }
}
