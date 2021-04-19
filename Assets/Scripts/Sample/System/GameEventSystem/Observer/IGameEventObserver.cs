using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public abstract class IGameEventObserver 
	{
		public abstract void Update();
		public abstract void SetSubject(IGameEventSubject subject);

	}
}
