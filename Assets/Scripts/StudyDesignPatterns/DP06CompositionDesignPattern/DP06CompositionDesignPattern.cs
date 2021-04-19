using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Study_XAN { 

	public class DP06CompositionDesignPattern : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			TestDP06CompositionDesignPattern();
		}

		void TestDP06CompositionDesignPattern() {
			Composite root = new Composite("root");
			Leaf leaf1 = new Leaf("leaf1");
			Composite branch1 = new Composite("branch1");
			Leaf leaf2 = new Leaf("leaf2");
			Leaf leaf3 = new Leaf("leaf3");
			Leaf leaf4 = new Leaf("leaf4");

			root.AddChild(leaf1);
			root.AddChild(branch1);
			root.AddChild(leaf2);
			root.AddChild(leaf3);
			branch1.AddChild(leaf4);

			root.Show();
		}
	}

	public abstract class Component {
		protected string mName;
		protected List<Component> mChildren;
		

		public Component(string name) {
			mName = name;
			mChildren = new List<Component>();
		}

		public abstract void AddChild(Component c);
		public abstract void RemoveChild(Component c);
		public abstract Component GetChild(int index);
		public abstract void Show(int depth=1);
	}

	public class Leaf : Component {
        public Leaf(string name) : base(name)
        {
        }

        public override void AddChild(Component c)
        {
			Debug.LogError(GetType()+ "/AddChild()/ Leaf Can not Add Child");
        }

        public override void RemoveChild(Component c)
        {
			Debug.LogError(GetType() + "/RemoveChild()/ Leaf Can not Remove Child");
		}

        public override Component GetChild(int index)
        {
			Debug.LogError(GetType() + "/GetChild()/ Leaf has not Child");
			return null;
        }

        public override void Show(int depth=1)
        {
			Debug.Log(GetType() + "/Show()/ " +new string('-', depth) + mName);
		}
    }

	public class Composite : Component {
        public Composite(string name) : base(name)
        {
        }

        public override void AddChild(Component c)
        {
			mChildren.Add(c);
        }

        public override void RemoveChild(Component c)
        {
			mChildren.Remove(c);
		}

        public override Component GetChild(int index)
        {
			return mChildren[index];

		}

        public override void Show(int depth=1)
        {
			Debug.Log(GetType() + "/Show()/ " + new string('-', depth) + mName);
            foreach (Component child in mChildren)
            {

				child.Show(depth + 2);
			}
		}
    }
}
