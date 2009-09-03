using System;
using System.Xml.XPath;

namespace SEARCH_Console
{
   
   public sealed class HourlyModifierCollection : System.Collections.SortedList
   {
		#region�Public�Members�(4)�

		#region�Properties�(1)�

      public int NextStartHour
      {
         get 
         {
            HourlyModifier hm;
            hm = (HourlyModifier)this.GetByIndex(currIndex);
            mNextStartHour = hm.StartTime;
            return mNextStartHour; }

         set { mNextStartHour = value; }
      }

		#endregion�Properties�
		#region�Methods�(3)�

      public HourlyModifier getNext()
      {
         HourlyModifier hm;
         HourlyModifier nextHM;
         hm = (HourlyModifier)this.GetByIndex(currIndex);
         if (currIndex == this.Count - 1)
         {
            currIndex = 0;
         }
         else
         {
            currIndex++;
         }
         //since we moved the modifer up we need to move up the next start hour
         nextHM = (HourlyModifier)this.GetByIndex(currIndex);
         mNextStartHour = nextHM.StartTime;
         return hm;
      }

      public static HourlyModifierCollection GetUniqueInstance()
      {
         if (uniqueInstance == null) 
         { 
            uniqueInstance = new HourlyModifierCollection();
         }
         return uniqueInstance;
      }

      public void readXML(XPathNodeIterator nit)
      {
         XPathNodeIterator temp = nit.Current.Select("//HourlyModifiers/*");
         while (temp.MoveNext())
         {
           string type = temp.Current.GetAttribute("type", "");
            //		MessageBox.Show("Type = " + type);
            HourlyModifier hm = new HourlyModifier();
            temp.Current.MoveToFirstChild();
            hm.StartTime = System.Convert.ToInt32(temp.Current.Value);
            temp.Current.MoveToNext();
            hm.CaptureFood = System.Convert.ToDouble(temp.Current.Value);
            temp.Current.MoveToNext();
            hm.EnergyUsed = System.Convert.ToDouble(temp.Current.Value);
            temp.Current.MoveToNext();
            hm.MoveSpeed = System.Convert.ToDouble(temp.Current.Value);
            temp.Current.MoveToNext();
            hm.MoveTurtosity = System.Convert.ToDouble(temp.Current.Value);
            temp.Current.MoveToNext();
            hm.Name = temp.Current.Value;
            temp.Current.MoveToNext();
            hm.PerceptonModifier = System.Convert.ToDouble(temp.Current.Value);
            temp.Current.MoveToNext();
            hm.PredationRisk = System.Convert.ToDouble(temp.Current.Value);
         }//end of while
      }

      public void reset()
      {
         this.currIndex = 0;
      }

		#endregion�Methods�

		#endregion�Public�Members�

		#region�Non-Public�Members�(4)�

		#region�Fields�(3)�

      private int currIndex;
      private int mNextStartHour;
      private static HourlyModifierCollection uniqueInstance;

		#endregion�Fields�
		#region�Constructors�(1)�

      private HourlyModifierCollection()
      {
         currIndex = 0;
         
      }

		#endregion�Constructors�

		#endregion�Non-Public�Members�
   }
}
