using MauiApp_CollectionViewIssue.ViewModels;

namespace MauiApp_CollectionViewIssue;

public partial class MainPage : ContentPage
{
    public MainPage(PageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        Loaded += ((PageViewModel)BindingContext).Pages_Loaded;
    }
    ~MainPage()
    {
        InitializeComponent();
        Loaded -= ((PageViewModel)BindingContext).Pages_Loaded;
    }

    #region Methods
    protected override void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            ((PageViewModel)BindingContext).OnAppearing();
        }
        catch (Exception) { }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        try
        {
            ((PageViewModel)BindingContext).OnDisappearing();
        }
        catch (Exception) { }
    }
    #endregion
}

