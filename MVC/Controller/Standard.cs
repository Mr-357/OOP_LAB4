using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.View;

namespace MVC.Controller
{
     public class Standard : IController
    {
        private IModel model;
        private IView view;
        public Standard(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
        }
        public IModel Model { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int score { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IView View { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void bet()
        {
            throw new NotImplementedException();
        }

        public void calculate()
        {
            throw new NotImplementedException();
        }

        public void deal()
        {
            throw new NotImplementedException();
        }

        public void reveal()
        {
            throw new NotImplementedException();
        }

        public void start()
        {
            throw new NotImplementedException();
        }

        public void stop()
        {
            throw new NotImplementedException();
        }

        public void swap()
        {
            throw new NotImplementedException();
        }
    }
}
