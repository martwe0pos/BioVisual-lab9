using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySqlConnector;

namespace lab9;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SendQ(object sender, RoutedEventArgs e)
    {
        string connStr = "server=127.0.0.1;port=3306;user=appuser;password=apppassword;database=login_demo;";
        using var conn = new MySqlConnection(connStr);
        conn.Open();
        string insertSql = "INSERT INTO records (field1, field2 ,field3 , field4 ,field5 , field6 ,field7 , field8 ,field9 , field10 ,field11 , field12 ,field13, field14, field15) VALUES (@index, @names, @semyear, @profile, @datesend, @subject, @points, @teacher, @cause, @stusign, @com1 , @com2 ,@com3, @daterev, @revsign)";
        using var insert = new MySqlCommand(insertSql, conn);
        insert.Parameters.AddWithValue("index", index.Text);
        insert.Parameters.AddWithValue("names", names.Text);
        insert.Parameters.AddWithValue("semyear", semyear.Text);
        insert.Parameters.AddWithValue("profile", profile.Text);
        insert.Parameters.AddWithValue("datesend", datesend.Text);
        insert.Parameters.AddWithValue("subject", subject.Text);
        insert.Parameters.AddWithValue("points", points.Text);
        insert.Parameters.AddWithValue("teacher", teacher.Text);
        insert.Parameters.AddWithValue("cause", cause.Text);
        insert.Parameters.AddWithValue("stusign", stusign.Text);
        insert.Parameters.AddWithValue("com1", com1.Text);
        insert.Parameters.AddWithValue("com2", com2.Text);
        insert.Parameters.AddWithValue("com3", com3.Text);
        insert.Parameters.AddWithValue("daterev", daterev.Text);
        insert.Parameters.AddWithValue("revsign", revsign.Text);
        insert.ExecuteNonQuery();
        string prompt = "SELECT COUNT(*) FROM records";
        using var sql = new MySqlCommand(prompt, conn);
        conn.Close();
    }

    private void LoadQ(object sender, RoutedEventArgs e)
    {
        string connStr = "server=127.0.0.1;port=3306;user=appuser;password=apppassword;database=login_demo;";
        using var conn = new MySqlConnection(connStr);
        conn.Open();
        string prompt = "SELECT * FROM records ORDER BY id DESC LIMIT 1";
        using var sql = new MySqlCommand(prompt, conn);
        using var load = sql.ExecuteReader();
        if (load.Read())
        {
            index.Text = load.GetValue(1).ToString();
            names.Text = load.GetValue(2).ToString();
            semyear.Text = load.GetValue(3).ToString();
            profile.Text = load.GetValue(4).ToString();
            datesend.Text = load.GetValue(5).ToString();
            subject.Text = load.GetValue(6).ToString();
            points.Text = load.GetValue(7).ToString();
            teacher.Text = load.GetValue(8).ToString();
            cause.Text = load.GetValue(9).ToString();
            stusign.Text = load.GetValue(10).ToString();
            com1.Text = load.GetValue(11).ToString();
            com2.Text = load.GetValue(12).ToString();
            com3.Text = load.GetValue(13).ToString();
            daterev.Text = load.GetValue(14).ToString();
            revsign.Text = load.GetValue(15).ToString();
        }
    }
}