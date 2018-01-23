using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

public class DataGridSample:Form
{
	DataSet ds;
	DataGrid myGrid;

	public DataGridSample()
	{
		InitializeComponent();
	}

	void InitializeComponent()
	{
		this.ClientSize = new System.Drawing.Size(550, 450);
		myGrid = new DataGrid();
		myGrid.Location = new Point (10,10);
		myGrid.Size = new Size(500, 400);
		myGrid.CaptionText = "Microsoft .NET DataGrid";
		this.Text = "C# Grid Example";

		this.Controls.Add(myGrid);
		ConnectToData();
		myGrid.SetDataBinding(ds, "Suppliers");
	}
	void ConnectToData()
	{
		// Create the ConnectionString and create a SqlConnection.
		// Change the data source value to the name of your computer.
      
		string cString = "Persist Security Info=False;Integrated Security=SSPI;database=northwind;server=DH";
		SqlConnection myConnection = new SqlConnection(cString);
		// Create a SqlDataAdapter.
		SqlDataAdapter myAdapter = new SqlDataAdapter();
		myAdapter.TableMappings.Add("Table", "Suppliers");
		myConnection.Open();
		SqlCommand myCommand = new SqlCommand("SELECT * FROM Suppliers",myConnection);
		myCommand.CommandType = CommandType.Text;
   
		myAdapter.SelectCommand = myCommand;
		Console.WriteLine("The connection is open");
		ds = new DataSet("Customers");
		myAdapter.Fill(ds);
		// Create a second Adapter and Command.
		SqlDataAdapter adpProducts = new SqlDataAdapter();
		adpProducts.TableMappings.Add("Table", "Products");
		SqlCommand cmdProducts = new SqlCommand("SELECT * FROM Products", myConnection);
		adpProducts.SelectCommand = cmdProducts;
		adpProducts.Fill(ds);
		myConnection.Close();
		Console.WriteLine("The connection is closed.");
		System.Data.DataRelation dr;
		System.Data.DataColumn dc1;
		System.Data.DataColumn dc2;
		// Get the parent and child columns of the two tables.
		dc1 = ds.Tables["Suppliers"].Columns["SupplierID"];
		dc2 = ds.Tables["Products"].Columns["SupplierID"];
		dr = new System.Data.DataRelation("suppliers2products", dc1, dc2);
		ds.Relations.Add(dr);
	}
}
