using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MadGazeSlamDemo { 

	public class DP13DecorateDesignPattern : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			TestDP13DecorateDesignPattern();
		}

		void TestDP13DecorateDesignPattern() {
			Coffee coffee = new Espress();

			coffee = coffee.AddDecorate(new Mocha());
			coffee = coffee.AddDecorate(new Mocha());
			coffee = coffee.AddDecorate(new Whip());

			Debug.Log(GetType() + "/TestDP13DecorateDesignPattern() / coffee Cost = " + coffee.Cost()) ;
		}
	}

	public abstract class Coffee {
		public abstract double Cost();
		public abstract double Capacity();

		public Coffee AddDecorate(Decorator decorator) {
			decorator.coffee = this;
			return decorator;
		}
	}

	public class Espress : Coffee {
        public override double Cost()
        {
			return 2.5f;
        }

        public override double Capacity()
        {
			return 10f;
		}
    }

	public class Decaf : Coffee
	{
		public override double Cost()
		{
			return 2f;
		}

		public override double Capacity()
		{
			return 10f;
		}
	}

	public class Decorator : Coffee {

		protected Coffee mCoffee;
		public Coffee coffee { set => mCoffee = value; }
        public override double Cost()
        {
			return mCoffee.Cost();

		}

        public override double Capacity()
        {
			return mCoffee.Capacity();
		}
    }

	public class Mocha : Decorator {
        public override double Cost()
        {
            return mCoffee.Cost()+0.1f;
        }
    }

	public class Whip : Decorator
	{
		public override double Cost()
		{
			return mCoffee.Cost() + 0.5f;
		}
	}
}
