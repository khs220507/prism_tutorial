using ModuleA.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace MyPrismApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                SetProperty(ref _isChecked, value);
                NavigateCommand.RaiseCanExecuteChanged();
            }
        }

        private DelegateCommand<string> _navigateCommand;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteCommandName, canExecuteCommand).ObservesCanExecute(() => IsChecked));

        private bool canExecuteCommand(string arg)
        {
            return IsChecked;
        }

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            
        }

        void ExecuteCommandName(string viewName)
        {
            var p = new NavigationParameters();
            p.Add("id", 23);
            _regionManager.RequestNavigate("ContentRegion", viewName, p);
            _eventAggregator.GetEvent<MessageEvent>().Publish($"Navigated to {viewName}");
        }
    }
}
