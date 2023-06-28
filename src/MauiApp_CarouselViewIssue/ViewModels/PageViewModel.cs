using AndreasReitberger.Shared.Core.Theme;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiApp_CollectionViewIssue.ViewModels
{
    /*
     * Core  : https://github.com/AndreasReitberger/SharedMauiCoreLibrary
     * Styles: https://github.com/AndreasReitberger/SharedMauiXamlStyles
     */
    public partial class PageViewModel : BaseViewModel
    {
        #region Module
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RefreshCommand))]
        bool isRefreshing = false;
        #endregion

        #region QueryParameters
        [ObservableProperty]
        string hexColorCode;
        partial void OnHexColorCodeChanged(string value)
        {

        }
        #endregion

        #region Properties

        [ObservableProperty]
        ObservableCollection<ThemeColorInfo> defaultColors = new();

        [ObservableProperty]
        ThemeColorInfo selectedColor;
        #endregion

        #region Constructor, LoadSettings

        public PageViewModel(IDispatcher dispatcher) : base(dispatcher)
        {
            Dispatcher = dispatcher;

            IsLoading = true;
            LoadSettings();
            IsLoading = false;
        }

        new void LoadSettings()
        {
            DefaultColors = new()
            {
                new ThemeColorInfo() { ThemeName = Colors.Gray.ToHex(), PrimaryColor = Colors.Gray },
                new ThemeColorInfo() { ThemeName = Colors.Brown.ToHex(), PrimaryColor = Colors.Brown },
                new ThemeColorInfo() { ThemeName = Colors.Green.ToHex(), PrimaryColor = Colors.Green },
                new ThemeColorInfo() { ThemeName = Colors.Red.ToHex(), PrimaryColor = Colors.Red },
                new ThemeColorInfo() { ThemeName = Colors.Orange.ToHex(), PrimaryColor = Colors.Orange },
                new ThemeColorInfo() { ThemeName = Colors.Blue.ToHex(), PrimaryColor = Colors.Blue },
                new ThemeColorInfo() { ThemeName = Colors.LightGray.ToHex(), PrimaryColor = Colors.LightGray },
                new ThemeColorInfo() { ThemeName = Colors.Teal.ToHex(), PrimaryColor = Colors.Teal },
                new ThemeColorInfo() { ThemeName = Colors.Purple.ToHex(), PrimaryColor = Colors.Purple },
                new ThemeColorInfo() { ThemeName = Colors.Pink.ToHex(), PrimaryColor = Colors.Pink },
                new ThemeColorInfo() { ThemeName = Colors.Beige.ToHex(), PrimaryColor = Colors.Beige },
                new ThemeColorInfo() { ThemeName = Colors.Violet.ToHex(), PrimaryColor = Colors.Violet },
                new ThemeColorInfo() { ThemeName = Colors.Silver.ToHex(), PrimaryColor = Colors.Silver },
                new ThemeColorInfo() { ThemeName = Colors.Gold.ToHex(), PrimaryColor = Colors.Gold },
            };
            SelectedColor =
                DefaultColors?.FirstOrDefault(theme => theme.PrimaryColor?.ToArgbHex() == HexColorCode) ??
                DefaultColors?.FirstOrDefault();
        }
        #endregion

        #region Commands

        #region Save

        [RelayCommand]
        void Save()
        {
            try
            {
                // Pass value back to caller
                string hex = SelectedColor.PrimaryColor.ToHex();//.Replace("#", string.Empty);
               
            }
            catch (Exception exc)
            {
                // Log error
            }
        }
        #endregion

        #region Refreshing
        bool RefreshCommand_CanExcecute() => !IsRefreshing;
        [RelayCommand(CanExecute = nameof(RefreshCommand_CanExcecute))]
        void Refresh()
        {
            try
            {
                IsLoading = true;
                LoadSettings();
                IsLoading = false;
            }
            catch (Exception exc)
            {
                // Log error
            }
            IsRefreshing = false;
        }
        #endregion

        #endregion

        #region Methods
        void LoadCurrentTheme()
        {
            try
            {
                if (!string.IsNullOrEmpty(HexColorCode))
                {
                    SelectedColor =
                        DefaultColors?.FirstOrDefault(themeInfo => themeInfo.PrimaryColor?.ToArgbHex() == HexColorCode) ??
                        DefaultColors.FirstOrDefault(themeInfo => themeInfo.IsAppDefault);
                }
                else
                {
                    SelectedColor = DefaultColors.FirstOrDefault(themeInfo => themeInfo.IsAppDefault);
                }
            }
            catch (Exception exc)
            {
                // Log error
            }
        }
        #endregion

        #region Lifecycle
        /// <summary>
        /// Runs once when the page is created (gets triggered after the 'OnAppearing' function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Pages_Loaded(object sender, EventArgs e)
        {
            LoadCurrentTheme();
        }
        public void OnAppearing()
        {
            try
            {
                IsBusy = true;
                LoadSettings();

                IsStartUp = false;
                IsBusy = false;
            }
            catch (Exception exc)
            {
                //Log error
            }
        }
        #endregion

    }
}
