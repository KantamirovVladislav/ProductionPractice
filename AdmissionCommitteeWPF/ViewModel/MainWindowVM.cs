
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Input;
using AdmissionCommitteeWPF.Models;
using DataBaseClassLibrary.Entities;
using DataBaseClassLibrary.Methods;
using MaterialDesignThemes.Wpf;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using AdmissionCommitteeWPF.Pages;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AdmissionCommitteeWPF.ViewModel;

public class MainWindowVM: ViewModelBase
{
    private Page _currentPage;

    private NavigationItems _selectedPage;

    public Page CurrentPage
    {
        get
        {
            return _currentPage;
        }
        set
        {
            
            _currentPage = value;
        }
    }

    public NavigationItems SelectedPage
    {
        get => _selectedPage;
        set
        {
            try
            {
                _selectedPage = value;
                if (_selectedPage != null) 
                {
                    if (SelectedPage.Title == "Таблицы")
                    {
                        CurrentPage = new TablesView();
                        OnPropertyChanged("CurrentPage");
                    }
                    else if (SelectedPage.Title == "Данные документов")
                    {
                        CurrentPage = new OperatorView();
                        OnPropertyChanged("CurrentPage");
                    }
                    else if (SelectedPage.Title == "Приёмная комиссия")
                    {
                        CurrentPage = new CommissionView();
                        OnPropertyChanged("CurrentPage");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
    public ObservableCollection<NavigationItems> _NavigationItems { get; }
    
     // private Dictionary<string, ObservableCollection<NavigationItems>> _dictOfUserItem =
     //    new Dictionary<string, ObservableCollection<NavigationItems>>
     //    {
     //        {
     //            "administrator", new ObservableCollection<NavigationItems>
     //            {
     //                new NavigationItems { Title = "Таблицы", Notification = "", SelectedIcon =  PackIconKind.FileTableBoxMultiple, UnselectedIcon = PackIconKind.FileTableBoxMultipleOutline },
     //                new NavigationItems {Title = "Данные документов", Notification = "", SelectedIcon = PackIconKind.AccountTieHat, UnselectedIcon = PackIconKind.AccountTieHatOutline},
     //                new NavigationItems {Title = "Приёмная комиссия", Notification = "", SelectedIcon = PackIconKind.Gavel, UnselectedIcon = PackIconKind.Gavel}
     //            }
     //        }
     //    };
     public MainWindowVM()
     {
         // string jsonString = JsonSerializer.Serialize(_dictOfUserItem);
         // File.WriteAllText("NavigationItem.json", jsonString);
         
         _NavigationItems = LoadNavigationMenu()["administrator"];
         _currentPage = new OperatorView();
         OnPropertyChanged("CurrentPage");
     }
     
     private Dictionary<string, ObservableCollection<NavigationItems>>? LoadNavigationMenu(){
         using (FileStream fs = new FileStream("NavigationItem.json", FileMode.Open))
         {
             Dictionary<string, ObservableCollection<NavigationItems>>? menuItems = JsonSerializer.Deserialize<Dictionary<string, ObservableCollection<NavigationItems>>>(fs);
             return menuItems;
         }
     }


    // private ObservableCollection<Applicant> _applicants;
    //
    // public ICommand LoadDataCommand { get; }
    //
    // public ObservableCollection<Applicant> Applicants
    // {
    //     get { return _applicants; }
    //     set { _applicants = value; }
    // }
    //
    // public async Task LoadData()
    // {
    //     _applicants = new ObservableCollection<Applicant>(await ExecuteCommandDataBase.GetApplicants());
    //     OnPropertyChanged("Applicants");
    // }
    //
    // public MainWindowVM() {
    //     _applicants = new ObservableCollection<Applicant>();
    //     LoadDataCommand = new RelayCommandAsync(async () => await LoadData());
    // }
}