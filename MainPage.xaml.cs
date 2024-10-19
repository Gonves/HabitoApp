    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Text.Json;
    using System.Windows.Input;

    namespace HabitoApp;

    public partial class MainPage : ContentPage
    {
        public class Habit
        {
            public string Nome { get; set; }
            public int Frequencia { get; set; } // Frequência em dias
            public int ProgressoDiario { get; set; } // Contador para o dia atual
            public bool Concluido { get; set; } // 
            public ICommand CompleteHabitCommand { get; set; }
            public ICommand RemoveHabitCommand { get; set; }
        }
        public ObservableCollection<Habit> Habits { get; set; } = new ObservableCollection<Habit>();


        public MainPage()
        {
            InitializeComponent();
            HabitsList.ItemsSource = Habits;
    }


        // Evento disparado quando o botão "Adicionar Hábito" for clicado
        private void OnAddHabitClicked(object sender, EventArgs e)
        {
            string habitName = HabitNameEntry.Text;
            if (string.IsNullOrWhiteSpace(habitName)) return;

            if (int.TryParse(HabitFrequencyEntry.Text, out int frequency))
            {
                var habit = new Habit
                {
                    Nome = habitName,
                    Frequencia = frequency
                };

                Habits.Add(habit);

                // Limpa os campos de entrada
                HabitNameEntry.Text = string.Empty;
                HabitFrequencyEntry.Text = string.Empty;
            }
        }

        
        private void OnCompleteHabitClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var habit = button?.CommandParameter as Habit;

            if (habit != null)
            {
                habit.Frequencia--;
                if (habit.Frequencia <= 0)
                {
                    Habits.Remove(habit);
                }
                OnPropertyChanged(nameof(Habits));
            }
        }

      
        private void OnRemoveHabitClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var habit = button?.CommandParameter as Habit;

            if (habit != null)
            {
                Habits.Remove(habit);
                OnPropertyChanged(nameof(Habits));
            }
        }

        // Implementação da interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = " ")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }




