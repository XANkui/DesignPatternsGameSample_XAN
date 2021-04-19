using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class DestroySelfForTime : MonoBehaviour
	{
		private float time = 1;

		public float Time { set { time = value; } }

		// Start is called before the first frame update
		void Start()
		{
			GameObject.Destroy(this.gameObject, time);
		}

		
	}
}
