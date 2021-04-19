using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN { 

	public abstract class ICharactorVisitor 
	{
		public abstract void VisitEnemy(IEnemy enemy);
		public abstract void VisitSoldier(ISoldier soldier);

	}
}
