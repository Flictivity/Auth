using DemoIlyas.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace DemoIlyas.Pages
{
    /// <summary>
    /// Interaction logic for RequestsPage.xaml
    /// </summary>
    public partial class RequestsPage : Page
    {
        private List<Request> Requests = new List<Request>();
        public RequestsPage()
        {
            InitializeComponent();
            Requests = App.Connection.Request.ToList();
            lvRequests.ItemsSource = Requests;
            tbRequestsCount.Text = $"Количество выполненных заявок - {App.Connection.Request.Count(x => x.StatusId == 2)}";
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvRequests.ItemsSource = Requests.Where(x => string.Join(" ", x.Description, x.Model.Name, x.User1?.FullName, x.User?.FullName, x.RequestStatus.Name).ToLower().Contains(tbSearch.Text.ToLower()));
        }
    }
}
