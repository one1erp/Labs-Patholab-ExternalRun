using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExternalRun
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    /// [Designer("System.Windows.Forms.Design.ControlDesigner, System.Design")]
    [DesignerSerializer("System.ComponentModel.Design.Serialization.TypeCodeDomSerializer , System.Design", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design")]
    public partial class UserControl1 : UserControl
    {
        private Oracle.ManagedDataAccess.Client.OracleConnection _connection;
        OracleCommand _cmd;
        private List<Side> sideList;
        public UserControl1()
        {
            InitializeComponent();
        }

        public List<Organ> organs { get; set; }
        internal void InitializeCon(Oracle.ManagedDataAccess.Client.OracleConnection connection)
        {
            _connection = connection;

            ReadOrgan();
            ReadSide();

        }

        private void ReadOrgan()
        {
            organs = new List<Organ>();
            string sql = " select ou.U_ORGAN_CODE, ou.U_ORGAN_HEBREW_NAME    from lims_sys.u_norgan o,        lims_sys.u_norgan_user ou" +
     " where ou.U_NORGAN_ID=o.U_NORGAN_ID    and   o.VERSION_STATUS='A'        order by ou.U_ORGAN_HEBREW_NAME";

            _cmd = new OracleCommand(sql, _connection);
            OracleDataReader reader;

            reader = _cmd.ExecuteReader();

            while (reader.Read())
            {
                organs.Add(new Organ
                {
                    ORGAN_CODE = reader["U_ORGAN_CODE"].ToString(),
                    ORGAN_HEBREW_NAME = reader["U_ORGAN_HEBREW_NAME"].ToString()
                });
            }
            cmbOrgan.ItemsSource = organs;
            _cmd.Dispose();
        }

        private void cmbOrgan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Organ org = cmbOrgan.SelectedItem as Organ;
            if (org == null) return;

            string sql = " select otu.U_TOPOGRAPHY_CODE, tu.U_TOPOGRAPHY_HEBREW_NAME " +
                "from lims_sys.u_norgan_topography ot,      lims_sys.u_norgan_topography_user otu,    " +
                " lims_sys.u_ntopography t,      lims_sys.u_ntopography_user tu " +
                "where otu.U_NORGAN_TOPOGRAPHY_ID=ot.U_NORGAN_TOPOGRAPHY_ID    and   tu.U_NTOPOGRAPHY_ID = t.U_NTOPOGRAPHY_ID   " +
                "and   t.VERSION_STATUS='A'   and   tu.U_TOPOGRAPHY_CODE=otu.U_TOPOGRAPHY_CODE  " +
                "and   otu.u_organ_code='" + (org.ORGAN_CODE) + "' order by  tu.U_TOPOGRAPHY_HEBREW_NAME";
            var TOPOGRAPHYs = new List<TOPOGRAPHY>();

            _cmd = new OracleCommand(sql, _connection);
            OracleDataReader reader;

            reader = _cmd.ExecuteReader();

            while (reader.Read())
            {
                TOPOGRAPHYs.Add(new TOPOGRAPHY
                {
                    TOPOGRAPHY_CODE = reader["U_TOPOGRAPHY_CODE"].ToString(),
                    TOPOGRAPHY_HEBREW_NAME = reader["U_TOPOGRAPHY_HEBREW_NAME"].ToString()
                });
            }
            cmbTOPOGRAPHY.ItemsSource = TOPOGRAPHYs;
            _cmd.Dispose();

        }

        void ReadSide()
        {
            sideList = new List<Side>();

            string sql = " select sd.NAME, sd.DESCRIPTION   from lims_sys.u_nside sd order by sd.U_NSIDE_ID";

            _cmd = new OracleCommand(sql, _connection);
            OracleDataReader reader;

            reader = _cmd.ExecuteReader();

            while (reader.Read())
            {
                sideList.Add(new Side
                {
                    Name = reader["NAME"].ToString(),
                    Description = reader["DESCRIPTION"].ToString()
                });
            }
        }

        private void cmbTOPOGRAPHY_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbbSide.Items.Clear();
            Organ org = cmbOrgan.SelectedItem as Organ;
            if (org == null) return;
            TOPOGRAPHY topg = cmbTOPOGRAPHY.SelectedItem as TOPOGRAPHY;
            if (topg == null) return;


            //read relevant sides for current organ & topography:
            string sql = " select otu.U_R_SNOMED, otu.U_L_SNOMED, otu.U_O_SNOMED, otu.U_RL_SNOMED, otu.U_NS_SNOMED " +
             " from lims_sys.u_norgan_topography_user otu " +
             " where otu.U_ORGAN_CODE='" + org.ORGAN_CODE + "'" +
             " and   otu.U_TOPOGRAPHY_CODE='" + topg.TOPOGRAPHY_CODE + "'";


            _cmd = new OracleCommand(sql, _connection);
            OracleDataReader reader;
            reader = _cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbbSide.Items.Add(sideList[0].Description);
            }
            
            _cmd.Dispose();

        }


        //'get possible sides by selected organ and topography:

    }
    public class Organ
    {
        public string ORGAN_CODE { get; set; }
        public string ORGAN_HEBREW_NAME { get; set; }
        public override string ToString()
        {
            return ORGAN_HEBREW_NAME;
        }
    }
    public class TOPOGRAPHY
    {
        public string TOPOGRAPHY_CODE { get; set; }
        public string TOPOGRAPHY_HEBREW_NAME { get; set; }
        public override string ToString()
        {
            return TOPOGRAPHY_HEBREW_NAME;
        }
    }
    public class Side
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
