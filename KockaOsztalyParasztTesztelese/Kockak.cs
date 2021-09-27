using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KockaOsztalyParasztTesztelese
{
  class Kockak
  {
    int[] ertekek = new int[5];
    Dictionary<int, int> minta;// = new Dictionary<int, int>();
    public int PontErtek { get; set; }

    public Kockak()
    {
    }

    public Kockak(int[] ertekek)
    {
      this.ertekek = ertekek;
    }


    public void Dobas()
    {
      Feltolt();
    } 
    /// <summary>
    /// 5 db véletlen szám az értékek tömbbe
    /// </summary>
    private void Feltolt()
    {
      Random vel = new Random(Guid.NewGuid().GetHashCode());
      for (int i = 0; i < ertekek.Length; i++)
      {
        ertekek[i] = vel.Next(1, 7);
      }
    }
    /// <summary>
    /// a dobás pontértékét egész számként adja vissza
    /// </summary>
    public int Ertek()
    {
      minta = new Dictionary<int, int>();
      KiErtekel();
      return PontErtek;
    }
    /// <summary>
    /// statisztikát készít, hogy melyik számból hány db van.
    /// Ha nem fordul elő a szám, akkor nem szerepel a dic-ben
    /// </summary>
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
    /// <summary>
    /// Egy darab előfordulásokat kiveszi a dic-ból.
    /// </summary>
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
    /// <summary>
    /// Elvégzi a dobás kiértékelését.
    /// </summary>
    private void KiErtekel()
    {
      Csoportosit();
      if (HaOtKulonbozo())
      {
        KissorNagysorSemmi();
      }
      else
      {
        Egyszerusit();
        //1 pár, 3 egyforma, 4 egyforma, 5 egyforma
        if (minta.Count==1)
        {
          int melyik = 0;
          int darab = 0;
          foreach (var m in minta)
          {
            melyik = m.Key;
            darab = m.Value;
          }
          switch (darab)
          {//szia lajos
              case 2: PontErtek = melyik;
              break;
              case 3: PontErtek = 300 + melyik;
              break;
              case 4: PontErtek = 400 + melyik;
              break;
              case 5: PontErtek = 1000 + melyik;
              break;
          }
        }
        //2 pár és Full (2-3)
        else
        {
          int valueSum = 0;
          int keySum = 0;
          foreach (var m in minta)
          {
            valueSum += m.Value;
            keySum += m.Key;
          }
          // 2 pár
          if (valueSum==4)
          {
            PontErtek = 100 + minta.Keys.Max()*10 + minta.Keys.Min();
          }
          else
          {
            PontErtek = 500;
            foreach (var m in minta)
            {
              if (m.Value==3)
              {
                PontErtek += m.Key * 10;
              }
              else
              {
                PontErtek += m.Key;
              }
            }
          }
        }
      }
    }

    private bool HaOtKulonbozo()
    {
      return minta.Count == 5;
    }

    /// <summary>
    /// Kissor,Nagysor,Semmi érték adás
    /// </summary>
    private void KissorNagysorSemmi()
    {
      if (ertekek[0] == 1 && ertekek[4] == 5)
      {
        PontErtek = 600;
      }
      else if (ertekek[0] == 2 && ertekek[4] == 6)
      {
        PontErtek = 700;
      }
      else
      {
        PontErtek = 0;
      }
    }

    /// <summary>
    /// a dobást vissza adja szövegesen összefűzve.
    /// pl.: 1-1-2-3-3
    /// </summary>
    /// <returns></returns>
    public string ErtekSzoveg()
    {
      Sorrendbe();
      return String.Join("-", ertekek);
    }
    /// <summary>
    /// Növekvő sorrendbe rakja a dobásokat.
    /// </summary>
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
