using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace SudokuWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateSudokuGrid();

        }

        private void CreateSudokuGrid()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Border cellBorder = new Border();
                    cellBorder.BorderBrush = Brushes.Gray;
                    cellBorder.BorderThickness = new Thickness(1);

                    TextBlock cellContent = new TextBlock();
                    cellContent.Name = "x" + i.ToString() + "y" +  j.ToString();
                    cellContent.HorizontalAlignment = HorizontalAlignment.Center;
                    cellContent.VerticalAlignment = VerticalAlignment.Center;
                    cellBorder.Child = cellContent;
                    uniformGrid.Children.Add(cellBorder);
                }
            }
        }
    }
}

