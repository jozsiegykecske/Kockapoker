using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kockapoker
{
  class Jatekos
  {
    private string nev;

    public string Nev
    {
      get { return nev; }
      set { nev = value; }
    }
    Kockak kockaDobas = new Kockak();
    public string Ertekszoveg {
      get
      {
        return kockaDobas.ErtekSzoveg();
      }
        }
    public int Ertek {
      get 
      {
        return kockaDobas.Ertek();
      }
      }
    public Jatekos(string nev)
    {
      this.nev = nev;
    }
    public void Kor()
    {
      kockaDobas.Dobas();
    }
  }
}
