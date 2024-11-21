using FreshShoop.Models;
using FreshShoop.ViewModel;
namespace FreshShoop.ViewModel
{
    public class CategoeryEditView:CategoryView
    {
        public string Id { get; set; } = null!;
        public string Status { get; set; } = null!;

        public string ExistingPath { get; set; }
    }
}
