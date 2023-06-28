using AndreasReitberger.Shared.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace MauiApp_CollectionViewIssue.ViewModels
{
    /*
     * Core  : https://github.com/AndreasReitberger/SharedMauiCoreLibrary
     * Styles: https://github.com/AndreasReitberger/SharedMauiXamlStyles
     */
    public partial class BaseViewModel : ViewModelBase
    {
        #region App
        [ObservableProperty]
        string version = string.Empty;

        [ObservableProperty]
        string build = string.Empty;

        [ObservableProperty]
        bool isBeta = false;

        [ObservableProperty]
        bool isLightVersion = false;

        [ObservableProperty]
        bool isTabletMode = false;

        [ObservableProperty]
        double progress = 0;

        #endregion

        #region Shell
        [ObservableProperty]
        bool keepFlyoutOpen = false;

        /*
        FlyoutBehavior _flyoutBehavior = DeviceInfo.Idiom == DeviceIdiom.Tablet ? FlyoutBehavior.Locked : FlyoutBehavior.Flyout;
        public FlyoutBehavior FlyoutBehavior
        {
            get { return _flyoutBehavior; }
            set { SetProperty(ref _flyoutBehavior, value); }
        }
        */
    public FlyoutBehavior FlyoutBehavior => KeepFlyoutOpen ? FlyoutBehavior.Locked : FlyoutBehavior.Flyout;

        #endregion

        #region Navigation
        [ObservableProperty]
        bool isViewShown = false;

        #endregion

        #region Connection
        [ObservableProperty]
        bool isConnecting = false;

        #endregion

        #region States
        [ObservableProperty]
        bool isListening = false;

        #endregion

        #region Constructor
        public BaseViewModel(IDispatcher dispatcher) : base(dispatcher)
        {
            Dispatcher = dispatcher;
            UpdateVersionBuild();
        }

        protected void LoadSettings()
        {
            IsLoading = true;

            IsLoading = false;
        }
        #endregion

        #region Destructor
        ~BaseViewModel()
        {
            // Unregisters all when the ViewModel is GC.
            WeakReferenceMessenger.Default.UnregisterAll(this);
        }
        #endregion

        #region Commands

        #region Navigation

        [RelayCommand]
        protected Task Close() => Back();

        [RelayCommand]
        protected Task Back() => Shell.Current.GoToAsync("..");

        #endregion

        #endregion

        #region Methods

        protected void UpdateVersionBuild()
        {
            try
            {
                Version = AppInfo.VersionString;
                Build = AppInfo.BuildString;
            }
            catch (Exception exc)
            {
                // Log error
            }
        }
        #endregion

        #region LiveCycle
        /*
        public async Task OnAppearingAsync()
        {

        }
        */

        public void OnDisappearing()
        {

        }
        #endregion
    }
}
