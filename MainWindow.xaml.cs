using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Kółko_i_krzyżyk
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members
        /// <summary>
        /// Przechowuje obecna wartość w komórce podczas gry
        /// </summary>
        private MarkType[] mResults;
        /// <summary>
        /// Prawda jeśli to kolej gracza nr 1 (X) lub gracza nr 2 (0)
        /// </summary>
        private bool mPlayer1Turn;
        /// <summary>
        /// Prawda jeśli gra zakończyła się
        /// </summary>
        private bool mGameEndend;

        #endregion
        #region Constructor 
        /// <summary>
        /// Default constructor
        /// </summary>


        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }
        #endregion
        /// <summary>
        /// Rozpoczyna nową grę
        /// </summary>
        private void NewGame()
        {
            // Tworzy nową pustą tablice pustych komórek
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;
            //Gracz 1 rozpoczyna grę
            mPlayer1Turn = true;

            // Dodaje każdy element do planszy
            Cointainer.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            mGameEndend = false;
        }
        /// <summary>
        /// Kliknięcie przycisku
        /// </summary>
        /// <param name="sender">Przyscik którey został kliknięty</param>
        /// <param name="e">Wydarzenia po kliknięciu</param>

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEndend)
            {
                NewGame();
                return;
            }
            var button = (Button)sender;

            // Find the buttons position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            
            if (mResults[index] != MarkType.Free)
                return;

            
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            
            button.Content = mPlayer1Turn ? "X" : "O";

            //zmienia kolor kółka na zielony
            if (mPlayer1Turn)
            {
                button.Foreground = Brushes.Red;
            }
            
            //przełącza kolej graczy 
            mPlayer1Turn ^= true;
            CheckForWinner();
        
        }
        private void CheckForWinner()
        {
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameEndend = true;
                //zanzacza wygrane komórki na zielono
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }
        }
    }
}