using ProjekatOOAD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatOOAD.Models
{
    public class Observer
    {
        //private string _name;
        private string _observerState;
        private Models.Administrator _subject;

        // Constructor

        public Observer(
          Administrator subject)
        {
            this._subject = subject;
        }

        public void Update()
        {
            _observerState = _subject.Obavjestenje;
            if (_subject.Obavjestenje == "") AdministratorViewModel.PrikaziPoruku("Nema obavjestenja!");
            else AdministratorViewModel.PrikaziPoruku("Obavjestenje: " + _subject.Obavjestenje);
        }

        // Gets or sets subject

        public Administrator Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
    }
}
