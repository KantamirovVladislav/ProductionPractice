using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DataBaseClassLibrary.Context;
using DataBaseClassLibrary.Entities;

namespace ScheduleWPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private MyDbContext _context;

        public ObservableCollection<Specialty> Specialties { get; set; }
        public ObservableCollection<Group> Groups { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }
        public ObservableCollection<Teacher> Teachers { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }

        public ICommand AddSpecialtyCommand { get; }
        public ICommand RemoveSpecialtyCommand { get; }

        public MainViewModel()
        {
            _context = new MyDbContext();
            LoadData();

            AddSpecialtyCommand = new RelayCommand(AddSpecialty);
            RemoveSpecialtyCommand = new RelayCommand(RemoveSpecialty, CanRemoveSpecialty);
        }

        private void LoadData()
        {
            Specialties = new ObservableCollection<Specialty>(_context.Specialties.ToList());
            Groups = new ObservableCollection<Group>(_context.Groups.ToList());
            Subjects = new ObservableCollection<Subject>(_context.Subjects.ToList());
            Teachers = new ObservableCollection<Teacher>(_context.Teachers.ToList());
            Rooms = new ObservableCollection<Room>(_context.Rooms.ToList());
        }

        private void AddSpecialty(object parameter)
        {
            var newSpecialty = new Specialty { SpecialtyName = "New Specialty" };
            _context.Specialties.Add(newSpecialty);
            _context.SaveChanges();
            Specialties.Add(newSpecialty);
        }

        private bool CanRemoveSpecialty(object parameter) => parameter is Specialty;

        private void RemoveSpecialty(object parameter)
        {
            if (parameter is Specialty specialty)
            {
                _context.Specialties.Remove(specialty);
                _context.SaveChanges();
                Specialties.Remove(specialty);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
