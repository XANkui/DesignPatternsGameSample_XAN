using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Study_XAN {

	public class DP08ChainOfResponsiblityDesignPattern : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			TestDP08ChainOfResponsiblityDesignPattern();
		}

		void TestDP08ChainOfResponsiblityDesignPattern(){
			string problem = "Small";

			IHandler smallHandler = new SmallHandler();
			IHandler mediumHandler = new MediumHandler();

			smallHandler.SetNextHandler(mediumHandler);

			smallHandler.Handle(problem);

			problem = "Medium";

			smallHandler.Handle(problem);
		}
	}

	public abstract class IHandler {
		protected IHandler mNextHandler;

		public virtual IHandler SetNextHandler(IHandler nextHandler)
		{
			mNextHandler = nextHandler;

			return mNextHandler;
		}

		public abstract void Handle(string problem);
	}

	public class SmallHandler : IHandler {
 

        public override void Handle(string problem)
        {
			if (problem == "Small")
			{
				Debug.Log(GetType() + "/Handle()/ ");
			}
			else {
				mNextHandler?.Handle(problem);
			}
        }
    }

	public class MediumHandler : IHandler
	{


		public override void Handle(string problem)
		{
			if (problem == "Medium")
			{
				Debug.Log(GetType() + "/Handle()/ ");
			}
			else
			{
				mNextHandler?.Handle(problem);
			}
		}
	}
}
