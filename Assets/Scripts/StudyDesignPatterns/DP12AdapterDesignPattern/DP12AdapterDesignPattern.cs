using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Study_XAN { 

	public class DP12AdapterDesignPattern : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			TestDP12AdapterDesignPattern();
		}

		void TestDP12AdapterDesignPattern() {

			StandardInterface si = new StandardImplementA();
			si.Request();

			Adapter adapter = new Adapter(new NewPlugins());
			si = adapter;
			si.Request();
		}
	}

	public interface StandardInterface {
		void Request();
	}

	public class StandardImplementA : StandardInterface {
        public void Request()
        {
			Debug.Log(GetType()+ "/StandardImplementA()/");
        }
    }

	public class NewPlugins {
		public void SpecificRequest() {
			Debug.Log(GetType() + "/SpecificRequest()/");
		}
	}

	public class Adapter : StandardInterface {

		private NewPlugins mPlugin;

		public Adapter(NewPlugins plugin) {
			mPlugin = plugin;
		}

        public void Request()
        {
			mPlugin.SpecificRequest();

		}
    }
}
