using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Study_XAN { 

	public class DP03StrategyDesignPattern : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			TestDP03StrategyDesignPattern();
		}

		void TestDP03StrategyDesignPattern() {
			
			StrategyContext strategyContext = new StrategyContext();

			IStrategy strategy = new ConcreteStrategyA();
			strategyContext.SetStrategy(strategy);
			strategyContext.Cal();

			strategy = new ConcreteStrategyB();
			strategyContext.SetStrategy(strategy);
			strategyContext.Cal();
		}
	}


	public class StrategyContext : IStrategy
	{
		protected IStrategy mStrategy;

		public void SetStrategy(IStrategy strategy) {
			mStrategy = strategy;
		}

		public void Cal()
        {
			mStrategy.Cal();

		}
    }

	public interface IStrategy {

		void Cal();
	}

	public class ConcreteStrategyA : IStrategy
	{
		public void Cal()
		{
			Debug.Log(GetType()+ "/Cal()/");
		}
	}

	public class ConcreteStrategyB : IStrategy
	{
		public void Cal()
		{
			Debug.Log(GetType() + "/Cal()/");
		}
	}
}
