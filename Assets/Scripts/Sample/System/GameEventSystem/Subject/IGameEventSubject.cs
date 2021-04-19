using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class IGameEventSubject 
	{
		private List<IGameEventObserver> mObserverLst = new List<IGameEventObserver>();

		public void RegisterObserver(IGameEventObserver observer) {
			mObserverLst.Add(observer);
		}

		public void RemoveObserver(IGameEventObserver observer)
		{
			mObserverLst.Remove(observer);
		}

		public virtual void Notify() {
            foreach (IGameEventObserver observer in mObserverLst)
            {
				observer.Update();
            }
		}
	}
}
