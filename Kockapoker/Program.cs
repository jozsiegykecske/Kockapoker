using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kockapoker
{
  class Program
  {
    static void Main(string[] args)
    {
      Jatekos gep = new Jatekos("Gép");
      Jatekos ember = new Jatekos("Bazzzsi");
      Console.WriteLine("Szeretnél kezdeni: (I/N)");
      if (Console.ReadLine().ToLower() =="i")
      {
        ember.Kor();
        Console.WriteLine($"Az ember: {ember.Ertekszoveg}");
        Console.WriteLine(ember.Ertek);
        gep.Kor();
        Console.WriteLine($"A gép   : {gep.Ertekszoveg}");
        Console.WriteLine(gep.Ertek);
      }
      else
      {
        gep.Kor();
        Console.WriteLine($"A gép   : {gep.Ertekszoveg}");
        ember.Kor();
        Console.WriteLine($"Az ember: {ember.Ertekszoveg}");
      }

      Console.ReadKey();
    }
  }
}
