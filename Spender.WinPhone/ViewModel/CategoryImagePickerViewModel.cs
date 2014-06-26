using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace Spender.WinPhone.ViewModel
{
	public class CategoryImagePickerViewModel : ViewModelBase
	{
		private ObservableCollection<CategoryImageListViewModel> items;

		public ObservableCollection<CategoryImageListViewModel> Items
		{
			get
			{
				if (items == null)
				{
					InitializeItems();
				}
				return items;
			}
			private set { items = value; }
		}

		private void InitializeItems()
		{
			items = new ObservableCollection<CategoryImageListViewModel>();
			items.Add(new CategoryImageListViewModel()
			{
				Title = "Banking",
				Items = new ObservableCollection<CategoryImageViewModel>
				{
					new CategoryImageViewModel{ImageSource = @"\Assets\banking\Account-Payable.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\banking\Accounts-Book.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\banking\Accounts-Recievable.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\banking\Agricultural-Loan.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\banking\ATM.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\banking\Bank.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\banking\Car-loan.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\banking\Cheque.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\banking\Telephone.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\banking\Debit-Card.png"},
				}
			});
			items.Add(new CategoryImageListViewModel()
			{
				Title = "Food",
				Items = new ObservableCollection<CategoryImageViewModel>
				{
					new CategoryImageViewModel{ImageSource = @"\Assets\food\Beverage-Beer-01.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\food\Beverage-Beer-01.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\food\Beverage-Coffee-01.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\food\Beverage-Coffee-02.png"},
				}
			});
			items.Add(new CategoryImageListViewModel()
			{
				Title = "Fun",
				Items = new ObservableCollection<CategoryImageViewModel>
				{
					new CategoryImageViewModel{ImageSource = @"\Assets\fun\IPod.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\fun\Joystick.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\fun\laptop-02.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\fun\Mouse.png"},
				}
			});
			items.Add(new CategoryImageListViewModel()
			{
				Title = "House",
				Items = new ObservableCollection<CategoryImageViewModel>
				{
					new CategoryImageViewModel{ImageSource = @"\Assets\house\Modem-Wireless.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\house\tv-remote.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\house\university.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\house\washing-machine.png"},
					new CategoryImageViewModel{ImageSource = @"\Assets\house\office-01.png"},
				}
			});
		}
	}

	public class CategoryImageListViewModel : ViewModelBase
	{
		private ObservableCollection<CategoryImageViewModel> items;

		public ObservableCollection<CategoryImageViewModel> Items
		{
			get
			{
				if (items == null)
				{
					InitializeItems();
				}
				return items;
			}
			set { items = value; }
		}

		public string Title { get; set; }
		public string Information { get; set; }

		private void InitializeItems()
		{
			items = new ObservableCollection<CategoryImageViewModel>();
		}
	}
}