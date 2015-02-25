using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMargin.Model
{
    public class Category : INotifyPropertyChanged
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Category()
        {

        }

        public Category(string CategoryName)
        {
            this.CategoryName = CategoryName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
