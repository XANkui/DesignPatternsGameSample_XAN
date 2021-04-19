using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Study_XAN { 

	public class DP01StateDesignPattern : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			TestStateDesignPattern();
		}

		void TestStateDesignPattern() {
			Context context = new Context();
			context.SetState(new ConcreteStateA(context));
			context.Handle(12);
			context.Handle(9);
			context.Handle(2);
			context.Handle(13);
			context.Handle(10);
		}
	}


	#region StateDesignPattern
	public class Context
	{
		private IState mCurState;

		public void SetState(IState state) {
			mCurState = state;
		}

		public void Handle(int arg) {
			mCurState.Handle(arg);
		}
	}

	public interface IState {
		void Handle(int arg);
	}

	public class ConcreteStateA : IState {
		private Context mContext;

		public ConcreteStateA(Context context) { mContext = context; }

        public void Handle(int arg)
        {
			Debug.Log(GetType()+ "/Handle()/ 处理");

            if (arg > 10)
            {
				mContext.SetState(new ConcreteStateB(mContext));
				Debug.Log(GetType() + "/Handle()/ 状态切换");
			}
        }
    }

	public class ConcreteStateB : IState
	{
		private Context mContext;
		public ConcreteStateB(Context context) { mContext = context; }
		public void Handle(int arg)
		{
			Debug.Log(GetType() + "/Handle()/ 处理");

			if (arg <= 10)
			{
				mContext.SetState(new ConcreteStateA(mContext));
				Debug.Log(GetType() + "/Handle()/ 状态切换");
			}
		}
	}

	#endregion

}





