using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace TriangleApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Alexey.Children.Clear();
            if (string.IsNullOrEmpty(FirstSide.Text))
            {
                MessageBox.Show("Не все данные введены ");
                return;
            }
            else if(string.IsNullOrEmpty(SecondSide.Text))
            {
                MessageBox.Show("Не все данные введены ");
                return;
            }
            else if(string.IsNullOrEmpty(ThirdSide.Text))
            {
                MessageBox.Show("Не все данные введены ");
                return;
            }
            try
            {
                double firstside = Convert.ToDouble(FirstSide.Text);
                double secondside = Convert.ToDouble(SecondSide.Text);
                double thirdside = Convert.ToDouble(ThirdSide.Text);
                int i = 0;
                if ((firstside == secondside && firstside == thirdside) && (secondside + firstside >= thirdside && secondside + thirdside >= firstside && firstside + thirdside >= secondside))
                {
                    View.Text = "Равносторонний";
                    i = 1;
                }
                else if ((firstside == secondside || firstside == thirdside || secondside == thirdside) && (secondside + firstside >= thirdside && secondside + thirdside >= firstside && firstside + thirdside >= secondside))
                {
                    View.Text = "Равнобедренный";
                    i = 2;
                }
                else if ((firstside != secondside || firstside != thirdside || secondside != thirdside) && (secondside + firstside >= thirdside && secondside + thirdside >= firstside && firstside + thirdside >= secondside))
                {
                    View.Text = "Разносторонний";
                    i = 3;
                }
                else
                {

                    if (secondside + firstside <= thirdside)
                    {
                        MessageBox.Show($"Треугольник не существует, так как {firstside} + {secondside} =< {thirdside}");
                        return;
                    }
                    else if (secondside + thirdside <= firstside)
                    {
                        MessageBox.Show($"Треугольник не существует, так как {secondside} + {thirdside} =< {firstside}");
                        return;
                    }
                    else if (firstside + thirdside <= secondside)
                    {
                        MessageBox.Show($"Треугольник не существует, так как {firstside} + {thirdside} =< {secondside}");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введен неверный тип данных");
                return;
            }
            double firstside1 = Convert.ToDouble(FirstSide.Text);
            double secondside1 = Convert.ToDouble(SecondSide.Text);
            double thirdside1 = Convert.ToDouble(ThirdSide.Text);
            double firstcorner = Math.Round(Math.Acos((firstside1 * firstside1 + thirdside1 * thirdside1 - secondside1 * secondside1) / (2 * firstside1 * thirdside1)) * 180 / Math.PI, 3);
            FirstCorner.Text = Convert.ToString("∠A=" + firstcorner + ";");
            double secondcorner = Math.Round(Math.Acos((firstside1 * firstside1 + secondside1 * secondside1 - thirdside1 * thirdside1) / (2 * firstside1 * secondside1)) * 180 / Math.PI, 3);
            SecondCorner.Text = Convert.ToString("∠B=" + secondcorner + ";");
            double thirdcorner = Math.Round(Math.Acos((secondside1 * secondside1 + thirdside1 * thirdside1 - firstside1 * firstside1) / (2 * secondside1 * thirdside1)) * 180 / Math.PI,3);
            ThirdCorner.Text = Convert.ToString("∠C=" + thirdcorner);
            Line abLine = new Line();
            Line bcLine = new Line();
            Line caLine = new Line();
            abLine.Stroke = Brushes.Black;
            bcLine.Stroke = Brushes.Black;
            caLine.Stroke = Brushes.Black;
            firstside1 *= 50;
            secondside1 *= 50;
            abLine.X1 = 100;
            abLine.Y1 = 30;
            abLine.X2 = abLine.X1 + firstside1;
            abLine.Y2 = abLine.Y1;
            bcLine.X1 = abLine.X2;
            bcLine.Y1 = abLine.Y2;
            bcLine.Y2 = abLine.Y1 + firstside1 * (Math.Sin(Convert.ToDouble(firstcorner) * Math.PI / 180) * Math.Sin(Convert.ToDouble(secondcorner) * Math.PI / 180) / Math.Sin((Convert.ToDouble(firstcorner) + Convert.ToDouble(secondcorner)) * Math.PI / 180));
            bcLine.X2 = abLine.X2 - Math.Sqrt(Math.Pow(secondside1, 2) - Math.Pow(bcLine.Y2 - abLine.Y1, 2));
            caLine.X1 = abLine.X1;
            caLine.Y1 = abLine.Y1;
            caLine.X2 = bcLine.X2;
            caLine.Y2 = bcLine.Y2;
            Alexey.Children.Add(abLine);
            Alexey.Children.Add(bcLine);
            Alexey.Children.Add(caLine);


        }
    }
}
