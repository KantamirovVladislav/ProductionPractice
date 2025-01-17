﻿using System.Windows;
using DataBaseClassLibrary.Methods;

namespace AdmissionCommitteeWPF.Models;

public class ConnectionM
{
    private Configuration _configuraiton = ConfigurationHelper.ReadFromJson();
    
    public bool IsSaveMe
    {
        get { return _configuraiton.IsSaveConnection; }
        set => _configuraiton.IsSaveConnection = value;
    }
    
    public void GetConnection(string? connName, string? connPassword)
    {
        if (connName == null || connPassword == null)
        {
            return;
        }
        
        WriteNewConfig(connName, connPassword);
        
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Application.Current.Windows[0].Close();
    }
    
    private void WriteNewConfig(string? connName, string? connPassword)
    {
        _configuraiton.ConnName = connName;
        _configuraiton.ConnPassword = connPassword;
        
        ConfigurationHelper.WriteToJson(_configuraiton);
    }
    
    public ConnectionM()
    {
        if (_configuraiton.CheckConnection() && _configuraiton.IsSaveConnection)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Application.Current.Windows[0].Close();
        }
    }
}