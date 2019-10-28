using System;
using System.IO;
using System.Windows.Forms;

namespace TFSManager.Core
{
    [Serializable]
    public class Config
    {
        #region Singleton property

        private const string ConfigFileName = "config.xml";

        private static Config instance;

        public static string ProgramDir
        {
            get
            {
                if (programDir == null)
                {
                    programDir = Application.StartupPath;
                    if (programDir[programDir.Length - 1] != '\\')
                    {
                        programDir += '\\';
                    }
                }

                return programDir;
            }
        }

        /// <summary>
        /// Get singleton instance of Config
        /// </summary>
        public static Config Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = LoadFromFile();

                    if (instance == null)
                    {
                        instance = new Config();
                        instance.SaveToFile();
                    }
                }
                return instance;
            }
            set
            {
                instance = new Config();
            }
        }

        #endregion

        private static readonly Type[] extraTypes = new Type[0];
        private static string programDir;
        public string BuildTemplatesFileName { get; set; }

        public string TeamFoundationServerName { get; set; }


        private static Config LoadFromFile()
        {
            string fileName = Path.Combine(ProgramDir, ConfigFileName);
            if (File.Exists(fileName))
            {
                try
                {
                    string xml = File.ReadAllText(fileName);
                    return Util.DeserializeObjectFromXml(typeof(Config), extraTypes, xml) as Config;
                }
                catch (Exception e)
                {
                    Util.DebugWrite("Config.LoadFromFile", e);
                }
            }

            return null;
        }

        public void SaveToFile()
        {
            string xml = Util.SerializeObjectToXml(typeof(Config), extraTypes, this);
            File.WriteAllText(Path.Combine(ProgramDir, ConfigFileName), xml);
        }
    }
}