using System.Windows.Input;
using AdmissionCommitteeWPF.Models;
using Microsoft.Extensions.Options;

namespace AdmissionCommitteeWPF.ViewModel;

public class ConnectionVM: ViewModelBase
{
    private ConnectionM _connectionModel = new ConnectionM();
    private string connectionName;
    private string connectionPassword;

    public bool SaveIO
    {
        get { return _connectionModel.IsSaveMe; }
        set
        {
            _connectionModel.IsSaveMe = value;
            OnPropertyChanged();
        }
    }

    public string ConnectionName
    {
        get => connectionName;
        set => connectionName = value;
    }

    public string ConnectionPassword
    {
        get => connectionPassword;
        set => connectionPassword = value;
    }

    public ICommand GetConnect
    {
        get; 
        set;
    }

    private void Connect(object obj)
    {
        _connectionModel.GetConnection(ConnectionName, ConnectionPassword);
    }

    public ConnectionVM()
    {
        
    }
}