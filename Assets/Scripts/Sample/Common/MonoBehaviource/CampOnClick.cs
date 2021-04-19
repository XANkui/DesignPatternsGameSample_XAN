using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public class CampOnClick : MonoBehaviour
	{
        private ICamp mCamp;

        public ICamp Camp { set => mCamp=value; }
        private void OnMouseUpAsButton()
        {
            PlayGameFacade.Instance.ShowCampInfo(mCamp);
        }
    }
}
