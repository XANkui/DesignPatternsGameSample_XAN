using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Study_XAN {

	public class DP05BuilderDesignPattern : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			TestDP05BuilderDesignPattern();
		}


		void TestDP05BuilderDesignPattern() {
			IBuilder fatPersonBuilder = new FatPersonBuilder();
			IBuilder thinPersonBuilder = new ThinPersonBuilder();

			Director director = new Director();
			director.Construct(fatPersonBuilder).Show();
			director.Construct(thinPersonBuilder).Show();
		}
	}

	public class Person {
		private List<string> partLst = new List<string>();
		public void AddPart(string partName) {
			partLst.Add(partName);
		}

		public void Show() {
			foreach (string part in partLst)
			{
				Debug.Log(GetType() + "/Show()/" + part);
			}
		}
	}

	public class ThinPerson : Person { }
	public class FatPerson : Person { }

	public interface IBuilder {
		void AddHead();
		void AddBody();
		void AddHand();
		void AddFoot();
		Person GetResult();
	}

	public class ThinPersonBuilder:IBuilder{

		private Person person;

		public ThinPersonBuilder() {
			person = new ThinPerson();
		}

        public void AddHead()
        {
			person.AddPart("瘦人头");
        }

        public void AddBody()
        {
			person.AddPart("瘦人体");
		}

        public void AddHand()
        {
			person.AddPart("瘦人手");
		}

        public void AddFoot()
        {
			person.AddPart("瘦人脚");
		}

        public Person GetResult()
        {
			return person;
		}
    }

	public class FatPersonBuilder : IBuilder
	{

		private Person person;

		public FatPersonBuilder()
		{
			person = new FatPerson();
		}

		public void AddHead()
		{
			person.AddPart("胖人头");
		}

		public void AddBody()
		{
			person.AddPart("胖人体");
		}

		public void AddHand()
		{
			person.AddPart("胖人手");
		}

		public void AddFoot()
		{
			person.AddPart("胖人脚");
		}

		public Person GetResult()
		{
			return person;
		}
	}

	public class Director {
		public Person Construct(IBuilder builder) {

			builder.AddHead();
			builder.AddBody();
			builder.AddHand();
			builder.AddFoot();

			return builder.GetResult();
		}
	}
}
