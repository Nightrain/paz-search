using System;
using log4net;

namespace SEARCH
{
	/// <summary>
	/// 
	/// </summary>
	public class DirectedMover : SEARCH.Mover
	{
		#region�Public�Members�(4)�

		#region�Constructors�(1)�

		public DirectedMover()
		{
			myMover = RandomWCMover.getRandomWCMover();
		}

		#endregion�Constructors�
		#region�Methods�(3)�

		public override double getStepLength()
		{
			return myMover.getStepLength();
		}

		public override double getTurnAngle(double turtosity)
		{
			return myMover.getTurnAngle(turtosity);
		}

		public override void move(ref double percentTimeStep, Animal inA)
		{
            //Changed homing so that an animal only reorients towards a HR site each full timestep
            //to prevent bumping against impermeable boundary repeatedly
         try
         {
            if (percentTimeStep == 0.0)
            {
               inA.Heading = System.Math.Atan((inA.Location.Y - inA.HomeRangeCenter.Y) / (inA.Location.X - inA.HomeRangeCenter.X));
               if (inA.Location.X > inA.HomeRangeCenter.X)
                  inA.Heading = inA.Heading + Math.PI;
               myMover.move(ref percentTimeStep, inA);

            }
         }
         catch (System.ArithmeticException ex)
         {
            ILog errolog = LogManager.GetLogger("DirectedMover");
            errolog.Error(ex.Message);
            errolog.Error("The animal passed in is " + inA.IdNum.ToString());
            errolog.Error("My location is " + inA.getLocation_XY());
            errolog.Error("My HomeRange Center is " + inA.HomeRangeCenter.X.ToString() + " " + inA.HomeRangeCenter.Y.ToString());
            errolog.Error("My calculation for Heading was System.Math.Atan((inA.Location.Y - inA.HomeRangeCenter.Y) / (inA.Location.X - inA.HomeRangeCenter.X));");
         }

           
			
		}

		#endregion�Methods�

		#endregion�Public�Members�

		#region�Non-Public�Members�(1)�

		#region�Fields�(1)�

		RandomWCMover myMover;

		#endregion�Fields�

		#endregion�Non-Public�Members�
	}
}
