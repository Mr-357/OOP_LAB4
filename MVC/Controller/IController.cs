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
        IModel Model
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
        IView View
        {
            get;
            set;
        }
        void swap();
        void deal();
        void calculate();
        void bet();
    }
}
