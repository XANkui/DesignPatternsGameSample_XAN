using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Study_XAN { 

	public class DP02BridgeDesignPattern : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			TestDP02BridgeDesignPattern();
		}

		void TestDP02BridgeDesignPattern() {

			//IRenderEngine renderEngine = new OpenGL();
			IRenderEngine renderEngine = new DirextX();

			Sphere sphere = new Sphere(renderEngine);
			sphere.Draw();

			Cube cube = new Cube(renderEngine);
			cube.Draw();

			Capsual capsual = new Capsual(renderEngine);
			capsual.Draw();
		}
	}


	public abstract class IShape {
		protected string mName;
		protected IRenderEngine mIRenderEngine;

		public IShape(IRenderEngine renderEngine) { mIRenderEngine = renderEngine; }
		public abstract void Draw();
	}

	public abstract class IRenderEngine {
		public abstract void Render(string name);
	}

	public class Sphere: IShape
	{
		public Sphere(IRenderEngine renderEngine):base(renderEngine) {
			mName = "Sphere";
			
		}

		public override void Draw() {
			mIRenderEngine.Render(mName);
		}
	}

	public class Cube:IShape
	{
		public Cube(IRenderEngine renderEngine):base(renderEngine)
		{
			mName = "Cube";
			
		}

		public override void Draw()
		{
			mIRenderEngine.Render(mName);
		}
	}

	public class Capsual:IShape
	{
		public Capsual(IRenderEngine renderEngine) : base(renderEngine)
		{
			mName = "Capsual";

		}

		public override void Draw()
		{
			mIRenderEngine.Render(mName);
		}
	}

	public class OpenGL:IRenderEngine {
		public override void Render(string name) {
			Debug.Log(GetType()+ "/Render()/ OpenGL draw a "+ name);
		}
	}

	public class DirextX : IRenderEngine
	{
		public override void Render(string name)
		{
			Debug.Log(GetType() + "/Render()/ DirextX draw a " + name);
		}
	}
}
