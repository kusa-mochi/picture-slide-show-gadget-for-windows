﻿using PictureSlideShowGadget.Views;
using System.Windows;
using Prism.Modularity;
using DryIoc;
using Prism.DryIoc;

namespace PictureSlideShowGadget
{
    class Bootstrapper : DryIocBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            //moduleCatalog.AddModule(typeof(YOUR_MODULE));
        }
    }
}
