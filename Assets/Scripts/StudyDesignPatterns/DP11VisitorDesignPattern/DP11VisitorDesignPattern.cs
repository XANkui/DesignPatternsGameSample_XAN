using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MadGazeSlamDemo { 

	public class DP11VisitorDesignPattern : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			TestDP11VisitorDesignPattern();
		}

		// Update is called once per frame
		void TestDP11VisitorDesignPattern() {
			ShapeContain shapeContain = new ShapeContain();

			SphereVisitorShape sphere = new SphereVisitorShape(1,1,10);
			CubeVisitorShape cube1 = new CubeVisitorShape(1,12,30);
			CubeVisitorShape cube2 = new CubeVisitorShape(1,12,20);
			CyclinderVisitorShape cyclinder = new CyclinderVisitorShape(1,2,15);

			shapeContain.AddShape(sphere);
			shapeContain.AddShape(cube1);
			shapeContain.AddShape(cube2);
			shapeContain.AddShape(cyclinder);

			AmountVisitor amountVisitor = new AmountVisitor();
			shapeContain.RunVisitor(amountVisitor);
			Debug.Log(GetType()+ "/TestDP11VisitorDesignPattern()/ amountVisitor amount =  "+ amountVisitor.Amount);

			CubeAmountVisitor cubeAmountVisitor = new CubeAmountVisitor();
			shapeContain.RunVisitor(cubeAmountVisitor);
			Debug.Log(GetType() + "/TestDP11VisitorDesignPattern()/ cubeAmountVisitor amount =  " + cubeAmountVisitor.Amount);
						
			VolumeVisitor volumeVisitor = new VolumeVisitor();
			shapeContain.RunVisitor(volumeVisitor);
			Debug.Log(GetType() + "/TestDP11VisitorDesignPattern()/ volumeVisitor volume =  " + volumeVisitor.Volume);

		}
	}

	public class ShapeContain {
		private List<IVisitorShape> mShapeLst = new List<IVisitorShape>();

		public void AddShape(IVisitorShape shape) {
			mShapeLst.Add(shape);
		}

		public void RunVisitor(IShapeVisitor visitor) {
            foreach (IVisitorShape shape in mShapeLst)
            {
				shape.RunVisitor(visitor);

			}
		}
	}

	public abstract class IVisitorShape {
		private int mAmount = 1;
		private int mEdge = 1;
		private int mVolume = 1;

		public int Amount => mAmount;
		public int Edge => mEdge;
		public int Volume => mVolume;

		protected IVisitorShape(int mAmount, int mEdge, int mVolume)
        {
            this.mAmount = mAmount;
            this.mEdge = mEdge;
            this.mVolume = mVolume;
        }

        public abstract void RunVisitor(IShapeVisitor visitor);
	}

	public class SphereVisitorShape : IVisitorShape {
        public SphereVisitorShape(int mAmount, int mEdge, int mVolume) : base(mAmount, mEdge, mVolume)
        {
        }

        public override void RunVisitor(IShapeVisitor visitor)
        {
			visitor.VisitSphere(this);
        }
    }

	public class CubeVisitorShape : IVisitorShape
	{
        public CubeVisitorShape(int mAmount, int mEdge, int mVolume) : base(mAmount, mEdge, mVolume)
        {
        }

        public override void RunVisitor(IShapeVisitor visitor)
		{
			visitor.VisitCube(this);
		}
	}

	public class CyclinderVisitorShape : IVisitorShape
	{
        public CyclinderVisitorShape(int mAmount, int mEdge, int mVolume) : base(mAmount, mEdge, mVolume)
        {
        }

        public override void RunVisitor(IShapeVisitor visitor)
		{
			visitor.VisitCyclinder(this);
		}
	}

	public abstract class IShapeVisitor {
		public abstract void VisitSphere(IVisitorShape shape);
		public abstract void VisitCube(IVisitorShape shape);
		public abstract void VisitCyclinder(IVisitorShape shape);
	}

	public class AmountVisitor : IShapeVisitor {

		private int amount = 0;
		public int Amount => amount;
        public override void VisitSphere(IVisitorShape shape)
        {
			amount+=shape.Amount;

		}

        public override void VisitCube(IVisitorShape shape)
        {
			amount += shape.Amount;
		}

        public override void VisitCyclinder(IVisitorShape shape)
        {
			amount += shape.Amount;
		}
    }

	public class CubeAmountVisitor : IShapeVisitor
	{

		private int amount = 0;
		public int Amount => amount;
		public override void VisitSphere(IVisitorShape shape)
		{
			
		}

		public override void VisitCube(IVisitorShape shape)
		{
			amount += shape.Amount;
		}

		public override void VisitCyclinder(IVisitorShape shape)
		{
			
		}
	}

	public class VolumeVisitor : IShapeVisitor
	{

		private int volume = 0;
		public int Volume => volume;

		public override void VisitSphere(IVisitorShape shape)
		{
			volume += shape.Volume;

		}

		public override void VisitCube(IVisitorShape shape)
		{
			volume += shape.Volume;
		}

		public override void VisitCyclinder(IVisitorShape shape)
		{
			volume += shape.Volume;
		}
	}
}
