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


namespace Get_Set_Try
{
    public partial class Form1 : Form
    {
        Person person = new Person();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlCommand Scmd = new SqlCommand();


        public Form1()
        {
            InitializeComponent();

        }
        SqlConnection sqlConnect = new SqlConnection("Data Source=MEPHISTO\\SQLEXPRESS01;Initial Catalog=UsersDatabase;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)

        {

            var da = new SqlDataAdapter("Select *From Persons", sqlConnect);

            sqlConnect.Open();
            da.Fill(ds, "Persons");
            dataGridView1.DataSource = ds.Tables["Persons"];
            sqlConnect.Close();
        }


        private void UptadeBtn_Click(object sender, EventArgs e)
        {
            UptadeBtnClick();
        }
        
        private void UptadeBtnClick()
        {
            // BURADA KALDIM EXECUTE HATA VERİYOR HALA
            string query = "UPDATE Persons SET Names=@Names,SurName=@SurName,Department=@Department,Gender=@Gender,Age=@Age WHERE ID=@ID";
            SqlCommand sqlcmd = new SqlCommand(query , sqlConnect);
            sqlcmd.Parameters.AddWithValue("@ID",Convert.ToInt32(IDTextBox.Text));
            sqlcmd.Parameters.AddWithValue("@Names" , nameTextBox.Text);
            sqlcmd.Parameters.AddWithValue("@SurName", surNameTextBox.Text);
            sqlcmd.Parameters.AddWithValue("@Department", DepartmentTextBox.Text);
            sqlcmd.Parameters.AddWithValue("@Gender", genderTextbox.Text);
            sqlcmd.Parameters.AddWithValue("@Age", Convert.ToInt32(ageTextBox.Text));
            sqlConnect.Open();
            sqlcmd.ExecuteNonQuery();
            sqlConnect.Close();
            listx("SELECT * FROM Persons");


        }

        private void ageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void surNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddBtnClick();
            listx("SELECT *FROM Persons");
            MessageBox.Show("Kayıt Başarıyla Tamamlandı.");
        }

        private void AddBtnClick()
        {

            sqlConnect.Open();
            Scmd.Connection = sqlConnect;
            Scmd.CommandText =
                "INSERT INTO Persons(ID,Names,SurName,Department,Gender,Age) " +
                "VALUES ('" + IDTextBox.Text + "'," +
                "'" + nameTextBox.Text + "'," +
                "'" + surNameTextBox.Text + "'," +
                "'" + DepartmentTextBox.Text + "'," +
                "'" + genderTextbox.Text + "'," +
                "'" + ageTextBox.Text + "')";
            Scmd.ExecuteNonQuery();
            Scmd.Dispose();
            sqlConnect.Close();
            listx("SELECT *FROM Persons");
            TextClear();

        }

        private void TextClear()
        {
            IDTextBox.Clear();
            nameTextBox.Clear();
            surNameTextBox.Clear();
            ageTextBox.Clear();
            DepartmentTextBox.Clear();
            genderTextbox.Clear();
            nameTextBox.Focus();
        }

        private void listx(string veri)
        {
            SqlDataAdapter da = new SqlDataAdapter(veri, sqlConnect);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            sqlConnect.Open();
            SqlCommand Scmd = new SqlCommand("DELETE FROM Persons WHERE ID=@ID", sqlConnect);
            Scmd.Parameters.AddWithValue("@ID", IDTextBox.Text);
            listx("SELECT *FROM Persons");
            Scmd.ExecuteNonQuery();
            sqlConnect.Close();
            listx("SELECT *FROM Persons");
            MessageBox.Show("Kayıt Silindi ");
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            TextClear();
            IDTextBox.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            nameTextBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            surNameTextBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            DepartmentTextBox.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            genderTextbox.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            ageTextBox.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextClear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NameSearch();
        }

        private void NameSearch()
        {
            
            sqlConnect.Open();
            SqlCommand Scmd = new SqlCommand("SELECT * FROM Persons WHERE SurName LIKE '%" + searchTextBox.Text + "%'", sqlConnect);
            SqlDataAdapter da = new SqlDataAdapter(Scmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            sqlConnect.Close();
            
        }

        private void IDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://ege.edu.tr/tr-0/anasayfa.html");
        }

        private void SimiBtn_Click(object sender, EventArgs e)
        { /*
            if (true)
            {
                int x = dataGridView1.Rows.GetLastRow();
                MessageBox.Show("Kayıt eklendi" , Convert.ToString(x));
            }
            else
            {
                MessageBox.Show("Kayıt eklendi");
            }

              KANSER OLACAM YAV , EN SON INDEXE GİDİP BURAYI BİR İNT DEĞERİ ATTIKTAN SONRA 1 ARTTIRIP YENİ BİR KAYIT EKLENDİĞİNDE ID YI OTOMATİK T
            TANIMLATMAYA CALSIIYORUM ....
            */
        }
    }
}
