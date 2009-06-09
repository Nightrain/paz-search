using System;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System.Collections.Generic;
namespace PAZ_Dispersal
{
   /// <summary>
   /// 
   /// </summary>
   public sealed class BestComboHomeRangeFinder : HomeRangeFinder
   {

		#region Static Fields (1) 

      static BestComboHomeRangeFinder uniqueInstance;

		#endregion Static Fields 

		#region Constructors (1) 

      public BestComboHomeRangeFinder()
      {
         // 
         // TODO: Add constructor logic here
         //
      }

		#endregion Constructors 

		#region Static Methods (1) 

      public static BestComboHomeRangeFinder getInstance()
      {
         if (uniqueInstance == null)
         {
            uniqueInstance = new BestComboHomeRangeFinder();
         }
         return uniqueInstance;
      }

		#endregion Static Methods 

		#region Overridden Methods (1) 

//      public override bool setHomeRangeCenter(Animal inAnimal, ESRI.ArcGIS.Geodatabase.IFeatureClass inAnmialMemoryMap)
//      {
//         bool success = false;
//         int numSuitableSites = 0;
//         try
//         {
//            fw.writeLine("inside setHomeRangeCenter for BestComboHomeRangeFinder");

//            fw.writeLine("calling get setSutitableSites");
//            numSuitableSites = setSutitableSites(inAnimal, inAnmialMemoryMap);
//            switch (numSuitableSites)
//            {
//               //nothing found so out of here
//               case 0:
//                  fw.writeLine("no spots were found");
//                  break;
//               //only one found so that is easy
//               case 1:
//                  fw.writeLine("found only one so that is it");
//                  success = true;
//                  EligibleHomeSite ehs;
//                  IPoint p;
//                  p = new PointClass();
//                  ehs = inAnimal.MySites.getFirstSuitableSite();
//                  p.X = ehs.X;
//                  p.Y = ehs.Y;
//                  inAnimal.HomeRangeCenter = p as PointClass;
//                  break;
//               //multiple sites are eligible so go get the needed data
//               default:
//                  fw.writeLine("multiple eligible spots where found so now fill eligble spots with ranking criteria");
//                  base.setDistance(inAnimal);
//                  inAnimal.MySites.setComboRank(inAnimal.DistanceWeight);
//                  inAnimal.HomeRangeCenter = base.getHomeRangeCenter(inAnimal.MySites) as PointClass;
//                  success = true;
//                  break;
//            }
//         }
//         catch (System.Exception ex)
//         {
//#if (DEBUG)
//            System.Windows.Forms.MessageBox.Show(ex.Message);
//#endif
//            FileWriter.FileWriter.WriteErrorFile(ex);
//         }
//         fw.writeLine("leaving BestComboHomeRangeFinder setHomeRangeCenter with a value of " + success.ToString());
//         return success;

//      }

      public override bool setHomeRangeCenter(Animal inAnimal, string inFileName)
      {
         bool foundHomeRange = false;
         base.setDistance(inAnimal);
         inAnimal.MySites.setComboRank(inAnimal.DistanceWeight);
         List<EligibleHomeSite> qs = inAnimal.MySites.getQualifiedSites();

         inAnimal.HomeRangeCenter = base.chooseHomeRangeCenter(qs, inAnimal.HomeRangeArea) as PointClass;
         if (inAnimal.HomeRangeCenter == null)
            foundHomeRange = false;

         return foundHomeRange;
         
      } 

		#endregion Overridden Methods 

   }
}
