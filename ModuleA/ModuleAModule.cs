﻿using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            // _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
            containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
        }
    }
}