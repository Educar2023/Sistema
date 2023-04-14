using FacturacionElectronica.constant;
using System.Configuration;

namespace FacturacionElectronica.repository
{
    public abstract class DataAcces
    {
        public static string _conncetionString;

        protected static string ConnectionString
        {
            get
            {
                if (_conncetionString == null)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                    ConfigurationSectionGroup userSetting = config.GetSectionGroup("userSettings");
                    ClientSettingsSection settings = (ClientSettingsSection)userSetting.Sections.Get(0);
                    SettingElement srvElem = settings.Settings.Get("SERVIDOR");
                    SettingElement bdElem = settings.Settings.Get("BD_COD");
                    string ServerName = string.Empty;
                    string BaseDatos = string.Empty;
                    if (srvElem != null)
                        ServerName = srvElem.Value.ValueXml.InnerText;
                    if (bdElem != null)
                        BaseDatos = bdElem.Value.ValueXml.InnerText;

                    DBCredential.CodBase = BaseDatos;

                    _conncetionString = string.Format("Data Source={0};Initial Catalog=BD_GCO{1};User={2};password={3}", ServerName, BaseDatos, DBCredential.user, DBCredential.pwd);
                }
                return _conncetionString;
            }
        }
    }
}
