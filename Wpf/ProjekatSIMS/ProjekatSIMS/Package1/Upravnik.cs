using System;

namespace Package1
{
   public class Upravnik : RegistrovanKorisnik
   {
      public System.Collections.ArrayList prostorije;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetProstorije()
      {
         if (prostorije == null)
            prostorije = new System.Collections.ArrayList();
         return prostorije;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetProstorije(System.Collections.ArrayList newProstorije)
      {
         RemoveAllProstorije();
         foreach (Prostorije oProstorije in newProstorije)
            AddProstorije(oProstorije);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddProstorije(Prostorije newProstorije)
      {
         if (newProstorije == null)
            return;
         if (this.prostorije == null)
            this.prostorije = new System.Collections.ArrayList();
         if (!this.prostorije.Contains(newProstorije))
            this.prostorije.Add(newProstorije);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveProstorije(Prostorije oldProstorije)
      {
         if (oldProstorije == null)
            return;
         if (this.prostorije != null)
            if (this.prostorije.Contains(oldProstorije))
               this.prostorije.Remove(oldProstorije);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllProstorije()
      {
         if (prostorije != null)
            prostorije.Clear();
      }
   
   }
}