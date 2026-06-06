using Maui.Models;
using Maui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.ViewModels
{
    public class ShowViewModel
    {
        public List<Student> Products { get; private set; } = new();

        public async Task LoadAsync()
        {
            var service = new StudentService();
            Products = await service.GetAsync();
        }
    }
}
