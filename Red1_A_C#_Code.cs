/*********************************************************
    Name: Red.cs
    Date: 12/22/17

*********************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Red
{

    public partial class Form1 : Form
    {
        //Initializes a new instance (creates an object or accessing code) of the SqlConnection class when given a connection string 
        //     and assigning it an alias ("cn")
        //     (This object can be called later using the alias to open a connection to a database)
        SqlConnection cn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True");
        //Initialize a new instance (creates an object or accessing code) of the SqlCommand class 
        //     and assigning it an alias ("cn")
        //     (This object can be called later using the alias to query the database.)
        SqlCommand cmd = new SqlCommand();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text != "" & comboBox1.Text != "")
            {
                /////////////////////////
                // INSERT DATE
                /////////////////////////

                DateTime dt_Insert_Date;
                dt_Insert_Date = DateTime.Now;

                //////////////////////////////////////////////////


                ////////////////////////
                // REPLACE SINGLE QUOTES
                ////////////////////////

                string str_Red_Daily_Work_Name;
                str_Red_Daily_Work_Name = comboBox1.Text;
                str_Red_Daily_Work_Name = str_Red_Daily_Work_Name.Replace("'", "\''");

                string str_Red_Daily_Work_Category;
                str_Red_Daily_Work_Category = comboBox2.Text;
                str_Red_Daily_Work_Category = str_Red_Daily_Work_Category.Replace("'", "\''");

                string str_Red_Daily_Work_Sprint;
                str_Red_Daily_Work_Sprint = textBox3.Text;
                str_Red_Daily_Work_Sprint = str_Red_Daily_Work_Sprint.Replace("'", "\''");

                string str_Red_Daily_Work_Type_Of_Ticket;
                str_Red_Daily_Work_Type_Of_Ticket = comboBox3.Text;
                str_Red_Daily_Work_Type_Of_Ticket = str_Red_Daily_Work_Type_Of_Ticket.Replace("'", "\''");

                string str_Red_Daily_Work_Beginning_Of_Day_State;
                str_Red_Daily_Work_Beginning_Of_Day_State = comboBox4.Text;
                str_Red_Daily_Work_Beginning_Of_Day_State = str_Red_Daily_Work_Beginning_Of_Day_State.Replace("'", "\''");

                string str_Red_Daily_Work_Ending_Of_Day_State;
                str_Red_Daily_Work_Ending_Of_Day_State = comboBox5.Text;
                str_Red_Daily_Work_Ending_Of_Day_State = str_Red_Daily_Work_Ending_Of_Day_State.Replace("'", "\''");

                string str_Red_Daily_Work_Notes;
                str_Red_Daily_Work_Notes = richTextBox1.Text;
                str_Red_Daily_Work_Notes = str_Red_Daily_Work_Notes.Replace("'", "\''");

                ////////////////////////////////////////////

                ////////////////////////
                // INT NULL VALUES
                ////////////////////////
                int intTfsNumber;
                intTfsNumber = 0;

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    intTfsNumber = 0;
                }
                else
                {
                    intTfsNumber = Convert.ToInt32(textBox2.Text);
                }

                int intPriorityNumber;
                intPriorityNumber = 0;

                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    intPriorityNumber = 0;
                }
                else
                {
                    intPriorityNumber = Convert.ToInt32(textBox4.Text);
                }

                decimal decTimeToday;
                decTimeToday = 0;

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    decTimeToday = 0;
                }
                else
                {
                    decTimeToday = Convert.ToDecimal(textBox1.Text);
                }

                ////////////////////////////////////////////


                //Open connection to database
                cn.Open();
                cmd.Connection = cn;

                //Sql command
                cmd.CommandText = "INSERT INTO Red.Red_Daily_Work " +
                    "(Red_Daily_Work_Record_Date" +
                    ", Red_Daily_Work_Name" +
                    ", Red_Daily_Work_Category" +
                    ", Red_Daily_Work_Time_Today" +
                    ", Red_Daily_Work_TFS_Number" +
                    ", Red_Daily_Work_Sprint" +
                    ", Red_Daily_Work_Type_Of_Ticket" +
                    ", Red_Daily_Work_Beginning_Of_Day_State" +
                    ", Red_Daily_Work_Ending_Of_Day_State" +
                    ", Red_Daily_Work_Business_Priority_For_Today" +
                    ", Red_Daily_Work_Notes" +
                    ", Red_Daily_Work_Insert_Date" +
                    ") " +
                    "VALUES ('" + dateTimePicker1.Text + "'" +
                    ",'" + str_Red_Daily_Work_Name + "'" +
                    ",'" + str_Red_Daily_Work_Category + "'" +
                    "," + decTimeToday + "" +
                    "," + intTfsNumber + "" +
                    ",'" + str_Red_Daily_Work_Sprint + "'" +
                    ",'" + str_Red_Daily_Work_Type_Of_Ticket + "'" +
                    ",'" + str_Red_Daily_Work_Beginning_Of_Day_State + "'" +
                    ",'" + str_Red_Daily_Work_Ending_Of_Day_State + "'" +
                    "," + intPriorityNumber + "" +
                    ",'" + str_Red_Daily_Work_Notes + "'" +
                    ",'" + dt_Insert_Date + "'" +
                    ")";

                //MessageBox.Show(cmd.CommandText);
                //Execute the sql command
                cmd.ExecuteNonQuery();

                //Insert into collection table (back up)
                cmd.CommandText = "INSERT INTO Red.Red_Daily_Work_bu " +
                    "(Red_Daily_Work_Record_Date" +
                    ", Red_Daily_Work_Name" +
                    ", Red_Daily_Work_Category" +
                    ", Red_Daily_Work_Time_Today" +
                    ", Red_Daily_Work_TFS_Number" +
                    ", Red_Daily_Work_Sprint" +
                    ", Red_Daily_Work_Type_Of_Ticket" +
                    ", Red_Daily_Work_Beginning_Of_Day_State" +
                    ", Red_Daily_Work_Ending_Of_Day_State" +
                    ", Red_Daily_Work_Business_Priority_For_Today" +
                    ", Red_Daily_Work_Notes" +
                    ", Red_Daily_Work_Insert_Date" +
                    ") " +
                    "VALUES ('" + dateTimePicker1.Text + "'" +
                    ",'" + str_Red_Daily_Work_Name + "'" +
                    ",'" + str_Red_Daily_Work_Category + "'" +
                    "," + decTimeToday + "" +
                    "," + intTfsNumber + "" +
                    ",'" + str_Red_Daily_Work_Sprint + "'" +
                    ",'" + str_Red_Daily_Work_Type_Of_Ticket + "'" +
                    ",'" + str_Red_Daily_Work_Beginning_Of_Day_State + "'" +
                    ",'" + str_Red_Daily_Work_Ending_Of_Day_State + "'" +
                    "," + intPriorityNumber + "" +
                    ",'" + str_Red_Daily_Work_Notes + "'" +
                    ",'" + dt_Insert_Date + "'" +
                    ")";
                cmd.ExecuteNonQuery();

                //Close connection to database
                cn.Close();

                //Clear fields on the form
                dateTimePicker1.Text = string.Empty;
                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                comboBox3.Text = string.Empty;
                comboBox4.Text = string.Empty;
                comboBox5.Text = string.Empty;
                textBox4.Text = string.Empty;
                richTextBox1.Text = string.Empty;
                textBox5.Text = string.Empty;


                MessageBox.Show("Record inserted!");
            }
            else
            {
                MessageBox.Show("Please enter the Date and Name of the record.");
            }

            //////////////////////////////////////
            // REFRESH DATAGRID
            //////////////////////////////////////
            using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Red.Red_Daily_Work ORDER BY Red_Daily_Work_Key DESC", conn))
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }

            //////////////////////////////////////////////////
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////
            // REFRESH DATAGRID
            //////////////////////////////////////
            using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Red.Red_Daily_Work ORDER BY Red_Daily_Work_Key DESC", conn))
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }

            //////////////////////////////////////////////////
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // Variable to check if record can be updated
            int RecordUpdateYn;
            //To set this variable inside a loop and use it outside of the loop
            //     you need to set the variable before the loop.
            RecordUpdateYn = 0;

            if (textBox5.Text != "")
            {
                //  Verify that the record exist to be UPDATED

                //Record number to be updated
                int checkUpdateRecordNum;
                checkUpdateRecordNum = Convert.ToInt32(textBox5.Text);

                //Query to pull data from the database
                string queryRecordUpdateYn;
                queryRecordUpdateYn = "SELECT COUNT(Red_Daily_Work_Key) AS Cnt " +
                                        "FROM Red.Red_Daily_Work " +
                                        "WHERE 1 = 1 " +
                                            "AND Red_Daily_Work_Key = " +
                                            "" + checkUpdateRecordNum + "";

                //Sql command
                SqlCommand cmdCheck = new SqlCommand(queryRecordUpdateYn, cn);

                try
                {
                    //Open connection to database
                    cn.Open();

                    //Initialize a data reader
                    SqlDataReader reader1 = cmdCheck.ExecuteReader();
                    while (reader1.Read())
                    {
                        //MessageBox.Show(reader["Cnt"].ToString());

                        //Assign a variable
                        if (reader1.IsDBNull(reader1.GetOrdinal("Cnt")))
                        {
                            RecordUpdateYn = 0;
                        }
                        else
                        {
                            RecordUpdateYn = (int)reader1["Cnt"];
                        }

                        //MessageBox.Show(RecordUpdateYn.ToString());
                    }
                    reader1.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //Close connection to database
                    cn.Close();
                }

                //MessageBox.Show(RecordUpdateYn.ToString());
                if (RecordUpdateYn == 1)
                {
                    //Clear fields on the form
                    dateTimePicker1.Text = string.Empty;
                    comboBox1.Text = string.Empty;
                    comboBox2.Text = string.Empty;
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    comboBox3.Text = string.Empty;
                    comboBox4.Text = string.Empty;
                    comboBox5.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    richTextBox1.Text = string.Empty;
                    //textBox5.Text = string.Empty;


                    string queryText1;
                    string queryText2;
                    string queryText3;
                    string queryText4;
                    string queryText5;
                    string queryText6;
                    string queryText7;
                    string queryText8;
                    string queryText9;
                    string queryText10;
                    string queryText11;


                    //Query to pull data from the database
                    queryText1 = "SELECT Red_Daily_Work_Record_Date  " +
                                    "FROM Red.Red_Daily_Work " +
                                    "WHERE 1 = 1 " +
                                        "AND Red_Daily_Work_Key = " +
                                        "" + checkUpdateRecordNum + "";
                    //Query to pull data from the database
                    queryText2 = "SELECT Red_Daily_Work_Name  " +
                                    "FROM Red.Red_Daily_Work " +
                                    "WHERE 1 = 1 " +
                                        "AND Red_Daily_Work_Key = " +
                                        "" + checkUpdateRecordNum + "";
                    //Query to pull data from the database
                    queryText3 = "SELECT Red_Daily_Work_Category  " +
                                    "FROM Red.Red_Daily_Work " +
                                    "WHERE 1 = 1 " +
                                        "AND Red_Daily_Work_Key = " +
                                        "" + checkUpdateRecordNum + "";
                    //Query to pull data from the database
                    queryText4 = "SELECT Red_Daily_Work_Time_Today  " +
                                    "FROM Red.Red_Daily_Work " +
                                    "WHERE 1 = 1 " +
                                        "AND Red_Daily_Work_Key = " +
                                        "" + checkUpdateRecordNum + "";
                    //Query to pull data from the database
                    queryText5 = "SELECT Red_Daily_Work_TFS_Number " +
                                    "FROM Red.Red_Daily_Work " +
                                    "WHERE 1 = 1 " +
                                        "AND Red_Daily_Work_Key = " +
                                        "" + checkUpdateRecordNum + "";
                    //Query to pull data from the database
                    queryText6 = "SELECT Red_Daily_Work_Sprint " +
                                    "FROM Red.Red_Daily_Work " +
                                    "WHERE 1 = 1 " +
                                        "AND Red_Daily_Work_Key = " +
                                        "" + checkUpdateRecordNum + "";
                    //Query to pull data from the database
                    queryText7 = "SELECT Red_Daily_Work_Type_Of_Ticket " +
                                    "FROM Red.Red_Daily_Work " +
                                    "WHERE 1 = 1 " +
                                        "AND Red_Daily_Work_Key = " +
                                        "" + checkUpdateRecordNum + "";
                    //Query to pull data from the database
                    queryText8 = "SELECT Red_Daily_Work_Beginning_Of_Day_State " +
                                    "FROM Red.Red_Daily_Work " +
                                    "WHERE 1 = 1 " +
                                        "AND Red_Daily_Work_Key = " +
                                        "" + checkUpdateRecordNum + "";
                    //Query to pull data from the database
                    queryText9 = "SELECT Red_Daily_Work_Ending_Of_Day_State  " +
                                    "FROM Red.Red_Daily_Work " +
                                    "WHERE 1 = 1 " +
                                        "AND Red_Daily_Work_Key = " +
                                        "" + checkUpdateRecordNum + "";
                    //Query to pull data from the database
                    queryText10 = "SELECT Red_Daily_Work_Business_Priority_For_Today  " +
                                    "FROM Red.Red_Daily_Work " +
                                    "WHERE 1 = 1 " +
                                        "AND Red_Daily_Work_Key = " +
                                        "" + checkUpdateRecordNum + "";
                    //Query to pull data from the database
                    queryText11 = "SELECT Red_Daily_Work_Notes  " +
                                    "FROM Red.Red_Daily_Work " +
                                    "WHERE 1 = 1 " +
                                        "AND Red_Daily_Work_Key = " +
                                        "" + checkUpdateRecordNum + "";



                    //MessageBox.Show(queryText12);

                    //Sql command
                    SqlCommand cmd1 = new SqlCommand(queryText1, cn);
                    SqlCommand cmd2 = new SqlCommand(queryText2, cn);
                    SqlCommand cmd3 = new SqlCommand(queryText3, cn);
                    SqlCommand cmd4 = new SqlCommand(queryText4, cn);
                    SqlCommand cmd5 = new SqlCommand(queryText5, cn);
                    SqlCommand cmd6 = new SqlCommand(queryText6, cn);
                    SqlCommand cmd7 = new SqlCommand(queryText7, cn);
                    SqlCommand cmd8 = new SqlCommand(queryText8, cn);
                    SqlCommand cmd9 = new SqlCommand(queryText9, cn);
                    SqlCommand cmd10 = new SqlCommand(queryText10, cn);
                    SqlCommand cmd11 = new SqlCommand(queryText11, cn);


                    try
                    {
                        //Open connection to database
                        cn.Open();

                        //Variable to house data from the table
                        DateTime var_Red_Daily_Work_Record_Date;
                        string var_Red_Daily_Work_Name;
                        string var_Red_Daily_Work_Category;
                        decimal var_Red_Daily_Work_Time_Today;
                        long var_Red_Daily_Work_TFS_Number;
                        string var_Red_Daily_Work_Sprint;
                        string var_Red_Daily_Work_Type_Of_Ticket;
                        string var_Red_Daily_Work_Beginning_Of_Day_State;
                        string var_Red_Daily_Work_Ending_Of_Day_State;
                        int var_Red_Daily_Work_Business_Priority_For_Today;
                        string var_Red_Daily_Work_Notes;


                        //To set this variable inside a loop and use it outside of the loop
                        //     you need to set the variable before the loop.
                        var_Red_Daily_Work_Record_Date = Convert.ToDateTime("2017-01-01");
                        var_Red_Daily_Work_Name = "";
                        var_Red_Daily_Work_Category = "";
                        var_Red_Daily_Work_Time_Today = 0;
                        var_Red_Daily_Work_TFS_Number = 0;
                        var_Red_Daily_Work_Sprint = "";
                        var_Red_Daily_Work_Type_Of_Ticket = "";
                        var_Red_Daily_Work_Beginning_Of_Day_State = "";
                        var_Red_Daily_Work_Ending_Of_Day_State = "";
                        var_Red_Daily_Work_Business_Priority_For_Today = 0;
                        var_Red_Daily_Work_Notes = "";
                        

                        //Initialize a data reader
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            //MessageBox.Show(reader1["Red_Daily_Work_Record_Date"].ToString());

                            //Assign a variable
                            if (reader1.IsDBNull(reader1.GetOrdinal("Red_Daily_Work_Record_Date")))
                            {
                                var_Red_Daily_Work_Record_Date = Convert.ToDateTime("2017-01-01");
                            }
                            else
                            {
                                var_Red_Daily_Work_Record_Date = (DateTime)reader1["Red_Daily_Work_Record_Date"];
                            }

                            //MessageBox.Show(var_Red_Daily_Work_Record_Date.ToString());
                            //MessageBox.Show(var_Red_Daily_Work_Record_Date);
                        }
                        reader1.Close();

                        reader1 = cmd2.ExecuteReader();
                        while (reader1.Read())
                        {
                            //MessageBox.Show(reader["Red_Daily_Work_Name"].ToString());

                            //Assign a variable
                            if (reader1.IsDBNull(reader1.GetOrdinal("Red_Daily_Work_Name")))
                            {
                                var_Red_Daily_Work_Name = "";
                            }
                            else
                            {
                                var_Red_Daily_Work_Name = (string)reader1["Red_Daily_Work_Name"];
                            }
                        }
                        reader1.Close();

                        reader1 = cmd3.ExecuteReader();
                        while (reader1.Read())
                        {
                            //MessageBox.Show(reader["Red_Daily_Work_Category"].ToString());

                            //Assign a variable
                            if (reader1.IsDBNull(reader1.GetOrdinal("Red_Daily_Work_Category")))
                            {
                                var_Red_Daily_Work_Category = "";
                            }
                            else
                            {
                                var_Red_Daily_Work_Category = (string)reader1["Red_Daily_Work_Category"];
                            }

                            //MessageBox.Show(var_Red_Daily_Work_Category.ToString());
                        }
                        reader1.Close();

                        reader1 = cmd4.ExecuteReader();
                        while (reader1.Read())
                        {
                            //MessageBox.Show(reader1["Red_Daily_Work_Time_Today"].ToString());

                            //Assign a variable
                            if (reader1.IsDBNull(reader1.GetOrdinal("Red_Daily_Work_Time_Today")))
                            {
                                var_Red_Daily_Work_Time_Today = 0;
                            }
                            else
                            {
                                var_Red_Daily_Work_Time_Today = (decimal)reader1["Red_Daily_Work_Time_Today"];
                            }


                            //MessageBox.Show(var_Red_Daily_Work_Time_Today.ToString());
                        }
                        reader1.Close();

                        reader1 = cmd5.ExecuteReader();
                        while (reader1.Read())
                        {
                            //MessageBox.Show(reader["Red_Daily_Work_TFS_Number"].ToString());

                            //Assign a variable
                            if (reader1.IsDBNull(reader1.GetOrdinal("Red_Daily_Work_TFS_Number")))
                            {
                                var_Red_Daily_Work_TFS_Number = 0;
                            }
                            else
                            {
                                var_Red_Daily_Work_TFS_Number = (long)reader1["Red_Daily_Work_TFS_Number"];
                            }

                            //MessageBox.Show(var_Red_Daily_Work_TFS_Number);
                        }
                        reader1.Close();

                        reader1 = cmd6.ExecuteReader();
                        while (reader1.Read())
                        {
                            //MessageBox.Show(reader["Red_Daily_Work_Sprint"].ToString());

                            //Assign a variable
                            if (reader1.IsDBNull(reader1.GetOrdinal("Red_Daily_Work_Sprint")))
                            {
                                var_Red_Daily_Work_Sprint = "";
                            }
                            else
                            {
                                var_Red_Daily_Work_Sprint = (string)reader1["Red_Daily_Work_Sprint"];
                            }

                            //MessageBox.Show(var_Red_Daily_Work_Sprint);
                        }
                        reader1.Close();

                        reader1 = cmd7.ExecuteReader();
                        while (reader1.Read())
                        {
                            //MessageBox.Show(reader["Red_Daily_Work_Type_Of_Ticket"].ToString());

                            //Assign a variable
                            if (reader1.IsDBNull(reader1.GetOrdinal("Red_Daily_Work_Type_Of_Ticket")))
                            {
                                var_Red_Daily_Work_Type_Of_Ticket = "";
                            }
                            else
                            {
                                var_Red_Daily_Work_Type_Of_Ticket = (string)reader1["Red_Daily_Work_Type_Of_Ticket"];
                            }

                            //MessageBox.Show(var_Red_Daily_Work_Type_Of_Ticket);
                        }
                        reader1.Close();


                        reader1 = cmd8.ExecuteReader();
                        while (reader1.Read())
                        {
                            //MessageBox.Show(reader1["Red_Daily_Work_Beginning_Of_Day_State"].ToString());

                            //Assign a variable
                            if (reader1.IsDBNull(reader1.GetOrdinal("Red_Daily_Work_Beginning_Of_Day_State")))
                            {
                                var_Red_Daily_Work_Beginning_Of_Day_State = "";
                            }
                            else
                            {
                                var_Red_Daily_Work_Beginning_Of_Day_State = (string)reader1["Red_Daily_Work_Beginning_Of_Day_State"];
                            }

                            //MessageBox.Show(var_Red_Daily_Work_Beginning_Of_Day_State);
                        }
                        reader1.Close();

                        reader1 = cmd9.ExecuteReader();
                        while (reader1.Read())
                        {
                            //MessageBox.Show(reader["Red_Daily_Work_Ending_Of_Day_State"].ToString());

                            //Assign a variable
                            if (reader1.IsDBNull(reader1.GetOrdinal("Red_Daily_Work_Ending_Of_Day_State")))
                            {
                                var_Red_Daily_Work_Ending_Of_Day_State = "";
                            }
                            else
                            {
                                var_Red_Daily_Work_Ending_Of_Day_State = (string)reader1["Red_Daily_Work_Ending_Of_Day_State"];
                            }

                            //MessageBox.Show(var_Red_Daily_Work_Ending_Of_Day_State);
                        }
                        reader1.Close();

                        reader1 = cmd10.ExecuteReader();
                        while (reader1.Read())
                        {
                            //MessageBox.Show(reader["Red_Daily_Work_Business_Priority_For_Today"].ToString());

                            //Assign a variable
                            if (reader1.IsDBNull(reader1.GetOrdinal("Red_Daily_Work_Business_Priority_For_Today")))
                            {
                                var_Red_Daily_Work_Business_Priority_For_Today = 0;
                            }
                            else
                            {
                                var_Red_Daily_Work_Business_Priority_For_Today = (int)reader1["Red_Daily_Work_Business_Priority_For_Today"];
                            }
                        }
                        reader1.Close();

                        reader1 = cmd11.ExecuteReader();
                        while (reader1.Read())
                        {
                            //MessageBox.Show(reader["Red_Daily_Work_Notes"].ToString());

                            //Assign a variable
                            if (reader1.IsDBNull(reader1.GetOrdinal("Red_Daily_Work_Notes")))
                            {
                                var_Red_Daily_Work_Notes = "";
                            }
                            else
                            {
                                var_Red_Daily_Work_Notes = (string)reader1["Red_Daily_Work_Notes"];
                            }

                            //MessageBox.Show(var_Red_Daily_Work_Notes);
                        }
                        reader1.Close();


                        //Set the values pulled from the database
                        dateTimePicker1.Text = Convert.ToString(var_Red_Daily_Work_Record_Date);
                        comboBox1.Text = var_Red_Daily_Work_Name;
                        comboBox2.Text = var_Red_Daily_Work_Category;
                        textBox1.Text = Convert.ToString(var_Red_Daily_Work_Time_Today);
                        textBox2.Text = Convert.ToString(var_Red_Daily_Work_TFS_Number);
                        textBox3.Text = var_Red_Daily_Work_Sprint;
                        comboBox3.Text = var_Red_Daily_Work_Type_Of_Ticket;
                        comboBox4.Text = var_Red_Daily_Work_Beginning_Of_Day_State;
                        comboBox5.Text = var_Red_Daily_Work_Ending_Of_Day_State;
                        textBox4.Text = Convert.ToString(var_Red_Daily_Work_Business_Priority_For_Today);
                        richTextBox1.Text = var_Red_Daily_Work_Notes;

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        //Close connection to database
                        cn.Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //////////////////////////
            //  UPDATE
            /////////////////////////
            if (textBox5.Text != "")
            {
                //Record number to be updated
                int checkUpdateRecordNum;
                checkUpdateRecordNum = Convert.ToInt32(textBox5.Text);

                ////////////////////////
                // REPLACE SINGLE QUOTES
                ////////////////////////

                string str_Red_Daily_Work_Name;
                str_Red_Daily_Work_Name = comboBox1.Text;
                str_Red_Daily_Work_Name = str_Red_Daily_Work_Name.Replace("'", "\''");

                string str_Red_Daily_Work_Category;
                str_Red_Daily_Work_Category = comboBox2.Text;
                str_Red_Daily_Work_Category = str_Red_Daily_Work_Category.Replace("'", "\''");

                string str_Red_Daily_Work_Sprint;
                str_Red_Daily_Work_Sprint = textBox3.Text;
                str_Red_Daily_Work_Sprint = str_Red_Daily_Work_Sprint.Replace("'", "\''");

                string str_Red_Daily_Work_Type_Of_Ticket;
                str_Red_Daily_Work_Type_Of_Ticket = comboBox3.Text;
                str_Red_Daily_Work_Type_Of_Ticket = str_Red_Daily_Work_Type_Of_Ticket.Replace("'", "\''");

                string str_Red_Daily_Work_Beginning_Of_Day_State;
                str_Red_Daily_Work_Beginning_Of_Day_State = comboBox4.Text;
                str_Red_Daily_Work_Beginning_Of_Day_State = str_Red_Daily_Work_Beginning_Of_Day_State.Replace("'", "\''");

                string str_Red_Daily_Work_Ending_Of_Day_State;
                str_Red_Daily_Work_Ending_Of_Day_State = comboBox5.Text;
                str_Red_Daily_Work_Ending_Of_Day_State = str_Red_Daily_Work_Ending_Of_Day_State.Replace("'", "\''");

                string str_Red_Daily_Work_Notes;
                str_Red_Daily_Work_Notes = richTextBox1.Text;
                str_Red_Daily_Work_Notes = str_Red_Daily_Work_Notes.Replace("'", "\''");

                ////////////////////////////////////////////


                ////////////////////////
                // INT NULL VALUES
                ////////////////////////
                int intTfsNumber;
                intTfsNumber = 0;

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    intTfsNumber = 0;
                }
                else
                {
                    intTfsNumber = Convert.ToInt32(textBox2.Text);
                }

                int intPriorityNumber;
                intPriorityNumber = 0;

                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    intPriorityNumber = 0;
                }
                else
                {
                    intPriorityNumber = Convert.ToInt32(textBox4.Text);
                }

                decimal decTimeToday;
                decTimeToday = 0;

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    decTimeToday = 0;
                }
                else
                {
                    decTimeToday = Convert.ToDecimal(textBox1.Text);
                }

                ////////////////////////////////////////////

                /////////////////////////
                // Update DATE
                /////////////////////////

                DateTime dt_Update_Date;
                dt_Update_Date = DateTime.Now;

                ////////////////////////////////////////////

                cn.Open();
                cmd.Connection = cn;

                cmd.CommandText = "UPDATE Red.Red_Daily_Work " +
                    "SET Red_Daily_Work_Record_Date = " +
                            "'" + dateTimePicker1.Text + "' " +
                    ", Red_Daily_Work_Name = " +
                            "'" + str_Red_Daily_Work_Name + "' " +
                    ", Red_Daily_Work_Category = " +
                            "'" + str_Red_Daily_Work_Category + "' " +
                    ", Red_Daily_Work_Time_Today = " +
                            "" + decTimeToday + " " +
                    ", Red_Daily_Work_TFS_Number = " +
                            "" + intTfsNumber + " " +
                    ", Red_Daily_Work_Sprint = " +
                            "'" + str_Red_Daily_Work_Sprint + "' " +
                    ", Red_Daily_Work_Type_Of_Ticket = " +
                            "'" + str_Red_Daily_Work_Type_Of_Ticket + "' " +
                    ", Red_Daily_Work_Beginning_Of_Day_State = " +
                            "'" + str_Red_Daily_Work_Beginning_Of_Day_State + "' " +
                    ", Red_Daily_Work_Ending_Of_Day_State = " +
                            "'" + str_Red_Daily_Work_Ending_Of_Day_State + "' " +
                    ", Red_Daily_Work_Business_Priority_For_Today = " +
                            "" + intPriorityNumber + " " +
                    ", Red_Daily_Work_Notes = " +
                            "'" + str_Red_Daily_Work_Notes + "' " +
                    ", Red_Daily_Work_Update_Date = " +
                            "'" + dt_Update_Date + "' " +
                    "WHERE 1 = 1 " +
                    "AND Red_Daily_Work_Key = " +
                    "'" + textBox5.Text + "'";

                cmd.ExecuteNonQuery();

                //Insert into collection table (back up)
                cmd.CommandText = "INSERT INTO Red.Red_Daily_Work_bu " +
                    "(Red_Daily_Work_Record_Date" +
                    ", Red_Daily_Work_Name" +
                    ", Red_Daily_Work_Category" +
                    ", Red_Daily_Work_Time_Today" +
                    ", Red_Daily_Work_TFS_Number" +
                    ", Red_Daily_Work_Sprint" +
                    ", Red_Daily_Work_Type_Of_Ticket" +
                    ", Red_Daily_Work_Beginning_Of_Day_State" +
                    ", Red_Daily_Work_Ending_Of_Day_State" +
                    ", Red_Daily_Work_Business_Priority_For_Today" +
                    ", Red_Daily_Work_Notes" +
                    ", Red_Daily_Work_Update_Date" +
                    ") " +
                    "VALUES ('" + dateTimePicker1.Text + "'" +
                    ",'" + str_Red_Daily_Work_Name + "'" +
                    ",'" + str_Red_Daily_Work_Category + "'" +
                    "," + decTimeToday + "" +
                    "," + intTfsNumber + "" +
                    ",'" + str_Red_Daily_Work_Sprint + "'" +
                    ",'" + str_Red_Daily_Work_Type_Of_Ticket + "'" +
                    ",'" + str_Red_Daily_Work_Beginning_Of_Day_State + "'" +
                    ",'" + str_Red_Daily_Work_Ending_Of_Day_State + "'" +
                    "," + intPriorityNumber + "" +
                    ",'" + str_Red_Daily_Work_Notes + "'" +
                    ",'" + dt_Update_Date + "'" +
                    ")";
                //MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();

                //Close connection to database
                cn.Close();

                //Clear fields on the form
                dateTimePicker1.Text = string.Empty;
                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                comboBox3.Text = string.Empty;
                comboBox4.Text = string.Empty;
                comboBox5.Text = string.Empty;
                textBox4.Text = string.Empty;
                richTextBox1.Text = string.Empty;
                textBox5.Text = string.Empty;

                MessageBox.Show("Record updated!");
                /*Application.Exit();*/

                //////////////////////////////////////
                // REFRESH DATAGRID
                //////////////////////////////////////
                using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Red.Red_Daily_Work ORDER BY Red_Daily_Work_Key DESC", conn))
                    {
                        DataTable dt = new DataTable();
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }

                //////////////////////////////////////////////////

            }

            /////////////////////////////////////////
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //////////////////////////
            //  DELETE
            /////////////////////////
            if (textBox5.Text != "")
            {
                //Record number to be updated
                int checkDeleteRecordNum;
                checkDeleteRecordNum = Convert.ToInt32(textBox5.Text);

                cn.Open();
                cmd.Connection = cn;

                cmd.CommandText = "DELETE Red.Red_Daily_Work " +
                    "WHERE 1 = 1 " +
                    "AND Red_Daily_Work_Key = " +
                    "'" + checkDeleteRecordNum + "'";
                cmd.ExecuteNonQuery();

                cn.Close();

                textBox5.Text = string.Empty;

                MessageBox.Show("Record deleted!");

                //Clear fields on the form
                dateTimePicker1.Text = string.Empty;
                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                comboBox3.Text = string.Empty;
                comboBox4.Text = string.Empty;
                comboBox5.Text = string.Empty;
                textBox4.Text = string.Empty;
                richTextBox1.Text = string.Empty;
                textBox5.Text = string.Empty;
            }
            ////////////////////////////////////////////////////

            //////////////////////////////////////
            // REFRESH DATAGRID
            //////////////////////////////////////
            using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Red.Red_Daily_Work ORDER BY Red_Daily_Work_Key DESC", conn))
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }

            //////////////////////////////////////////////////
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Clear fields on the form
            dateTimePicker1.Text = string.Empty;
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox3.Text = string.Empty;
            comboBox4.Text = string.Empty;
            comboBox5.Text = string.Empty;
            textBox4.Text = string.Empty;
            richTextBox1.Text = string.Empty;
            textBox5.Text = string.Empty;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////
            // REFRESH DATAGRID
            //////////////////////////////////////
            using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SELECT A.Category " +
                                                                    ", A.Monday " +
                                                                    ", A.Tuesday " +
                                                                    ", A.Wednesday " +
                                                                    ", A.Thursday " +
                                                                    ", A.Friday " +
                                                                    ", A.SubTotal " +
                                                                    "FROM " +
                                                                        "(SELECT A.Category " +
                                                                            ", A.Monday " +
                                                                            ", A.Tuesday " +
                                                                            ", A.Wednesday " +
                                                                            ", A.Thursday " +
                                                                            ", A.Friday " +
                                                                            ", A.SubTotal " +
                                                                            ", 1 AS Row_Order " +
                                                                            "FROM " +
                                                                                "(SELECT A.Red_Daily_Work_Category AS Category " +
                                                                                    ", Monday.Time_Today_Monday AS Monday " +
                                                                                    ", Tuesday.Time_Today_Tuesday AS Tuesday " +
                                                                                    ", Wednesday.Time_Today_Wednesday AS Wednesday " +
                                                                                    ", Thursday.Time_Today_Thursday AS Thursday " +
                                                                                    ", Friday.Time_Today_Friday AS Friday " +
                                                                                    ", A.Time_Today_SubTotal AS SubTotal " +
                                                                                    "FROM " +
                                                                                        "(SELECT Red_Daily_Work_Category " +
                                                                                            ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_SubTotal " +
                                                                                            "FROM Red.Red_Daily_Work " +
                                                                                            "WHERE 1 = 1 " +
                                                                                                "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                    "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                "AND Red_Daily_Work_Category NOT LIKE 'WT%' " +
                                                                                            "GROUP BY Red_Daily_Work_Category " +
                                                                                        ") A " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Monday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Monday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category NOT LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Monday ON A.Red_Daily_Work_Category = Monday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                               " , SUM(Red_Daily_Work_Time_Today) AS Time_Today_Tuesday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Tuesday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category NOT LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Tuesday ON A.Red_Daily_Work_Category = Tuesday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Wednesday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Wednesday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category NOT LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Wednesday ON A.Red_Daily_Work_Category = Wednesday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Thursday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Thursday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category NOT LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Thursday ON A.Red_Daily_Work_Category = Thursday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Friday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Friday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category NOT LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Friday ON A.Red_Daily_Work_Category = Friday.Red_Daily_Work_Category " +
                                                                                ") A " +
                                                                        "UNION " +
                                                                        "SELECT A.Category " +
                                                                            ", A.Monday " +
                                                                            ", A.Tuesday " +
                                                                            ", A.Wednesday " +
                                                                            ", A.Thursday " +
                                                                            ", A.Friday " +
                                                                            ", A.SubTotal " +
                                                                            ", 2 AS Row_Order " +
                                                                            "FROM " +
                                                                                "(SELECT '                 Total Worked:' AS Category " +
                                                                                    ", SUM(Monday.Time_Today_Monday) AS Monday " +
                                                                                    ", SUM(Tuesday.Time_Today_Tuesday) AS Tuesday " +
                                                                                    ", SUM(Wednesday.Time_Today_Wednesday) AS Wednesday " +
                                                                                    ", SUM(Thursday.Time_Today_Thursday) AS Thursday " +
                                                                                    ", SUM(Friday.Time_Today_Friday) AS Friday " +
                                                                                    ", SUM(A.Time_Today_SubTotal) AS SubTotal " +
                                                                                    "FROM " +
                                                                                        "(SELECT Red_Daily_Work_Category " +
                                                                                            ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_SubTotal " +
                                                                                            "FROM Red.Red_Daily_Work " +
                                                                                            "WHERE 1 = 1 " +
                                                                                                "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                    "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                "AND Red_Daily_Work_Category NOT LIKE 'WT%' " +
                                                                                            "GROUP BY Red_Daily_Work_Category " +
                                                                                        ") A " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Monday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Monday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category NOT LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Monday ON A.Red_Daily_Work_Category = Monday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Tuesday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Tuesday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category NOT LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Tuesday ON A.Red_Daily_Work_Category = Tuesday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Wednesday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Wednesday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category NOT LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Wednesday ON A.Red_Daily_Work_Category = Wednesday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Thursday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Thursday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category NOT LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Thursday ON A.Red_Daily_Work_Category = Thursday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Friday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Friday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category NOT LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Friday ON A.Red_Daily_Work_Category = Friday.Red_Daily_Work_Category " +
                                                                                ") A " +
                                                                        "UNION " +
                                                                        "SELECT NULL AS Category " +
                                                                            ", NULL AS Monday " +
                                                                            ", NULL AS Tuesday " +
                                                                            ", NULL AS Wednesday " +
                                                                            ", NULL AS Thursday " +
                                                                            ", NULL AS Friday " +
                                                                            ", NULL AS SubTotal " +
                                                                            ", 3 AS Row_Order " +
                                                                        "UNION " +
                                                                        "SELECT A.Category " +
                                                                            ", A.Monday " +
                                                                            ", A.Tuesday " +
                                                                            ", A.Wednesday " +
                                                                            ", A.Thursday " +
                                                                            ", A.Friday " +
                                                                            ", A.SubTotal " +
                                                                            ", 4 AS Row_Order " +
                                                                            "FROM " +
                                                                                "(SELECT A.Red_Daily_Work_Category AS Category " +
                                                                                    ", Monday.Time_Today_Monday AS Monday " +
                                                                                    ", Tuesday.Time_Today_Tuesday AS Tuesday " +
                                                                                    ", Wednesday.Time_Today_Wednesday AS Wednesday " +
                                                                                    ", Thursday.Time_Today_Thursday AS Thursday " +
                                                                                    ", Friday.Time_Today_Friday AS Friday " +
                                                                                    ", A.Time_Today_SubTotal AS SubTotal " +
                                                                                    "FROM " +
                                                                                        "(SELECT Red_Daily_Work_Category " +
                                                                                            ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_SubTotal " +
                                                                                            "FROM Red.Red_Daily_Work " +
                                                                                            "WHERE 1 = 1 " +
                                                                                                "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                    "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                "AND Red_Daily_Work_Category LIKE 'WT%' " +
                                                                                            "GROUP BY Red_Daily_Work_Category " +
                                                                                        ") A " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Monday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Monday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Monday ON A.Red_Daily_Work_Category = Monday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Tuesday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Tuesday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Tuesday ON A.Red_Daily_Work_Category = Tuesday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Wednesday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Wednesday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Wednesday ON A.Red_Daily_Work_Category = Wednesday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Thursday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Thursday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Thursday ON A.Red_Daily_Work_Category = Thursday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Friday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Friday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Friday ON A.Red_Daily_Work_Category = Friday.Red_Daily_Work_Category " +
                                                                                ") A " +
                                                                        "UNION " +
                                                                        "SELECT A.Category " +
                                                                            ", A.Monday " +
                                                                            ", A.Tuesday " +
                                                                            ", A.Wednesday " +
                                                                            ", A.Thursday " +
                                                                            ", A.Friday " +
                                                                            ", A.SubTotal " +
                                                                            ", 5 AS Row_Order " +
                                                                            "FROM " +
                                                                                "(SELECT '                 Total Wait:' AS Category " +
                                                                                    ", SUM(Monday.Time_Today_Monday) AS Monday " +
                                                                                    ", SUM(Tuesday.Time_Today_Tuesday) AS Tuesday " +
                                                                                    ", SUM(Wednesday.Time_Today_Wednesday) AS Wednesday " +
                                                                                    ", SUM(Thursday.Time_Today_Thursday) AS Thursday " +
                                                                                    ", SUM(Friday.Time_Today_Friday) AS Friday " +
                                                                                    ", SUM(A.Time_Today_SubTotal) AS SubTotal " +
                                                                                    "FROM " +
                                                                                        "(SELECT Red_Daily_Work_Category " +
                                                                                            ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_SubTotal " +
                                                                                            "FROM Red.Red_Daily_Work " +
                                                                                            "WHERE 1 = 1 " +
                                                                                                "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                    "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                "AND Red_Daily_Work_Category LIKE 'WT%' " +
                                                                                            "GROUP BY Red_Daily_Work_Category " +
                                                                                        ") A " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Monday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Monday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Monday ON A.Red_Daily_Work_Category = Monday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Tuesday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Tuesday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Tuesday ON A.Red_Daily_Work_Category = Tuesday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Wednesday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Wednesday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Wednesday ON A.Red_Daily_Work_Category = Wednesday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Thursday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Thursday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Thursday ON A.Red_Daily_Work_Category = Thursday.Red_Daily_Work_Category " +
                                                                                        "LEFT JOIN " +
                                                                                            "(SELECT Red_Daily_Work_Category " +
                                                                                                ", SUM(Red_Daily_Work_Time_Today) AS Time_Today_Friday " +
                                                                                                "FROM Red.Red_Daily_Work " +
                                                                                                "WHERE 1 = 1 " +
                                                                                                    "AND DATENAME(DW, Red_Daily_Work_Record_Date) = 'Friday' " +
                                                                                                    "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                                                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                                                    "AND Red_Daily_Work_Category LIKE 'WT%' " +
                                                                                                "GROUP BY Red_Daily_Work_Category " +
                                                                                            ") Friday ON A.Red_Daily_Work_Category = Friday.Red_Daily_Work_Category " +
                                                                                ") A " +
                                                                        ") A " +
                                                                "ORDER BY Row_Order, SubTotal DESC ;" +
                                                                "DROP TABLE IF EXISTS Red.Red_Chart_Time_Totals; " +
                                                                "CREATE TABLE Red.Red_Chart_Time_Totals( " +
                                                                    "Categories NVARCHAR(100) " +
                                                                    ", Time_Totals DECIMAL(10, 2) " +
                                                                ") " +
                                                                "INSERT INTO Red.Red_Chart_Time_Totals( " +
                                                                    "Categories " +
                                                                    ", Time_Totals " +
                                                                ") " +
                                                                "SELECT Red_Daily_Work_Category AS Categories " +
                                                                    ", SUM(Red_Daily_Work_Time_Today) AS Time_Totals " +
                                                                    "FROM Red.Red_Daily_Work " +
                                                                    "WHERE 1 = 1 " +
                                                                        "AND CONVERT(DATE, Red_Daily_Work_Record_Date, 101) BETWEEN DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1) " +
                                                                        "AND DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), -1 + 6) " +
                                                                        "AND Red_Daily_Work_Category NOT LIKE 'WT%' " +
                                                                    "GROUP BY Red_Daily_Work_Category "
                                                                , conn
                                                             )
                      )
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
            }

            //////////////////////////////////////////////////
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////
            // REFRESH DATAGRID
            //////////////////////////////////////
            using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SELECT Red_Daily_Work_Key AS ID " +
                                                                    ", Red_Daily_Work_Record_Date AS Record_Date " +
                                                                    ", Red_Daily_Work_Name AS Name " +
                                                                    ", Red_Daily_Work_TFS_Number AS TFS_Number " +
                                                                    ", Red_Daily_Work_Category AS Category " +
                                                                    ", Red_Daily_Work_Time_Today AS Time " +
                                                                    ", Red_Daily_Work_Notes AS Notes " +
                                                                    "FROM Red.Red_Daily_Work " +
                                                                    "WHERE 1 = 1 " +
                                                                         "AND CONVERT(DATE, Red_Daily_Work_Record_Date,101) = '" + dateTimePicker2.Text + "' " +
                                                                    "ORDER BY Red_Daily_Work_Key DESC"
                                                                    , conn
                                                             )
                      )
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView3.DataSource = dt;
                }
            }

            //////////////////////////////////////////////////
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////
            // REFRESH DATAGRID
            //////////////////////////////////////
            using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SELECT Red_Daily_Work_Key AS ID " +
                                                                    ", Red_Daily_Work_Record_Date AS Record_Date " +
                                                                    ", Red_Daily_Work_Name AS Name " +
                                                                    ", Red_Daily_Work_TFS_Number AS TFS_Number " +
                                                                    ", Red_Daily_Work_Category AS Category " +
                                                                    ", Red_Daily_Work_Time_Today AS Time " +
                                                                    ", Red_Daily_Work_Notes AS Notes " +
                                                                    "FROM Red.Red_Daily_Work " +
                                                                    "WHERE 1 = 1 " +
                                                                         "AND Red_Daily_Work_Name LIKE '%" + textBox6.Text + "%' " +
                                                                    "ORDER BY Red_Daily_Work_Key DESC"
                                                                    , conn
                                                             )
                      )
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView3.DataSource = dt;
                }
            }

            //////////////////////////////////////////////////
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////
            // REFRESH DATAGRID
            //////////////////////////////////////
            using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SELECT Red_Daily_Work_Key AS ID " +
                                                                    ", Red_Daily_Work_Record_Date AS Record_Date " +
                                                                    ", Red_Daily_Work_Name AS Name " +
                                                                    ", Red_Daily_Work_TFS_Number AS TFS_Number " +
                                                                    ", Red_Daily_Work_Category AS Category " +
                                                                    ", Red_Daily_Work_Time_Today AS Time " +
                                                                    ", Red_Daily_Work_Notes AS Notes " +
                                                                    "FROM Red.Red_Daily_Work " +
                                                                    "WHERE 1 = 1 " +
                                                                         "AND Red_Daily_Work_TFS_Number = " + Convert.ToInt32(textBox7.Text) + " " +
                                                                    "ORDER BY Red_Daily_Work_Key DESC"
                                                                    , conn
                                                             )
                      )
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView3.DataSource = dt;
                }
            }

            //////////////////////////////////////////////////
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////
            // REFRESH DATAGRID
            //////////////////////////////////////
            using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SELECT Red_Daily_Work_Key AS ID " +
                                                                    ", Red_Daily_Work_Record_Date AS Record_Date " +
                                                                    ", Red_Daily_Work_Name AS Name " +
                                                                    ", Red_Daily_Work_TFS_Number AS TFS_Number " +
                                                                    ", Red_Daily_Work_Category AS Category " +
                                                                    ", Red_Daily_Work_Time_Today AS Time " +
                                                                    ", Red_Daily_Work_Notes AS Notes " +
                                                                    "FROM Red.Red_Daily_Work " +
                                                                    "WHERE 1 = 1 " +
                                                                         "AND Red_Daily_Work_Category LIKE '%" + comboBox6.Text + "%' " +
                                                                    "ORDER BY Red_Daily_Work_Key DESC"
                                                                    , conn
                                                             )
                      )
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView3.DataSource = dt;
                }
            }

            //////////////////////////////////////////////////
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////
            // REFRESH DATAGRID
            //////////////////////////////////////
            using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SELECT Red_Daily_Work_Key AS ID " +
                                                                    ", Red_Daily_Work_Record_Date AS Record_Date " +
                                                                    ", Red_Daily_Work_Name AS Name " +
                                                                    ", Red_Daily_Work_TFS_Number AS TFS_Number " +
                                                                    ", Red_Daily_Work_Category AS Category " +
                                                                    ", Red_Daily_Work_Time_Today AS Time " +
                                                                    ", Red_Daily_Work_Notes AS Notes " +
                                                                    "FROM Red.Red_Daily_Work " +
                                                                    "WHERE 1 = 1 " +
                                                                         "AND Red_Daily_Work_Notes LIKE '%" + textBox8.Text + "%' " +
                                                                    "ORDER BY Red_Daily_Work_Key DESC"
                                                                    , conn
                                                             )
                      )
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView3.DataSource = dt;
                }
            }

            //////////////////////////////////////////////////
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oneAccord_WarehouseDataSet3.Red_Etl_Integrity_Check' table. You can move, or remove it, as needed.
            this.red_Etl_Integrity_CheckTableAdapter.Fill(this.oneAccord_WarehouseDataSet3.Red_Etl_Integrity_Check);
            // TODO: This line of code loads data into the 'oneAccord_WarehouseDataSet2.Red_Etl_Transform_Month_Avg' table. You can move, or remove it, as needed.
            this.red_Etl_Transform_Month_AvgTableAdapter.Fill(this.oneAccord_WarehouseDataSet2.Red_Etl_Transform_Month_Avg);
            // TODO: This line of code loads data into the 'oneAccord_WarehouseDataSet1.Red_Etl_Extract_Month_Avg' table. You can move, or remove it, as needed.
            this.red_Etl_Extract_Month_AvgTableAdapter.Fill(this.oneAccord_WarehouseDataSet1.Red_Etl_Extract_Month_Avg);
            // TODO: This line of code loads data into the 'oneAccord_WarehouseDataSet.Red_Chart_Time_Totals' table. You can move, or remove it, as needed.
            this.red_Chart_Time_TotalsTableAdapter.Fill(this.oneAccord_WarehouseDataSet.Red_Chart_Time_Totals);

        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            // Variable to check if record can be updated
            int RecordUpdateYn;
            //To set this variable inside a loop and use it outside of the loop
            //     you need to set the variable before the loop.
            RecordUpdateYn = 0;

            if (textBox9.Text != "")
            {
                //  Verify that the record exist to be UPDATED

                //Record number to be updated
                int checkUpdateRecordNum;
                checkUpdateRecordNum = Convert.ToInt32(textBox9.Text);

                //Query to pull data from the database
                string queryRecordUpdateYn;
                queryRecordUpdateYn = "SELECT COUNT(Red_Daily_Work_Key) AS Cnt " +
                                        "FROM Red.Red_Daily_Work " +
                                        "WHERE 1 = 1 " +
                                            "AND Red_Daily_Work_Key = " +
                                            "" + checkUpdateRecordNum + "";

                //Sql command
                SqlCommand cmdCheck = new SqlCommand(queryRecordUpdateYn, cn);

                try
                {
                    //Open connection to database
                    cn.Open();

                    //Initialize a data reader
                    SqlDataReader reader1 = cmdCheck.ExecuteReader();
                    while (reader1.Read())
                    {
                        //MessageBox.Show(reader["Cnt"].ToString());

                        //Assign a variable
                        if (reader1.IsDBNull(reader1.GetOrdinal("Cnt")))
                        {
                            RecordUpdateYn = 0;
                        }
                        else
                        {
                            RecordUpdateYn = (int)reader1["Cnt"];
                        }

                        //MessageBox.Show(RecordUpdateYn.ToString());
                    }
                    reader1.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //Close connection to database
                    cn.Close();
                }

                //MessageBox.Show(RecordUpdateYn.ToString());
                if (RecordUpdateYn == 1)
                {
                    //Clear fields on the form
                    richTextBox2.Text = string.Empty;
                    //textBox5.Text = string.Empty;


                    string queryText1;


                    //Query to pull data from the database
                    queryText1 = "SELECT Red_Daily_Work_Notes  " +
                                    "FROM Red.Red_Daily_Work " +
                                    "WHERE 1 = 1 " +
                                        "AND Red_Daily_Work_Key = " +
                                        "" + checkUpdateRecordNum + "";

                    //MessageBox.Show(queryText12);

                    //Sql command
                    SqlCommand cmd1 = new SqlCommand(queryText1, cn);

                    try
                    {
                        //Open connection to database
                        cn.Open();

                        //Variable to house data from the table
                        string var_Red_Daily_Work_Notes;


                        //To set this variable inside a loop and use it outside of the loop
                        //     you need to set the variable before the loop.
                        var_Red_Daily_Work_Notes = "";


                        //Initialize a data reader
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            //MessageBox.Show(reader["Red_Daily_Work_Notes"].ToString());

                            //Assign a variable
                            if (reader1.IsDBNull(reader1.GetOrdinal("Red_Daily_Work_Notes")))
                            {
                                var_Red_Daily_Work_Notes = "";
                            }
                            else
                            {
                                var_Red_Daily_Work_Notes = (string)reader1["Red_Daily_Work_Notes"];
                            }

                            //MessageBox.Show(var_Red_Daily_Work_Notes);
                        }
                        reader1.Close();


                        //Set the values pulled from the database
                        richTextBox2.Text = var_Red_Daily_Work_Notes;

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        //Close connection to database
                        cn.Close();
                    }
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //////////////////////////
            //  UPDATE
            /////////////////////////
            if (textBox9.Text != "")
            {
                //Record number to be updated
                int checkUpdateRecordNum;
                checkUpdateRecordNum = Convert.ToInt32(textBox9.Text);

                ////////////////////////
                // REPLACE SINGLE QUOTES
                ////////////////////////

                string str_Red_Daily_Work_Notes;
                str_Red_Daily_Work_Notes = richTextBox2.Text;
                str_Red_Daily_Work_Notes = str_Red_Daily_Work_Notes.Replace("'", "\''");

                ////////////////////////////////////////////


                /////////////////////////
                // Update DATE
                /////////////////////////

                DateTime dt_Update_Date;
                dt_Update_Date = DateTime.Now;

                ////////////////////////////////////////////

                cn.Open();
                cmd.Connection = cn;

                cmd.CommandText = "UPDATE Red.Red_Daily_Work " +
                    "SET Red_Daily_Work_Notes = " +
                            "'" + str_Red_Daily_Work_Notes + "' " +
                    ", Red_Daily_Work_Update_Date = " +
                            "'" + dt_Update_Date + "' " +
                    "WHERE 1 = 1 " +
                    "AND Red_Daily_Work_Key = " +
                    "'" + textBox9.Text + "'";

                cmd.ExecuteNonQuery();

                //Insert into collection table (back up)
                cmd.CommandText = "INSERT INTO Red.Red_Daily_Work_bu " +
                    "(Red_Daily_Work_Notes" +
                    ", Red_Daily_Work_Update_Date" +
                    ") " +
                    "VALUES ('" + str_Red_Daily_Work_Notes + "'" +
                    ",'" + dt_Update_Date + "'" +
                    ")";
                //MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();

                //Close connection to database
                cn.Close();

                //Clear fields on the form
                richTextBox2.Text = string.Empty;
                textBox9.Text = string.Empty;

                MessageBox.Show("Record updated!");
                /*Application.Exit();*/

                //////////////////////////////////////
                // REFRESH DATAGRID
                //////////////////////////////////////
                using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Red.Red_Daily_Work ORDER BY Red_Daily_Work_Key DESC", conn))
                    {
                        DataTable dt = new DataTable();
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }

                //////////////////////////////////////////////////

            }

            /////////////////////////////////////////
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Clear fields on the form
            richTextBox2.Text = string.Empty;
            textBox9.Text = string.Empty;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////
            // REFRESH DATAGRID
            //////////////////////////////////////
            using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("DROP TABLE IF EXISTS Red.Red_Etl_Last_Run; " +
                                                                "CREATE TABLE Red.Red_Etl_Last_Run( " +
                                                                    "Etl_Stage NVARCHAR(50) " +
                                                                    ", Run_Date DATE " +
                                                                    ", Run_End_Time TIME " +
                                                                    ", Run_Time INT " +
                                                                    ", Error_Cnt INT " +
                                                                    ", Order_Num INT " +
                                                                ") " +
                                                                "INSERT INTO Red.Red_Etl_Last_Run( " +
                                                                    "Etl_Stage " +
                                                                    ", Run_Date " +
                                                                    ", Run_End_Time " +
                                                                    ", Run_Time " +
                                                                    ", Error_Cnt " +
                                                                    ", Order_Num " +
                                                                ") " +
                                                                "SELECT DISTINCT 'Extract' AS Etl_Stage " +
                                                                    ", CONVERT(DATE, A.Alpha_DateTime, 101) AS Run_Date " +
                                                                    ", B.Run_End_Time " +
                                                                    ", C.Run_Time " +
                                                                    ", D.Error_Cnt " +
                                                                    ", 1 AS Order_Num " +
                                                                    "FROM OneAccord_Warehouse.dbo.Alpha_Table_1 A, " +
                                                                        "(SELECT MAX(CONVERT(TIME(0), Alpha_DateTime)) AS Run_End_Time " +
                                                                            "FROM OneAccord_Warehouse.dbo.Alpha_Table_1 " +
                                                                        ") B , " +
                                                                        "(SELECT DATEDIFF(MINUTE, A.Begin_Time, A.End_Time) AS Run_Time " +
                                                                            "FROM " +
                                                                                "(SELECT MIN(Alpha_DateTime) AS Begin_Time " +
                                                                                    ", MAX(Alpha_DateTime) AS End_Time " +
                                                                                    "FROM Alpha_Table_1 " +
                                                                                ") A " +
                                                                        ") C , " +
                                                                        "(SELECT COUNT(Alpha_Result) AS Error_Cnt " +
                                                                            "FROM OneAccord_Warehouse.dbo.Alpha_Table_1 " +
                                                                            "WHERE Alpha_Result = '0' " +
                                                                        ") D " +
                                                                "UNION " +
                                                                "SELECT DISTINCT 'Transform' AS Etl_Stage " +
                                                                    ", CONVERT(DATE, A.Alpha_DateTime, 101) AS Run_Date " +
                                                                    ", B.Run_End_Time " +
                                                                    ", C.Run_Time " +
                                                                    ", D.Error_Cnt " +
                                                                    ", 2 AS Order_Num " +
                                                                    "FROM OneAccord_Warehouse.dbo.Alpha_Table_2 A, " +
                                                                        "(SELECT MAX(CONVERT(TIME(0), Alpha_DateTime)) AS Run_End_Time " +
                                                                            "FROM OneAccord_Warehouse.dbo.Alpha_Table_2 " +
                                                                        ") B , " +
                                                                        "(SELECT DATEDIFF(MINUTE, A.Begin_Time, B.End_Time) AS Run_Time " +
                                                                            "FROM " +
                                                                                "(SELECT MIN(Alpha_DateTime) AS Begin_Time " +
                                                                                    "FROM Alpha_Table_2 " +
                                                                                    "WHERE 1 = 1 " +
                                                                                        "AND Alpha_Stage = '_Picklist' " +
                                                                                ") A ," +
                                                                                "(SELECT MAX(Alpha_DateTime) AS End_Time " +
                                                                                    "FROM Alpha_Table_2 " +
                                                                                ") B " +
                                                                        ") C , " +
                                                                        "(SELECT COUNT(Alpha_Result) AS Error_Cnt " +
                                                                            "FROM OneAccord_Warehouse.dbo.Alpha_Table_2 " +
                                                                            "WHERE Alpha_Result = '0' " +
                                                                        ") D " +
                                                                "UNION " +
                                                                "SELECT DISTINCT 'Load' AS Etl_Stage " +
                                                                    ", CONVERT(DATE, A.Alpha_DateTime, 101) AS Run_Date " +
                                                                    ", B.Run_End_Time " +
                                                                    ", C.Run_Time " +
                                                                    ", D.Error_Cnt " +
                                                                    ", 3 AS Order_Num " +
                                                                    "FROM [MSSQL12335\\S01].OneAccord_Warehouse.dbo.Alpha_Table_3 A , " +
                                                                        "(SELECT MAX(CONVERT(TIME(0), Alpha_DateTime)) AS Run_End_Time " +
                                                                            "FROM [MSSQL12335\\S01].OneAccord_Warehouse.dbo.Alpha_Table_3 " +
                                                                        ") B , " +
                                                                        "(SELECT DATEDIFF(MINUTE,A.Begin_Time,B.End_Time) AS Run_Time " +
                                                                            "FROM " +
                                                                                "(SELECT MIN(Alpha_DateTime) AS Begin_Time " +
                                                                                    "FROM[MSSQL12335\\S01].OneAccord_Warehouse.dbo.Alpha_Table_3 " +
                                                                                    "WHERE 1 = 1 " +
                                                                                        "AND Alpha_Stage = '_Affiliated_Dim' " +
                                                                                ") A, " +
                                                                                "(SELECT MAX(Alpha_DateTime) AS End_Time " +
                                                                                    "FROM[MSSQL12335\\S01].OneAccord_Warehouse.dbo.Alpha_Table_3 " +
                                                                                ") B " +
                                                                        ") C , " +
                                                                        "(SELECT COUNT(Alpha_Result) AS Error_Cnt " +
                                                                            "FROM [MSSQL12335\\S01].OneAccord_Warehouse.dbo.Alpha_Table_3 " +
                                                                            "WHERE Alpha_Result = '0' " +
                                                                        ") D " +
                                                                    "ORDER BY Order_Num; " +
                                                                "DROP TABLE IF EXISTS Red.Red_Etl_Integrity_Check; " +
                                                                "CREATE TABLE Red.Red_Etl_Integrity_Check( " +
                                                                    "Check_Name NVARCHAR(100) " +
                                                                    ", Error_Cnt INT " +
                                                                "); " +
                                                                "INSERT INTO Red.Red_Etl_Integrity_Check( " +
                                                                    "Check_Name " +
                                                                    ", Error_Cnt " +
                                                                ") " +
                                                                "SELECT 'New_EmailBase - Orphans' AS Check_Name " +
                                                                    ", COUNT(*) AS Error_Cnt " +
                                                                    "FROM Check_New_EmailBase_Orphans " +
                                                                "UNION " +
                                                                "SELECT 'New_AddressBase - New_Confidential' AS Check_Name " +
                                                                    ", COUNT(*) AS Error_Cnt " +
                                                                    "FROM Check_New_AddressBase_New_Confidential " +
                                                                "UNION " +
                                                                "SELECT 'New_AddressBase - Orphans' AS Check_Name " +
                                                                    ", COUNT(*) AS Error_Cnt " +
                                                                    "FROM Check_New_AddressBase_Orphans " +
                                                                "UNION " +
                                                                "SELECT 'New_PhoneBase - Orphans' AS Check_Name " +
                                                                    ", COUNT(*) AS Error_Cnt " +
                                                                    "FROM Check_New_PhoneBase_Orphans " +
                                                                "UNION " +
                                                                "SELECT 'New_StudentAttendanceBase - Orphans' AS Check_Name " +
                                                                    ", COUNT(*) AS Error_Cnt " +
                                                                    "FROM Check_New_StudentAttendanceBase_Orphans " +
                                                                "UNION " +
                                                                "SELECT 'New_PhoneBase - Invalid Phones' AS Check_Name " +
                                                                    ", COUNT(*) AS Error_Cnt " +
                                                                    "FROM Check_New_PhoneBase_Invalid_Phones " +
                                                                "UNION " +
                                                                "SELECT 'New_EmailBase - Invalid Emails' AS Check_Name " +
                                                                    ", COUNT(*) AS Error_Cnt " +
                                                                    "FROM Check_New_EmailBase_Invalid_Emails " +
                                                                "UNION " +
                                                                "SELECT 'Plus_AlumniBase - Plus_Constituent' AS Check_Name " +
                                                                    ", COUNT(*) AS Error_Cnt " +
                                                                    "FROM Check_Plus_AlumniBase_Plus_Constituent " +
                                                                "UNION " +
                                                                "SELECT 'New_StudentAttendanceBase - New_Term' AS Check_Name " +
                                                                    ", COUNT(*) AS Error_Cnt " +
                                                                    "FROM Check_New_StudentAttendanceBase_New_Term " +
                                                                "UNION " +
                                                                "SELECT 'AccountBase - AccountId' AS Check_Name " +
                                                                    ", COUNT(*) AS Error_Cnt " +
                                                                    "FROM Check_AccountBase_AccountId " +
                                                                "UNION " +
                                                                "SELECT 'AccountBase - New_LdspId' AS Check_Name " +
                                                                    ", COUNT(*) AS Error_Cnt " +
                                                                    "FROM Check_AccountBase_New_LdspId " +
                                                                "UNION " +
                                                                "SELECT 'New_StudentAttendanceBase - Plus_Year' AS Check_Name " +
                                                                    ", COUNT(*) AS Error_Cnt " +
                                                                    "FROM Check_New_StudentAttendanceBase_Plus_Year " +
                                                                "SELECT Etl_Stage " +
                                                                        ", Run_Date " +
                                                                        ", Run_End_Time " +
                                                                        ", Run_Time " +
                                                                        ", Error_Cnt " +
                                                                        "FROM Red.Red_Etl_Last_Run " +
                                                                        "ORDER BY Order_Num "
                                                                , conn
                                                             )
                      )
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView4.DataSource = dt;
                }
            }

            //////////////////////////////////////////////////
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////
            // REFRESH DATAGRID
            //////////////////////////////////////
            using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("DROP TABLE IF EXISTS #Red_Etl_Extract_Month_Avg; " +
                                                                "CREATE TABLE #Red_Etl_Extract_Month_Avg (  " +
                                                                    "Extract_Month NVARCHAR(7) " +
                                                                    ", Extract_Run_Avg INT " +
                                                                    ", Row_Num INT " +
                                                                ") " +
                                                                "INSERT INTO #Red_Etl_Extract_Month_Avg (  " +
                                                                    "Extract_Month " +
                                                                    ", Extract_Run_Avg " +
                                                                    ", Row_Num " +
                                                                ") " +
                                                                "SELECT A.Extract_Month " +
                                                                    ", A.Extract_Run_Avg " +
                                                                    ", A.Row_Num " +
                                                                    "FROM " +
                                                                        "(SELECT CONCAT(A.Extract_Year, '-', Extract_Month) AS Extract_Month " +
                                                                            ", CASE WHEN A.Run_Days_Counted > 0 THEN A.Run_Time_Summed / A.Run_Days_Counted ELSE 0 END AS Extract_Run_Avg " +
                                                                            ", ROW_NUMBER() OVER(ORDER BY CONCAT(A.Extract_Year, '-', Extract_Month) DESC) AS Row_Num " +
                                                                            "FROM " +
                                                                                "(SELECT CONVERT(NVARCHAR(4), A.Extract_Date) AS Extract_Year " +
                                                                                    ", CASE WHEN MONTH(A.Extract_Date) = 1 THEN CONCAT('0', CONVERT(NVARCHAR(2), MONTH(A.Extract_Date))) " +
                                                                                            "WHEN LEFT(MONTH(A.Extract_Date), 1) = 1 THEN CONVERT(NVARCHAR(2), MONTH(A.Extract_Date)) " +
                                                                                            "ELSE CONCAT('0', CONVERT(NVARCHAR(2), MONTH(A.Extract_Date))) END AS Extract_Month " +
                                                                                    ", SUM(A.Run_Time) AS Run_Time_Summed " +
                                                                                    ", COUNT(CASE WHEN Run_Time IS NOT NULL THEN 1 ELSE NULL END) AS Run_Days_Counted " +
                                                                                    "FROM " +
                                                                                        "( " +
                                                                                        "SELECT A.Extract_Date " +
                                                                                            ", CASE WHEN A.Run_Time > 100 THEN NULL " +
                                                                                                "ELSE A.Run_Time END AS Run_Time " +
                                                                                            "FROM " +
                                                                                                "(SELECT A.Extract_Date " +
                                                                                                    ", CASE WHEN B.Extract_DateTime IS NOT NULL THEN DATEDIFF(MINUTE, A.Extract_DateTime, B.Extract_DateTime) " +
                                                                                                        "ELSE NULL END AS Run_Time " +
                                                                                                    "FROM " +
                                                                                                        "(SELECT 'Beginning of the run' AS Beginning " +
                                                                                                            ", B.Extract_Date " +
                                                                                                            ", A.Extract_DateTime " +
                                                                                                            "FROM Extract_Data A " +
                                                                                                                "INNER JOIN " +
                                                                                                                    "( " +
                                                                                                                    " " +
                                                                                                                    "SELECT A.Extract_Table_Id " +
                                                                                                                        ", CONVERT(DATE, A.Extract_DateTime, 101) AS Extract_Date " +
                                                                                                                        ", MIN(A.Extract_Data_Key) AS Min_Extract_Data_Key " +
                                                                                                                        "FROM Extract_Data A " +
                                                                                                                            "INNER JOIN " +
                                                                                                                                "(SELECT CONVERT(DATE, Extract_DateTime, 101) AS Extract_Date " +
                                                                                                                                    ", MAX(Extract_Table_Id) AS Max_Extract_Table_Id " +
                                                                                                                                    ", MIN(Extract_Table_Id) AS Min_Extract_Table_Id " +
                                                                                                                                    "FROM Extract_Data " +
                                                                                                                                    "GROUP BY CONVERT(DATE, Extract_DateTime, 101) " +
                                                                                                                                ") B ON CONVERT(DATE, A.Extract_DateTime, 101) = B.Extract_Date " +
                                                                                                                                        "AND A.Extract_Table_Id = B.Min_Extract_Table_Id " +
                                                                                                                        "GROUP BY A.Extract_Table_Id " +
                                                                                                                            ", CONVERT(DATE, A.Extract_DateTime, 101) " +
                                                                                                                    ") B ON A.Extract_Data_Key = B.Min_Extract_Data_Key " +
                                                                                                        ") A " +
                                                                                                        "LEFT JOIN " +
                                                                                                        "(SELECT 'Ending of the run' AS Ending " +
                                                                                                            ", B.Extract_Date " +
                                                                                                            ", A.Extract_DateTime " +
                                                                                                            "FROM Extract_Data A " +
                                                                                                                "INNER JOIN " +
                                                                                                                "( " +
                                                                                                                " " +
                                                                                                                "SELECT A.Extract_Table_Id " +
                                                                                                                    ", CONVERT(DATE, A.Extract_DateTime, 101) AS Extract_Date " +
                                                                                                                    ", MIN(A.Extract_Data_Key) AS Min_Extract_Data_Key " +
                                                                                                                    "FROM Extract_Data A " +
                                                                                                                        "INNER JOIN " +
                                                                                                                            "(SELECT CONVERT(DATE, Extract_DateTime, 101) AS Extract_Date " +
                                                                                                                                ", MAX(Extract_Table_Id) AS Max_Extract_Table_Id " +
                                                                                                                               ", MIN(Extract_Table_Id) AS Min_Extract_Table_Id " +
                                                                                                                               "FROM Extract_Data " +
                                                                                                                                "GROUP BY CONVERT(DATE, Extract_DateTime, 101) " +
                                                                                                                            ") B ON CONVERT(DATE, A.Extract_DateTime, 101) = B.Extract_Date " +
                                                                                                                                    "AND A.Extract_Table_Id = B.Max_Extract_Table_Id " +
                                                                                                                    "GROUP BY A.Extract_Table_Id " +
                                                                                                                        ", CONVERT(DATE, A.Extract_DateTime, 101) " +
                                                                                                                ") B ON A.Extract_Data_Key = B.Min_Extract_Data_Key " +
                                                                                                                                            ") B ON A.Extract_Date = B.Extract_Date " +
                                                                                                                                    ") A " +
                                                                                                                            ") A " +
                                                                                                                        "GROUP BY CONVERT(NVARCHAR(4), A.Extract_Date) " +
                                                                                                                            ", CASE WHEN MONTH(A.Extract_Date) = 1 THEN CONCAT('0', CONVERT(NVARCHAR(2), MONTH(A.Extract_Date))) " +
                                                                                                                                "WHEN LEFT(MONTH(A.Extract_Date), 1) = 1 THEN CONVERT(NVARCHAR(2), MONTH(A.Extract_Date)) " +
                                                                                                                                "ELSE CONCAT('0', CONVERT(NVARCHAR(2), MONTH(A.Extract_Date))) END " +
                                                                                                                    ") A " +
                                                                                                            ") A " +
                                                                                                        "WHERE 1 = 1 " +
                                                                                                            "AND A.Row_Num < 7 " +
                                                                                                        "ORDER BY A.Row_Num DESC; " +
                                                                                                        "DROP TABLE IF EXISTS Red.Red_Etl_Extract_Month_Avg; " +
                                                                                                        "CREATE TABLE Red.Red_Etl_Extract_Month_Avg( " +
                                                                                                            "Extract_Month NVARCHAR(7) " +
                                                                                                            ", Extract_Run_Avg INT " +
                                                                                                        ") " +
                                                                                                        "INSERT INTO Red.Red_Etl_Extract_Month_Avg( " +
                                                                                                            "Extract_Month " +
                                                                                                            ", Extract_Run_Avg " +
                                                                                                        ") " +
                                                                                                        "SELECT RIGHT(Extract_Month,5) AS Extract_Month " +
                                                                                                            ", Extract_Run_Avg " +
                                                                                                            "FROM #Red_Etl_Extract_Month_Avg " +
                                                                                                            "WHERE 1 = 1 " +
                                                                                                                "AND Row_Num = 6 " +
                                                                                                        "UNION " +
                                                                                                        "SELECT RIGHT(Extract_Month,5) AS Extract_Month " +
                                                                                                            ", Extract_Run_Avg " +
                                                                                                            "FROM #Red_Etl_Extract_Month_Avg " +
                                                                                                            "WHERE 1 = 1 " +
                                                                                                                "AND Row_Num = 5 " +
                                                                                                        "UNION " +
                                                                                                        "SELECT RIGHT(Extract_Month,5) AS Extract_Month " +
                                                                                                            ", Extract_Run_Avg " +
                                                                                                            "FROM #Red_Etl_Extract_Month_Avg " +
                                                                                                            "WHERE 1 = 1 " +
                                                                                                                "AND Row_Num = 4 " +
                                                                                                        "UNION " +
                                                                                                        "SELECT RIGHT(Extract_Month,5) AS Extract_Month " +
                                                                                                            ", Extract_Run_Avg " +
                                                                                                            "FROM #Red_Etl_Extract_Month_Avg " +
                                                                                                            "WHERE 1 = 1 " +
                                                                                                                "AND Row_Num = 3 " +
                                                                                                        "UNION " +
                                                                                                        "SELECT RIGHT(Extract_Month,5) AS Extract_Month " +
                                                                                                            ", Extract_Run_Avg " +
                                                                                                            "FROM #Red_Etl_Extract_Month_Avg " +
                                                                                                            "WHERE 1 = 1 " +
                                                                                                                "AND Row_Num = 2 " +
                                                                                                        "UNION " +
                                                                                                        "SELECT RIGHT(Extract_Month,5) AS Extract_Month " +
                                                                                                            ", Extract_Run_Avg " +
                                                                                                            "FROM #Red_Etl_Extract_Month_Avg " +
                                                                                                            "WHERE 1 = 1 " +
                                                                                                                "AND Row_Num = 1; " +
                                                                                                        "SELECT Alpha_Stage AS [Production Table] " +
                                                                                                            ", Alpha_Duration_In_Seconds AS Duration " +
                                                                                                            ", Alpha_Count AS[Count] " +
                                                                                                            ", CONVERT(TIME(0), Alpha_DateTime) AS[Time] " +
                                                                                                            ", ErrorMessage AS Message " +
                                                                                                            "FROM Alpha_Table_1 " +
                                                                                                            "WHERE 1 = 1 " +
                                                                                                                "AND(Alpha_Step_Name = 'Stats' " +
                                                                                                                        "OR Alpha_Result = 0) " +
                                                                                                            "ORDER BY Alpha_Key DESC"
                                                                , conn
                                                             )
                      )
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView5.DataSource = dt;
                }
            }

            //////////////////////////////////////////////////
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////
            // REFRESH DATAGRID
            //////////////////////////////////////
            using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("DROP TABLE IF EXISTS #Red_Etl_Transform_Month_Avg; " +
                                                                "CREATE TABLE #Red_Etl_Transform_Month_Avg ( " +
                                                                    "Transform_Month NVARCHAR(7) " +
                                                                    ", Transform_Run_Avg INT " +
                                                                    ", Row_Num INT " +
                                                                ") " +
                                                                "INSERT INTO #Red_Etl_Transform_Month_Avg ( " +
                                                                    "Transform_Month " +
                                                                    ", Transform_Run_Avg " +
                                                                    ", Row_Num " +
                                                                ") " +
                                                                "SELECT A.Transform_Month " +
                                                                    ", A.Transform_Run_Avg " +
                                                                    ", A.Row_Num " +
                                                                    "FROM " +
                                                                        "(SELECT CONCAT(A.Transform_Year, '-', Transform_Month) AS Transform_Month " +
                                                                            ", CASE WHEN A.Run_Days_Counted > 0 THEN A.Run_Time_Summed / A.Run_Days_Counted ELSE 0 END AS Transform_Run_Avg " +
                                                                            ", ROW_NUMBER() OVER(ORDER BY CONCAT(A.Transform_Year, '-', Transform_Month) DESC) AS Row_Num " +
                                                                            "FROM " +
                                                                                "(SELECT CONVERT(NVARCHAR(4), A.Transform_Date) AS Transform_Year " +
                                                                                    ", CASE WHEN MONTH(A.Transform_Date) = 1 THEN CONCAT('0', CONVERT(NVARCHAR(2), MONTH(A.Transform_Date))) " +
                                                                                           " WHEN LEFT(MONTH(A.Transform_Date), 1) = 1 THEN CONVERT(NVARCHAR(2), MONTH(A.Transform_Date)) " +
                                                                                            "ELSE CONCAT('0', CONVERT(NVARCHAR(2), MONTH(A.Transform_Date))) END AS Transform_Month " +
                                                                                    ", SUM(A.Run_Time) AS Run_Time_Summed " +
                                                                                    ", COUNT(CASE WHEN Run_Time IS NOT NULL THEN 1 ELSE NULL END) AS Run_Days_Counted " +
                                                                                    "FROM " +
                                                                                        "(SELECT A.Transform_Date " +
                                                                                            ", DATEDIFF(MINUTE, A.Begin_Transform_Time, B.End_Transform_Time) AS Run_Time " +
                                                                                            "FROM " +
                                                                                                "(SELECT CONVERT(DATE, Transform_DateTime, 101) AS Transform_Date " +
                                                                                                    ", MIN(CONVERT(TIME, Transform_DateTime)) AS Begin_Transform_Time " +
                                                                                                    "FROM Transform_Data " +
                                                                                                    "GROUP BY CONVERT(DATE, Transform_DateTime, 101) " +
                                                                                                ") A " +
                                                                                                "INNER JOIN " +
                                                                                                    "(SELECT CONVERT(DATE, Transform_DateTime, 101) AS Transform_Date " +
                                                                                                        ", MAX(CONVERT(TIME, Transform_DateTime)) AS End_Transform_Time " +
                                                                                                        "FROM Transform_Data " +
                                                                                                        "WHERE 1 = 1 " +
                                                                                                            "AND CONVERT(TIME(0), Transform_DateTime) BETWEEN '02:30:00' AND '06:00:00' " +
                                                                                                        "GROUP BY CONVERT(DATE, Transform_DateTime, 101) " +
                                                                                                    ") B ON A.Transform_Date = B.Transform_Date " +
                                                                                        ") A " +
                                                                                    "GROUP BY CONVERT(NVARCHAR(4), A.Transform_Date) " +
                                                                                        ", CASE WHEN MONTH(A.Transform_Date) = 1 THEN CONCAT('0', CONVERT(NVARCHAR(2), MONTH(A.Transform_Date))) " +
                                                                                            "WHEN LEFT(MONTH(A.Transform_Date), 1) = 1 THEN CONVERT(NVARCHAR(2), MONTH(A.Transform_Date)) " +
                                                                                            "ELSE CONCAT('0', CONVERT(NVARCHAR(2), MONTH(A.Transform_Date))) END " +
                                                                                ") A " +
                                                                        ") A " +
                                                                    "WHERE 1 = 1 " +
                                                                        "AND A.Row_Num < 7 " +
                                                                    "ORDER BY A.Row_Num DESC; " +
                                                                "DROP TABLE IF EXISTS Red.Red_Etl_Transform_Month_Avg; " +
                                                                "CREATE TABLE Red.Red_Etl_Transform_Month_Avg( " +
                                                                    "Transform_Month NVARCHAR(7) " +
                                                                    ", Transform_Run_Avg INT " +
                                                                ") " +
                                                                "INSERT INTO Red.Red_Etl_Transform_Month_Avg( " +
                                                                    "Transform_Month " +
                                                                    ", Transform_Run_Avg " +
                                                                ") " +
                                                                "SELECT RIGHT(Transform_Month,5) AS Transform_Month " +
                                                                    ", Transform_Run_Avg " +
                                                                    "FROM #Red_Etl_Transform_Month_Avg " +
                                                                    "WHERE 1 = 1 " +
                                                                        "AND Row_Num = 6 " +
                                                                "UNION " +
                                                                "SELECT RIGHT(Transform_Month,5) AS Transform_Month " +
                                                                    ", Transform_Run_Avg " +
                                                                    "FROM #Red_Etl_Transform_Month_Avg " +
                                                                    "WHERE 1 = 1 " +
                                                                        "AND Row_Num = 5 " +
                                                                "UNION " +
                                                                "SELECT RIGHT(Transform_Month,5) AS Transform_Month " +
                                                                    ", Transform_Run_Avg " +
                                                                    "FROM #Red_Etl_Transform_Month_Avg " +
                                                                    "WHERE 1 = 1 " +
                                                                        "AND Row_Num = 4 " +
                                                                "UNION " +
                                                                "SELECT RIGHT(Transform_Month,5) AS Transform_Month " +
                                                                    ", Transform_Run_Avg " +
                                                                    "FROM #Red_Etl_Transform_Month_Avg " +
                                                                    "WHERE 1 = 1 " +
                                                                        "AND Row_Num = 3 " +
                                                                "UNION " +
                                                                "SELECT RIGHT(Transform_Month,5) AS Transform_Month " +
                                                                    ", Transform_Run_Avg " +
                                                                    "FROM #Red_Etl_Transform_Month_Avg " +
                                                                    "WHERE 1 = 1 " +
                                                                        "AND Row_Num = 2 " +
                                                                "UNION " +
                                                                "SELECT RIGHT(Transform_Month,5) AS Transform_Month " +
                                                                    ", Transform_Run_Avg " +
                                                                    "FROM #Red_Etl_Transform_Month_Avg " +
                                                                    "WHERE 1 = 1 " +
                                                                        "AND Row_Num = 1; " +
                                                                "SELECT Alpha_Stage AS [Production Table] " +
                                                                    ", Alpha_Duration_In_Seconds AS Duration " +
                                                                    ", Alpha_Count AS[Count] " +
                                                                    ", CONVERT(TIME(0), Alpha_DateTime) AS[Time] " +
                                                                    ", ErrorMessage AS Message " +
                                                                    "FROM Alpha_Table_2 " +
                                                                    "WHERE 1 = 1 " +
                                                                        "AND(Alpha_Step_Name = 'Stats' " +
                                                                                "OR Alpha_Result = 0) " +
                                                                    "ORDER BY Alpha_Key DESC"
                                                                , conn
                                                             )
                      )
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView6.DataSource = dt;
                }
            }

            //////////////////////////////////////////////////
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////
            // REFRESH DATAGRID
            //////////////////////////////////////
            using (SqlConnection conn = new SqlConnection(@"Data Source=mssql12336\S01;Initial Catalog=OneAccord_Warehouse;Integrated Security=True"))
            {
                using (SqlDataAdapter ad = new SqlDataAdapter("SELECT Alpha_Stage AS [Production Table] " +
                                                                    ", Alpha_Duration_In_Seconds AS Duration " +
                                                                    ", Alpha_Count AS[Count] " +
                                                                    ", CONVERT(TIME(0), Alpha_DateTime) AS[Time] " +
                                                                    ", ErrorMessage AS Message " +
                                                                    "FROM [MSSQL12335\\S01].OneAccord_Warehouse.dbo.Alpha_Table_3 " +
                                                                    "WHERE 1 = 1 " +
                                                                        "AND(Alpha_Step_Name = 'Stats' " +
                                                                                "OR Alpha_Result = 0) " +
                                                                    "ORDER BY Alpha_Key DESC"
                                                                , conn
                                                             )
                      )
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    dataGridView7.DataSource = dt;
                }
            }

            //////////////////////////////////////////////////
        }
    }
}
