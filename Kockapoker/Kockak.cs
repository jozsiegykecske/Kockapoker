using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kockapoker
{
  class Kockak
  {
    int[] ertekek = new int[5];
    Dictionary<int, int> minta = new Dictionary<int, int>();
    public void Dobas()
    {
      Feltolt();
    } 

    private void Feltolt()
    {
      Random vel = new Random(Guid.NewGuid().GetHashCode());
      for (int i = 0; i < ertekek.Length; i++)
      {
        ertekek[i] = vel.Next(1, 7);
      }

    }
    public int Ertek()
    {
      KiErtekel();
      foreach (var m in minta)
      {
        Console.WriteLine($"{m.Key}:{m.Value}");
      }
      return 0;
    }
    
    private void Csoportosit()
    {
      foreach (var e in ertekek)
      {
        if (minta.ContainsKey(e))
        {
          minta[e]++;
        }
        else
        {
          minta.Add(e, 1);
        }
      }
    }
    private void Egyszerusit()
    {
      List<int> egyesek = new List<int>();
      foreach (var m in minta)
      {
        if (m.Value == 1)
        {
          egyesek.Add(m.Key);
        }
      }
      foreach (var e in egyesek)
      {
        minta.Remove(e);
      }
    }
    private void KiErtekel()
    {
      Csoportosit();
      Egyszerusit();
    }

    public string ErtekSzoveg()
    {
      Sorrendbe();
      return String.Join("-", ertekek);
    }

    private void Sorrendbe()
    {
      for (int i = 0; i < ertekek.Length-1; i++)
      {
        for (int j = i+1; j < ertekek.Length; j++)
        {
          if (ertekek[i]>ertekek[j])
          {
            int temp = ertekek[i];
            ertekek[i] = ertekek[j];
            ertekek[j] = temp;
          }
        }
      }
    }
  }
}
