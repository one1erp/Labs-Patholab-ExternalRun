using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace ExternalRun
{
    public partial class Form2 : Form
    {
        private Oracle.ManagedDataAccess.Client.OracleConnection _connection;

        public Form2()
        {
            InitializeComponent();
        }

 
        internal void InitializeCon(Oracle.ManagedDataAccess.Client.OracleConnection connection)
        {
            _connection = connection;
            userControl11.InitializeCon(connection);
        }
    }
}
