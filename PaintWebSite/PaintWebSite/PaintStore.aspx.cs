//-----------------------------------------------------------------------
// <copyright file="PaintStore.aspx.cs" company="LakeheadU">
//     Copyright ENGI-3675. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace PaintWebSite
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Npgsql;

    /// <summary>
    /// This class holds all the backend works of the webpage
    /// </summary>
    public partial class PaintStore : System.Web.UI.Page
    {
        /// <summary>
        /// Within this method, a connection to the database is made on which queries are executed to retrieve data.
        /// </summary>
        /// <returns>Returns the populated table.</returns>
        public static List<string> RetrieveData()
        {
            // NPGSQL connection string (to connect to DB)
            // NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=Assignment_1; User Id=postgres; Password=0000;");

            // NPGSQL connection string (to connect to DB)
            NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder()
            {
                Host = "localhost",
                Database = "Assignment_1",
                IntegratedSecurity = true
            };

            NpgsqlConnection conn = new NpgsqlConnection(builder);
            List<string> retData = new List<string>();
            
            try
            {
                // Open connection
                conn.Open();
                
                // Execute SQL query on DB and read the data
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM paints", conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    retData.Add(string.Format("{0}", reader[0]));
                    retData.Add(string.Format("{0}", reader[1]));
                }
            }
            finally
            {
                // Close connection
                conn.Close();
            }

            return retData;
        }

        /// <summary>
        /// Within this method is called the method that retrieves data from the database. 
        /// This data is placed within dynamically created rows and sent to the ASP-table.
        /// Following this the connection to the database is closed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> retData = new List<string>();
            retData = RetrieveData();

            // Loop until all data is read
            for (int i = 0; i < retData.Count; i++)
            {
                // Dynamic creation of table rows and cells based on total data read from DB
                TableRow tRow = new TableRow();
                TableCell tCell1 = new TableCell();
                TableCell tCell2 = new TableCell();

                // Add created table cells to each created table row
                tRow.Cells.Add(tCell1);
                tRow.Cells.Add(tCell2);

                // Dynamic creation of labels
                Label lbl1 = new Label();
                Label lbl2 = new Label();

                // Data is placed within the labels
                lbl1.Text = retData[i].ToString();
                lbl2.Text = retData[++i].ToString();

                // Lables are placed within the table cells
                tCell1.Controls.Add(lbl1);
                tCell2.Controls.Add(lbl2);

                // Table cells are placed within row
                tRow.Cells.Add(tCell1);
                tRow.Cells.Add(tCell2);

                // Row is sent to ASP table (created in .aspx file)
                PaintTable.Rows.Add(tRow);
            }
        }
    }
}