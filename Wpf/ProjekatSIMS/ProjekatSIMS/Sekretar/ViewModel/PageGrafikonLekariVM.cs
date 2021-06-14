using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageGrafikonLekariVM : ViewModels
    {
        private PageGrafikonLekari page;

        public class Category
        {
            public float Percentage { get; set; }
            public string Title { get; set; }
            public Brush ColorBrush { get; set; }
        }

        private RelayCommand nazad;

        public RelayCommand Nazad
        {
            get { return nazad; }
            set
            {
                nazad = value;
            }
        }

        private List<Category> Categories { get; set; }

        public PageGrafikonLekariVM(PageGrafikonLekari page, Canvas mainCanvas, ItemsControl detailsItemsControl)
        {
            this.page = page;

            this.Nazad = new RelayCommand(Executed_Nazad, CanExecute_NavigateCommand);

            
            float pieWidth = 350, pieHeight = 350, centerX = pieWidth / 2, centerY = pieHeight / 2, radius = pieWidth / 2;
            mainCanvas.Width = pieWidth;
            mainCanvas.Height = pieHeight;

            Categories = new List<Category>()
            {
                new Category
                {
                    Title = "Marko Markovic-kardiolog",
                    Percentage = 20,
                    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB22222")),
                },

                new Category
                {
                    Title = "Jovan Jovanovic-hirurg",
                    Percentage = 60,
                    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ED7D31")),
                },
                /*
                new Category
                {
                    Title = "Category#03",
                    Percentage = 5,
                    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC000")),
                },*/

                new Category
                {
                    Title = "Jova Jovic-opsta praksa",
                    Percentage = 20,
                    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF32CD32")),
                },
                /*
                new Category
                {
                    Title = "Category#05",
                    Percentage = 5,
                    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A5A5A5")),
                },*/

            };

            detailsItemsControl.ItemsSource = Categories;

            // draw pie
            float angle = 0, prevAngle = 0;
            foreach (var category in Categories)
            {
                double line1X = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                double line1Y = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                angle = category.Percentage * (float)360 / 100 + prevAngle;
                Debug.WriteLine(angle);

                double arcX = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                double arcY = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                var line1Segment = new LineSegment(new Point(line1X, line1Y), false);
                double arcWidth = radius, arcHeight = radius;
                bool isLargeArc = category.Percentage > 50;
                var arcSegment = new ArcSegment()
                {
                    Size = new Size(arcWidth, arcHeight),
                    Point = new Point(arcX, arcY),
                    SweepDirection = SweepDirection.Clockwise,
                    IsLargeArc = isLargeArc,
                };
                var line2Segment = new LineSegment(new Point(centerX, centerY), false);

                var pathFigure = new PathFigure(
                    new Point(centerX, centerY),
                    new List<PathSegment>()
                    {
                        line1Segment,
                        arcSegment,
                        line2Segment,
                    },
                    true);

                var pathFigures = new List<PathFigure>() { pathFigure, };
                var pathGeometry = new PathGeometry(pathFigures);
                var path = new Path()
                {
                    Fill = category.ColorBrush,
                    Data = pathGeometry,
                };
                mainCanvas.Children.Add(path);

                prevAngle = angle;


                // draw outlines
                var outline1 = new Line()
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = line1Segment.Point.X,
                    Y2 = line1Segment.Point.Y,
                    Stroke = Brushes.White,
                    StrokeThickness = 5,
                };
                var outline2 = new Line()
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = arcSegment.Point.X,
                    Y2 = arcSegment.Point.Y,
                    Stroke = Brushes.White,
                    StrokeThickness = 5,
                };

                mainCanvas.Children.Add(outline1);
                mainCanvas.Children.Add(outline2);
            }
        }

        public void Executed_Nazad(object obj)
        {
            page.NavigationService.Navigate(new PagePrikazLekara());
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
