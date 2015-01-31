using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infovizprojekt
{
    public class BaseHandler
    {
        protected MainWindow _mainWindow;

        public BaseHandler(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public MainWindow getMainWindow()
        {
            return _mainWindow;
        }
    }
}
