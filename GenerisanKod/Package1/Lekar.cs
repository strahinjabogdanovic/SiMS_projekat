using System;

namespace Package1
{
   public class Lekar : Zaposleni
   {
      public System.Collections.ArrayList zakazivanjeTermina;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetZakazivanjeTermina()
      {
         if (zakazivanjeTermina == null)
            zakazivanjeTermina = new System.Collections.ArrayList();
         return zakazivanjeTermina;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetZakazivanjeTermina(System.Collections.ArrayList newZakazivanjeTermina)
      {
         RemoveAllZakazivanjeTermina();
         foreach (ZakazivanjeTermina oZakazivanjeTermina in newZakazivanjeTermina)
            AddZakazivanjeTermina(oZakazivanjeTermina);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddZakazivanjeTermina(ZakazivanjeTermina newZakazivanjeTermina)
      {
         if (newZakazivanjeTermina == null)
            return;
         if (this.zakazivanjeTermina == null)
            this.zakazivanjeTermina = new System.Collections.ArrayList();
         if (!this.zakazivanjeTermina.Contains(newZakazivanjeTermina))
            this.zakazivanjeTermina.Add(newZakazivanjeTermina);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveZakazivanjeTermina(ZakazivanjeTermina oldZakazivanjeTermina)
      {
         if (oldZakazivanjeTermina == null)
            return;
         if (this.zakazivanjeTermina != null)
            if (this.zakazivanjeTermina.Contains(oldZakazivanjeTermina))
               this.zakazivanjeTermina.Remove(oldZakazivanjeTermina);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllZakazivanjeTermina()
      {
         if (zakazivanjeTermina != null)
            zakazivanjeTermina.Clear();
      }
   
      private Specijalizacija Specijalizacija;
   
   }
}