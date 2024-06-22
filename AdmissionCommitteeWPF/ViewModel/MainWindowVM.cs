
using DataBaseClassLibrary.Context;
using DataBaseClassLibrary.Entities.Comission;

namespace AdmissionCommitteeWPF.ViewModel;

public class MainWindowVM
{
    private List<Applicant> _applicants;

    public List<Applicant> Applicants
    {
        get { return OpenConnectionDataBase.getInstance().Applicants.ToList(); }
        set { _applicants = value; }
    }

    public MainWindowVM() {
    }
}