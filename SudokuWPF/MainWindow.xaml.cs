﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SudokuLibary;

namespace SudokuWPF
{
    public partial class MainWindow : Window
    {
        private List<TextBox> _textBoxes;
        

        

        public MainWindow()
        {
            InitializeComponent();
            SudokuPuzzle.OnErrorOccured += ShowErrorPopup;
            this.LocationChanged += MainWindow_LocationChanged;

            _textBoxes = new List<TextBox>
            {
                txtBox00,txtBox10,txtBox20,txtBox30,txtBox40,txtBox50,txtBox60,txtBox70,txtBox80,

                txtBox01,txtBox11,txtBox21,txtBox31,txtBox41,txtBox51,txtBox61,txtBox71,txtBox81,

                txtBox02,txtBox12,txtBox22,txtBox32,txtBox42,txtBox52,txtBox62,txtBox72,txtBox82,

                txtBox03,txtBox13,txtBox23,txtBox33,txtBox43,txtBox53,txtBox63,txtBox73,txtBox83,

                txtBox04,txtBox14,txtBox24,txtBox34,txtBox44,txtBox54,txtBox64,txtBox74,txtBox84,

                txtBox05,txtBox15,txtBox25,txtBox35,txtBox45,txtBox55,txtBox65,txtBox75,txtBox85,

                txtBox06,txtBox16,txtBox26,txtBox36,txtBox46,txtBox56,txtBox66,txtBox76,txtBox86,

                txtBox07,txtBox17,txtBox27,txtBox37,txtBox47,txtBox57,txtBox67,txtBox77,txtBox87,

                txtBox08,txtBox18,txtBox28,txtBox38,txtBox48,txtBox58,txtBox68,txtBox78,txtBox88,
            };
        }
        private void CellTextBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            //e.Handled = !IsTextAllowed(e.Text);
            //ChangeTextColor(sender);

            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.Clear();
                e.Handled = !IsTextAllowed(e.Text);
            }
            ChangeTextColor(sender);
        }
        private static bool IsTextAllowed(string text)
        {
            //txtBox00.Text = puzzle.GetSpotValue(0, 0).ToString();
            int result;
            return text.Length == 1 && Int32.TryParse(text, out result) && result >= 1 && result <= 9;
        }

        private void ChangeTextColor(object sender)
        {
            SolidColorBrush myBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7D5A50"));

            TextBox ? tb = sender as TextBox;
            if (tb != null)
            {
                tb.Foreground = myBrush;
            }
        }

        private void BoxClear_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush myBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFBE9"));
            _myPopup.IsOpen = false;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var textBoxName = $"txtBox{i}{j}";
                    var textBox = (TextBox)this.FindName(textBoxName);
                    if (textBox != null)
                    {
                        textBox.Text = string.Empty;
                        textBox.Background = myBrush;
                    }
                }
            }
        }
        private void Sample_Click(object sender, RoutedEventArgs e)
        {
            BoxClear_Click(sender,e);
            FillSudoku();
        }

        private void BoxSolve_Click(object sender, RoutedEventArgs e)
        {
            var puzzle = new SudokuPuzzle();
            foreach (var tb in _textBoxes)
            {
                var x = int.Parse(tb.Name.Substring(6, 1));
                var y = int.Parse(tb.Name.Substring(7, 1));

                if (int.TryParse(tb.Text, out var num))
                    puzzle.SetSpotValue(x, y, num);
            }

            if (puzzle.TrySolve())
            {
                SolidColorBrush myCol = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EEE3CB"));

                SolidColorBrush myCol2 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7D5A50"));

                //txtBox00.Text = puzzle.GetSpotValue(0, 0).ToString();
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        var textBoxName = $"txtBox{i}{j}";
                        var textBox = (TextBox)this.FindName(textBoxName);
                        textBox.Foreground = Brushes.Black;

                        if (string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            var txtBoxNum = puzzle.GetSpotValue(i, j);
                            textBox.Background = myCol;
                            textBox.Foreground = myCol2;
                            textBox.Text = txtBoxNum.ToString();
                        }
                    }
                }
            }
            else
            {
                //TODO - CANT Solve

            }
        }
        private void ShowErrorPopup(string errorMessage)
        {
            // Wenn das Popup offen ist, schließen Sie es zuerst
            if (_myPopup.IsOpen)
            {
                _myPopup.IsOpen = false;
            }

            // Setzen Sie Ihre Popup-Nachricht (Sie müssen eine entsprechende Eigenschaft in Ihrem Popup hinzufügen)
            // myPopup.Message = errorMessage;

            // Öffnen Sie das Popup
            _myPopup.IsOpen = true;
        }

        private void CellTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {
            // Erzwingt die Aktualisierung der Position des Popups
            var offset = _myPopup.HorizontalOffset;
            _myPopup.HorizontalOffset = offset + 1;
            _myPopup.HorizontalOffset = offset;
        }

        private void ClosePopupButton_Click(object sender, RoutedEventArgs e)
        { 
            _myPopup.IsOpen = false;
        }

  
        private void FillSudoku()
        {
            //ROW 1
            txtBox10.Text = "3";

            //ROW 2
            txtBox31.Text = "1";
            txtBox41.Text = "9";
            txtBox51.Text = "5";

            //ROW 3
            txtBox22.Text = "8";
            txtBox72.Text = "6";

            //ROW 4
            txtBox03.Text = "8";
            txtBox43.Text = "6";

            //ROW 5
            txtBox04.Text = "4";
            txtBox34.Text = "8";
            txtBox84.Text = "1";

            //ROW 6
            txtBox45.Text = "2";

            //ROW 7
            txtBox16.Text = "6";
            txtBox66.Text = "2";
            txtBox76.Text = "8";

            //ROW 8
            txtBox37.Text = "4";
            txtBox47.Text = "1";
            txtBox57.Text = "9";
            txtBox87.Text = "5";

            //ROW 9
            txtBox78.Text = "7";
        }

    }
}
