using System.Collections;
using System;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public static class UnityTool
	{
		public static GameObject FindChild(GameObject parent, string childName) {
			Transform[] children = parent.GetComponentsInChildren<Transform>();
			bool isFound = false;
			Transform child = null;

            foreach (Transform item in children)
            {
                if (item.name==childName)
                {
                    if (isFound == true)
                    {
                        Debug.LogWarning("DesignPattern_Sample_XAN.UnityTool/FindChild()/ "+parent + " has more than one child :" +childName);
                    }

                    isFound = true;
                    child = item;
                }
            }

            if (child==null)
            {
                Debug.LogError("DesignPattern_Sample_XAN.UnityTool/FindChild()/ child is null");
            }

            return child.gameObject;
		}

        public static void Attach(GameObject parent, GameObject child) {
            child.transform.parent = parent.transform;
            child.transform.localPosition = Vector3.zero;
            child.transform.localScale = Vector3.one;
            child.transform.localEulerAngles = Vector3.zero;
        }
	}
}
