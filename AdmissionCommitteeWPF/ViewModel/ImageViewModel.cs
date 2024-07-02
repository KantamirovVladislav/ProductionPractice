using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AdmissionCommitteeWPF.ViewModel;

public class ImageViewModel: ViewModelBase
{
    private ImageSource _image = new BitmapImage();

    public ImageSource Image
    {
        get { return _image; }
        set
        {
            _image = value;
            OnPropertyChanged("Image");
        }
    }
}