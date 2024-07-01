using Java.Lang;
using System.Diagnostics;
using ToDoMauiCLient.DataServices;

namespace ToDoMauiCLient
{
    public partial class MainPage : ContentPage
    {
        private readonly IRestDataService _dataService;

        public MainPage(IRestDataService restDataService)
        {
            InitializeComponent();

            _dataService = restDataService;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await _dataService.GetAllToDosAsync();
        }

        async void OnAddToDoClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("---> Add button clicked!");
        }

        async void OnSelectionChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("---> item changed clicked!");
        }
    }

}
