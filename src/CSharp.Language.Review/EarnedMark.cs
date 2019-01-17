using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Language.Review
{
    public class EarnedMark : WeightedMark
    {

        //this is an example of an auto-implemented property
        //properties provide a controlled access to information
        public int Possible { get; private set; }

        //this is a field
        private double _Earned;

        //this is an explicitly implemented property
        public double Earned
        {

            // we are using the earned field as a "backing store"
            get { return _Earned; }
            set
            {
                if (value < 0 || value > Possible)
                    throw new Exception("Invalid earned mark assigned");
                _Earned = value;

            }
            
        }
        public double Percent // an example of a property that derives its values from other data
        { get { return (Earned / Possible) * 100; } }
        public double WeightedPercent
        { get { return Percent * Weight / 100; } }

        //This constructor calls another constructor
        //before it runs its own body of instructions(code)
        //Inheritance calls another constructor before that constructor runs its code
        //hooking up constructors in this fashion is
        //known as "daisy-chaining" your constructor calls.
        public EarnedMark(WeightedMark markableItem, int possible, double earned)
            : this(markableItem.Name, markableItem.Weight, possible, earned) //a
        {
            //d
        }

        public EarnedMark(string name, int weight, int possible, double earned)
            : base(name, weight) //b
        {

            if (possible <= 0) //c
                throw new Exception("Invalid possible marks");
            Possible = possible;
            Earned = earned;

        }

        //changing the behaviour of the base class by overriding some method
        //is one way that we accomplish Polymorphism
        public override string ToString()
        {
            return String.Format("{0} ({1})\t - {2}% ({3}/{4}) \t - Weighted Mark {5}%",
                Name,
                Weight,
                Percent,
                Earned,
                Possible,
                WeightedPercent);

        }
        

    }
}
