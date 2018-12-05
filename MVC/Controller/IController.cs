using MVC.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Controller
{
    public interface IController
    {
        void start();
        void stop();
        IModel model
        {
            get;
            set;
        }
        void reveal();
        int score
        {
            get;
            set;
        }
        IView view
        {
            get;
            set;
        }
        void swap();
        void deal();
        void calculate();

    }
}
