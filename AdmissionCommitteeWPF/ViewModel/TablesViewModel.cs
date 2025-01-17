﻿using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using AdmissionCommitteeWPF.Models;
using DataBaseClassLibrary.Entities;
using DataBaseClassLibrary.Methods;

namespace AdmissionCommitteeWPF.ViewModel;

public class TablesViewModel: ViewModelBase
{
    #region Variables
    // Contains the model for the tables
    private TablesListModel _tablesModel; 
    
    // Contains the current table name
    private ComissionEntitys _table;
    
    // Contains the all tables name
    private ObservableCollection<ComissionEntitys> _tables = new ObservableCollection<ComissionEntitys>();

    private object _selectedRow;
    
    #endregion
    
    #region Properties

    // Contains the current table value
    public ObservableCollection<object> TablesItems
    {
        set { _tablesModel.CurrentTable = value;}
        get { return _tablesModel.CurrentTable; }
    }

    // Accepts the table name and starts loading data
    public ComissionEntitys Table
    {
        get { return _table;}
        set
        {
            _table = value;
            Task.Run(LoadDataAsync);
        }
    }
    
    // Returns the list of tables
    public ObservableCollection<ComissionEntitys> Tables => _tables;

    public object SelectedRow
    {
        get => _selectedRow;
        set
        {
            _selectedRow = value;
        }
    }
    
    #endregion
   
    #region Commands

    public ICommand SaveDataCommand { get; }
    public ICommand DeleteDataCommand { get; }
    
    public ICommand RejectAllChanges { get; }
    
    public ICommand RejectChanges { get; }
    
    private void DeleteData(object data)
    {
        if (SelectedRow != null)
            _tablesModel.DeletedValues.Add(SelectedRow); 
    }

    private async Task SaveDataAsync()
    {
        try
        {
            await _tablesModel.SaveData(); 
            MessageBox.Show("Data saved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
    }
    
    private async Task RejectAllChangesAsync()
    {
        try
        {
            _tablesModel.RejectAllChanges();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        await LoadDataAsync();
        MessageBox.Show("Data reject successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
    }
    
    private async Task RejectChangesAsync()
    {
        // try
        // {
        //     _tablesModel.RejectChanges();
        // }
        // catch (Exception e)
        // {
        //     MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //     return;
        // }
        // await LoadDataAsync();
        // MessageBox.Show("Data reject successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    // Contains the command for loading data. Works with async 
    private async Task LoadDataAsync()
    {
        try
        {
            await _tablesModel.SetTable(_table);
            TablesItems = _tablesModel.CurrentTable;
            OnPropertyChanged("TablesItems");
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    #endregion


    #region Function

    // Fills the list with tables
    private void LoadListTables()
    {
        foreach (ComissionEntitys val in Enum.GetValues(typeof(ComissionEntitys)))
        {
            _tables.Add(val);
        }
    }

    #endregion
    
    // Constructor
    public TablesViewModel()
    {
        _tablesModel = new TablesListModel();
        SaveDataCommand = new RelayCommandAsync(async () => await SaveDataAsync());
        RejectAllChanges = new RelayCommandAsync(async () => await RejectAllChangesAsync());
        RejectChanges = new RelayCommandAsync(async () => await RejectChangesAsync());
        DeleteDataCommand = new RelayCommand(DeleteData);
        LoadListTables();
    }

   

}