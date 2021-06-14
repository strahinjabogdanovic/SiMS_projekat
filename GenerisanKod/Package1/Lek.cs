/***********************************************************************
 * Module:  Lek.cs
 * Author:  Strahx
 * Purpose: Definition of the Class Package1.Lek
 ***********************************************************************/

using System;

namespace Package1
{
   public class Lek
   {
      public System.Collections.ArrayList sastojci;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetSastojci()
      {
         if (sastojci == null)
            sastojci = new System.Collections.ArrayList();
         return sastojci;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetSastojci(System.Collections.ArrayList newSastojci)
      {
         RemoveAllSastojci();
         foreach (Sastojci oSastojci in newSastojci)
            AddSastojci(oSastojci);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddSastojci(Sastojci newSastojci)
      {
         if (newSastojci == null)
            return;
         if (this.sastojci == null)
            this.sastojci = new System.Collections.ArrayList();
         if (!this.sastojci.Contains(newSastojci))
            this.sastojci.Add(newSastojci);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveSastojci(Sastojci oldSastojci)
      {
         if (oldSastojci == null)
            return;
         if (this.sastojci != null)
            if (this.sastojci.Contains(oldSastojci))
               this.sastojci.Remove(oldSastojci);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllSastojci()
      {
         if (sastojci != null)
            sastojci.Clear();
      }
   
      private string NazivLeka;
      private string SifraLeka;
      private string Sastojci;
      private string Zamena;
   
   }
}