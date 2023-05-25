using System.ComponentModel;

namespace Server.Models
{
    public class Product : INotifyPropertyChanged
    {
        private int _quantity;
        public string Name { get; set; }
        public int Quantity {
            get 
            { return _quantity; } 
            set 
            { _quantity = value;
              OnPropertyChanged(nameof(Quantity));
            } 
        }
        public int PriceShop { get; set; }
        public int PriceClient { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
