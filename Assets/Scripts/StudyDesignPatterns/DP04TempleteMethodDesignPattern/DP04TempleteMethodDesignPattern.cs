using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Study_XAN {

	public class DP04TempleteMethodDesignPattern : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			TestDP04TempleteMethodDesignPattern();
		}

		void TestDP04TempleteMethodDesignPattern() {

			TempletePeople people = new NorthPeople();
			people.Eat();

			people = new SouthPeople();
			people.Eat();
		}
	}

	// 人吃饭的模板
	public class TempletePeople{
		public void Eat() {
			OrderMenu();
			EatSomething();
			PayBill();
		}

		private void OrderMenu() {
			Debug.Log(GetType()+ "/OrderMenu()/");
		}

		// 需要重写的地方虚方法即可
		protected virtual void EatSomething()
		{
			Debug.Log(GetType() + "/EatSomething()/");
		}

		private void PayBill()
		{
			Debug.Log(GetType() + "/PayBill()/");
		}
	}

	public class NorthPeople : TempletePeople{
        protected override void EatSomething()
        {
			Debug.Log(GetType() + "/EatSomething()/ Eat Noodle");
		}
    }

	public class SouthPeople : TempletePeople
	{
		protected override void EatSomething()
		{
			Debug.Log(GetType() + "/EatSomething()/ Eat Rice");
		}
	}
}
