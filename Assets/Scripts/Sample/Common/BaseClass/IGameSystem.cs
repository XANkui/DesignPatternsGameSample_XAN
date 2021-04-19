using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{ 

	public abstract class IGameSystem 
	{
		private PlayGameFacade mPlayGameFacade;
		public PlayGameFacade PlayGameFacade
		{
			get
			{
				if (mPlayGameFacade == null)
				{
					mPlayGameFacade = PlayGameFacade.Instance;
				}

				return mPlayGameFacade;
			}
		}
		public virtual void Init() { }
		public virtual void Release() { }
		public virtual void Update() { }
	}
}
