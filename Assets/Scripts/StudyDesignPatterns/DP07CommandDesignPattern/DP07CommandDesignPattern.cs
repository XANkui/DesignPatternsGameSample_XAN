using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Study_XAN {

	public class DP07CommandDesignPattern : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			TestDP07CommandDesignPattern();
		}

		void TestDP07CommandDesignPattern() {
			Reciever reciever = new Reciever();
			Invoker invoker = new Invoker();

			ConreteCommand1 cmd1 = new ConreteCommand1(reciever," Cmd 1");
			ConreteCommand1 cmd2 = new ConreteCommand1(reciever, " Cmd 2");
			invoker.AddCommand(cmd1);
			invoker.AddCommand(cmd2);

			invoker.NotifyToExcute();
		}
	}

	public class Invoker {
		private List<ICommand> mCommandLst = new List<ICommand>();

		public void AddCommand(ICommand command) {
			mCommandLst.Add(command);
			Debug.Log(GetType() + "/AddCommand()/ 接收到命令 : " + command.CmdName);
		}

		public void NotifyToExcute() {
            foreach (ICommand command in mCommandLst)
            {
				command.Excute();
            }

			mCommandLst.Clear();
		}
	}

	public abstract class ICommand{

		protected string mCmdName;
		public string CmdName { get => mCmdName; }
		public ICommand(string cmdName) { mCmdName = cmdName; }
		public abstract void Excute();
	}

	public class ConreteCommand1 : ICommand {

		Reciever mReciever;

		public ConreteCommand1(Reciever reciever, string cmdName) : base(cmdName) {
			mReciever = reciever;
		}

		public override void Excute()
        {
			mReciever.Excute(CmdName);

		}
    }

	public class Reciever {

		public void Excute(string cmd) {
			Debug.Log(GetType()+ "/Excute()/ 执行命令 cmd: "+cmd);
		}
	}
}
