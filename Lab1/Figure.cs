using Lab1.Enums;

namespace Lab1
{
    public class Figure
    {
        private double _square;

        public double Square
        {
            get { return _square; }
        }

        public Figure(TypeOfFigure typeOfFigure, double line_length)
        {
            switch (typeOfFigure)
            {
                case TypeOfFigure.Triangle:
                    _square = double.Sqrt(3) * line_length / 2;
                    break;
                case TypeOfFigure.Rectangle:
                    _square = line_length * line_length;
                    break;
                case TypeOfFigure.Pentagon:
                    _square = (line_length * line_length / 4) * double.Sqrt(25 + 10 * double.Sqrt(5));
                    break;
                case TypeOfFigure.Octagon:
                    _square = line_length * line_length * 3 * double.Sqrt(3) / 2;
                    break;
                default:
                    break;
            }


        }
    }    
}

