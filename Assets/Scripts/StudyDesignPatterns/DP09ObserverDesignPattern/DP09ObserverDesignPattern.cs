using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Study_XAN { 

	public class DP09ObserverDesignPattern : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			TestDP09ObserverDesignPattern();
		}

		void TestDP09ObserverDesignPattern() {
			ConcreteSubject sub = new ConcreteSubject();

			IObserver observer1 = new ConcreteObserver1("订阅者1");
			observer1.Subscribe(sub);
			sub.Update("周一新爆料");


			IObserver observer2 = new ConcreteObserver2("订阅者2");			
			observer2.Subscribe(sub);
			sub.Update("周二新爆料");

			observer1.Unsubscribe(sub);
			sub.Update("周五新爆料");
		}
	}

	public abstract class ISubject {
		private List<IObserver> mObserverLst = new List<IObserver>();

		public void AddObserver(IObserver observer) {
			mObserverLst.Add(observer);
		}

		public void RemoveObserver(IObserver observer)
		{
			mObserverLst.Remove(observer);
		}

		public void Update(string content) {
            foreach (IObserver observer in mObserverLst)
            {
				observer.Update(content);
            }
		}
	}

	public abstract class IObserver {

		protected string mName;

		public IObserver(string name) {
			mName = name;
		}

		public virtual void Subscribe(ISubject subject) {
			subject.AddObserver(this);
		}

		public virtual void Unsubscribe(ISubject subject)
		{
			subject.RemoveObserver(this);
		}
		public virtual void Update(string content) {
			Debug.Log(mName + " 获得订阅更新内容：" + content);
		}
	}

	public class ConcreteSubject : ISubject {
		
    }

    public class ConcreteObserver1 : IObserver
    {
        public ConcreteObserver1(string name) : base(name)
        {
        }
    }

    public class ConcreteObserver2 : IObserver
    {
        public ConcreteObserver2(string name) : base(name)
        {
        }
    }
}
