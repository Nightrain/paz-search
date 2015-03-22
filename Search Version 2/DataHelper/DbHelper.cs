using ModularSearch;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;


namespace DataHelper
{
    public class DbHelper
    {
       public bool DidCross(DbGeometry start, DbGeometry end)
       {
			 bool didCross;
			 using (DataMapsEntities me = new DataMapsEntities ())
			 {
				 object StartPoly = me.base_social.Where (f => f.geom.Contains (start)).FirstOrDefault ();
				 object EndPoly = me.base_social.Where (f => f.geom.Contains (end)).FirstOrDefault ();
				 // I hate negative logic too.  But if they equal each other then they did not cross
				 didCross = !StartPoly.Equals (EndPoly);
			 }
			 //string s = start.WellKnownValue.WellKnownText.Replace("POINT (","").Replace(")","");
			 //string e = end.WellKnownValue.WellKnownText.Replace("POINT (", "").Replace(")", "");
			 //string a = start.XCoordinate.Value.ToString ();
			 //DbGeometry myLine = DbGeometry.LineFromText("LINESTRING( " + s + " , " + e + ")",0);

			 return didCross;
       }

		 public base_food GetFoodSite( DbGeometry inLocation )
		 {
			 base_food bf = null;
			 using (DataMapsEntities me = new DataMapsEntities ())
			 {
				 bf = me.base_food.Where (g => g.geom.Contains (inLocation)).FirstOrDefault () as base_food;
			 }
			 return bf;
		 }

		 public base_move GetMoveSite( DbGeometry inLocation )
       { 
          base_move bm = null;
          using(DataMapsEntities me = new DataMapsEntities())
          {
             bm = me.base_move.Where(f => f.geom.Contains(inLocation)).FirstOrDefault() as base_move;
          }
          return bm;
       }

		 public List<base_release> GetReleaseSites()
		 {
			 List<base_release> br = new List<base_release> ();
			 using (DataMapsEntities me = new DataMapsEntities ())
			 {
				 br = me.base_release.ToList ();
			 }
			 return br;
		 }

		 public base_risk GetRiskSite( DbGeometry inLocation )
       {
          base_risk br = null;
          using (DataMapsEntities me = new DataMapsEntities())
          {
             br = me.base_risk.Where(f => f.geom.Contains(inLocation)).FirstOrDefault() as base_risk;
          }
          return br;

       }

		 public bool IsStillOnMap( DbGeometry inLocation )
		 {
			 bool onMap = false;
			 object o;
			 using (DataMapsEntities me = new DataMapsEntities ())
			 {
				 o = me.base_social.Where (f => f.geom.Contains (inLocation)).FirstOrDefault ();
				 if (o != null) { onMap = true; }
			 }
			 return onMap;
		 }

		 public bool LoadMaps()
		 {
			 using (GisHelper gh = new GisHelper ())
			 {
				 gh.loadFoodFiles (@"E:\SEARCHwork\Maps\Food\Ridenour_food9x9.shp");
				 gh.loadMoveFiles (@"E:\SEARCHwork\Maps\Move\Ridenour_move9x9.shp");
				 gh.loadReleaseFile (@"E:\SEARCHwork\Maps\Release\Ridenour_release3.shp");
				 gh.loadRiskFiles (@"E:\SEARCHwork\Maps\Risk\Ridenour_risk9x9.shp");
				 gh.loadSocialFiles (@"E:\SEARCHwork\Maps\Social\Ridenour_social9x9.shp");

			 }
			 return true;

		 }
    }
}
