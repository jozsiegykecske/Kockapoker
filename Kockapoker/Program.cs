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
      int emberNyer = 0;
      int gepNyer = 0;
      string valasz = string.Empty;
      do
      {
        JatekEgykor(gep,ref gepNyer,ember,ref emberNyer);
        JatekAllasa(emberNyer, gepNyer);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Akarsz még játszani?: (i/n)");
        valasz = Console.ReadLine().ToLower();
        Console.WriteLine("----------------------");
      } while (valasz=="i");
      Console.BackgroundColor = ConsoleColor.White;
      Console.ForegroundColor = ConsoleColor.Black;
      Console.WriteLine("Bye Bye Captain!");
      Console.ReadKey();
    }

    private static void JatekAllasa(int ember, int gep)
    {
      Console.WriteLine($"Ember: {ember.ToString().PadLeft(2)} - Gép: {gep}");
    }

    private static void JatekEgykor(Jatekos gep,ref int gepnyer, Jatekos ember,ref int embernyer)
    {
      Console.WriteLine("Szeretnél kezdeni: (I/N)");
      if (Console.ReadLine().ToLower() == "i")
      {
        ember.Kor();
        Console.WriteLine($"Az ember: {ember.Ertekszoveg}");
        //Console.WriteLine(ember.Ertek);
        gep.Kor();
        Console.WriteLine($"A gép   : {gep.Ertekszoveg}");
        //Console.WriteLine(gep.Ertek);
        EredmenyKiiras(gep,ref gepnyer, ember,ref embernyer);
      }
      else
      {
        gep.Kor();
        Console.WriteLine($"A gép   : {gep.Ertekszoveg}");
        //Console.WriteLine(gep.Ertek);
        ember.Kor();
        Console.WriteLine($"Az ember: {ember.Ertekszoveg}");
        //Console.WriteLine(ember.Ertek);
        EredmenyKiiras(gep, ref gepnyer, ember, ref embernyer);
      }
    }

    private static void EredmenyKiiras(Jatekos gep,ref int gepNyer ,Jatekos ember,ref int emberNyer)
    {
      if (ember.Ertek==gep.Ertek)
      {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Az állás döntetlen!");
      }
      else if (ember.Ertek > gep.Ertek)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Az ember nyert.");
        emberNyer++;
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Az ember vesztett.");
        gepNyer++;
      }
    }
  }
}
