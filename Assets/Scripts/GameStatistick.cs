using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
     static public class GameStatistick
    {
        public static int Level { get; set; } = 1;
        public static int ScorePlayer1 { get; set; } = 0;
        public static int ScorePlayer2 { get; set; } = 0;
        public static int Shots { get; set; } = 0;
    }
}
