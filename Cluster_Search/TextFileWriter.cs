using System.IO;
using System.Collections.Specialized;
using log4net;
namespace SEARCH
{
   public class TextFileWriter
   {
        #region Public Members (5) 

        #region Constructors (1) 

       private ILog eLog = LogManager.GetLogger("Error");

      public TextFileWriter(string path, string fileName)
      {
         bool exists = false;
         sc = new StringCollection();
         if (path != null)
         {
             if (!System.IO.Directory.Exists(path))
             {
                 System.IO.Directory.CreateDirectory(path);
             }
             if(System.IO.File.Exists(path + "\\" + fileName + ".txt"))
             {
                 exists = true;
               
             }
             sw = new StreamWriter(path + "\\" + fileName + ".txt", true);
             sw.AutoFlush = true;
             if (!exists)
             {
                 sw.WriteLine("Year, Day, Time, Animal #, X, Y, Asleep, Behavior Mode, Energy Level, Risk, ProbFoodCap, MVL, MSL, PercptionDist, Percent Step");
             }
         }
      }

        #endregion Constructors 
        #region Properties (1) 

      public string OutPath
      {
         get { return mOutPath; }
         set { mOutPath = value; }
      }

        #endregion Properties 
        #region Methods (3) 

      public void addLine(string inValue)
      {
         try
         {
            this.sw.WriteLine(inValue);
            
         }
         catch (System.Exception ex)
         {

            eLog.Debug(ex);
         }
      }

      public void close()
      {
         sw.Close();
      }

      public void WriteOutTimeStep()
      {
         foreach (string s in this.sc)
         {
            this.sw.WriteLine(s);
         }
         this.sc.Clear();
      }

        #endregion Methods 

        #endregion Public Members 

        #region Non-Public Members (3) 

        #region Fields (3) 

      private string mOutPath;
      private StringCollection sc;
      private System.IO.StreamWriter sw;

        #endregion Fields 

        #endregion Non-Public Members 
   }
}
