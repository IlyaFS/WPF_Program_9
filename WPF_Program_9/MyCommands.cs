using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Program_9
{
    class MyCommands
    {
        public static RoutedCommand Dark { get; set; }
        public static RoutedCommand White { get; set; }

        static MyCommands()
        {
            Dark = new RoutedCommand();
            White = new RoutedCommand();
        }
    }
}
