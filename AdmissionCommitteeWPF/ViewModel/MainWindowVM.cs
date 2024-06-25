
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Input;
using AdmissionCommitteeWPF.Models;
using DataBaseClassLibrary.Context;
using DataBaseClassLibrary.Entities.Comission;
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

    public Page CurrentPage
    {
        get { return _currentPage; }
        set { _currentPage = value; }
    }
    public ObservableCollection<NavigationItems> _NavigationItems { get; }
    
     // private Dictionary<string, ObservableCollection<NavigationItems>> _dictOfUserItem =
     //    new Dictionary<string, ObservableCollection<NavigationItems>>
     //    {
     //        {
     //            "administrator", new ObservableCollection<NavigationItems>
     //            {
     //                new NavigationItems { Title = "Таблицы", Notification = "", SelectedIcon =  PackIconKind.FileTableBoxMultiple, UnselectedIcon = PackIconKind.FileTableBoxMultipleOutline }
     //            }
     //        }
     //    };
     public MainWindowVM()
     {
         // string jsonString = JsonSerializer.Serialize(_dictOfUserItem);
         // File.WriteAllText("NavigationItem.json", jsonString);
         
         _NavigationItems = LoadNavigationMenu()["administrator"];
         _currentPage = new TablesView();
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
    //     LoadDataCommand = new RelayCommand(async () => await LoadData());
    // }
}