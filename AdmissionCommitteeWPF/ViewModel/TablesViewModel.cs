using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using AdmissionCommitteeWPF.Models;
using DataBaseClassLibrary.Entities.Comission;
using DataBaseClassLibrary.Methods;

namespace AdmissionCommitteeWPF.ViewModel;

public class TablesViewModel: ViewModelBase
{
    private TablesListModel _tablesViewModel;
    private ComissionEntitys _table;
    private ObservableCollection<ComissionEntitys> _tables = new ObservableCollection<ComissionEntitys>();

    public ObservableCollection<object> TablesItems
    {
        set { _tablesViewModel.CurrentTable = value;}
        get { return _tablesViewModel.CurrentTable; }
    }
    
    private async Task LoadDataAsync()
    {
        await _tablesViewModel.SetTable(_table);
        TablesItems = _tablesViewModel.CurrentTable;
        OnPropertyChanged("TablesItems");
    }
    
    public ComissionEntitys Table
    {
        get { return _table;}
        set
        {
            _table = value;
            Task.Run(LoadDataAsync);
        }
    }
    public ObservableCollection<ComissionEntitys> Tables => _tables;

    public TablesViewModel()
    {
        _tablesViewModel = new TablesListModel();
        //LoadDataCommand = new RelayCommand(async () => await LoadDataAsync());
        LoadListTables();
    }

    private void LoadListTables()
    {
        foreach (ComissionEntitys val in Enum.GetValues(typeof(ComissionEntitys)))
        {
            _tables.Add(val);
        }
    }

}