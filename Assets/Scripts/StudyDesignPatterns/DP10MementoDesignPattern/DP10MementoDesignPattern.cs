using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Study_XAN {

	public class DP10MementoDesignPattern : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			TestDP10MementoDesignPattern();
		}

		void TestDP10MementoDesignPattern() {
			CareTake careTake = new CareTake();

			Originator originator = new Originator();
			originator.SetState("state_1");
			originator.ShowState();
			careTake.AddMemento("v1.0",originator.CreateMemento());

			originator.SetState("state_2");
			originator.ShowState();
			careTake.AddMemento("v2.0", originator.CreateMemento());

			originator.SetState("state_3");
			originator.ShowState();
			careTake.AddMemento("v3.0", originator.CreateMemento());

			originator.SetMemento(careTake.GetMemento("v2.0"));
			originator.ShowState();
		}
	}

	public class Originator {
		private string mState;
		public void SetState(string state)
		{
			mState = state;
		}

		public void ShowState()
		{
			Debug.Log(GetType() + "/ShowState()/ " + mState);
		}

		public Memento CreateMemento() {
			Memento memento = new Memento();
			memento.SetState(mState);
			return memento;
		}

		public void SetMemento(Memento memento)
		{
			SetState(memento.GetState());
		}
	}

	public class Memento {
		private string mState;

		public void SetState(string state) {
			mState = state;
		}

		public string GetState() {
			return mState;
		}
	}

	public class CareTake{
		Dictionary<string, Memento> mMementoDict = new Dictionary<string, Memento>();

		public void AddMemento(string version, Memento memento) {
			mMementoDict.Add(version, memento);
		}

		public Memento GetMemento(string version) {
            if (mMementoDict.ContainsKey(version) ==false)
            {
				Debug.LogError(GetType()+ "/()/mMementoDict.ContainsKey() ==false  : "+ version);
				return null;
            }

			return mMementoDict[version];
		}
	}
}
