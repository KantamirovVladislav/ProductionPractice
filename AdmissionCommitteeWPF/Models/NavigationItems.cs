using MaterialDesignThemes.Wpf;

namespace AdmissionCommitteeWPF.Models;

public class NavigationItems
{
    public string Title { get; set; }
    public string Notification { get; set; }
    public PackIconKind SelectedIcon { get; set; }
    public PackIconKind UnselectedIcon { get; set; }
}