using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public static class UITool 
	{
		public static GameObject GetCanvas(string name="Canvas") {
			return GameObject.Find(name);
		}

		public static T FindChild<T>(GameObject parent, string childName) {
			GameObject uiGO = UnityTool.FindChild(parent, childName);
			T t = uiGO.GetComponent<T>();
            if (t ==null)
            {
				Debug.LogError("/()/ There is not  " +t.ToString()+" on the "+childName);

			}
			return t;
		}
	}
}
