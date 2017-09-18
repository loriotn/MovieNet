using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNet.Tools
{
    public class UserControlProperties
    {
        MainWindowProperties m = MainWindowProperties.mainWindowProperties;
        public double HeightMovie { get; set; }
        public double WidthMovie { get; set; }
        public double FontSize { get; set; }
        public double HeightGridMovie { get; set; }
        public double HeightTitle { get; set; }
        public double HeightComment { get; set; }
        public double HeightNewComment { get; set; }
        public double WidthNewComment { get; set; }
        public double WidthGridMovie { get; set; }
        public double WidthGridMovieComment { get; set; }
        public double WidthButtons { get; set; }
        public double WidthLittleButtons { get; set; }
        public double WidthAreaComment { get; set; }
        public double PosLineY { get; set; }
        public UserControlProperties()
        {
            WidthMovie = m.Width - 20;
            HeightGridMovie = HeightMovie - HeightMovie * 0.05;
            HeightTitle = HeightMovie * 0.05;
            HeightNewComment = HeightGridMovie * 1 / 3;
            HeightComment = HeightGridMovie * 2 / 3;
            FontSize = (m.Height * m.Width) / 103680;
            WidthGridMovie = WidthMovie * 3 / 9;
            WidthGridMovieComment = WidthMovie * 4 / 9;
            WidthButtons = WidthMovie * 1 / 9;
            WidthLittleButtons = WidthButtons / 2;
            WidthAreaComment = WidthMovie - WidthGridMovie;
            WidthNewComment = WidthGridMovieComment + WidthButtons;
            PosLineY = HeightTitle + 3;
        }
    }
}
