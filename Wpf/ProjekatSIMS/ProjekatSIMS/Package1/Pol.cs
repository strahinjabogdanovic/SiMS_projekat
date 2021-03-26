using System;

namespace Package1
{
    public enum Pol
    {
        Zenski,
        Muski
    }

    public class Foo
    {
        private Pol p;

        public void SetDifficulty(Pol value)
        {
            p = value;
        }

        public Pol GetDifficulty()
        {
            return p;
        }
        // public class Pol
        // {
        //   private EnumConstant Zenski;
        //   private EnumConstant Muski;

        // }
    }
}