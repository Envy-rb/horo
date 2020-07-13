using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horoscope.service
{
    class HoroDBService
    {
        private static string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=resource\database\Horoscope\HoroscopeDB.mdb";

        public static void executeQuery(string CommandText)
        {
            OleDbConnection connection = new OleDbConnection(ConnectionString);

            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = CommandText;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static DataSet yearHoro(int year)
        {
            string query;
            int mod;

            mod = year % 12;
            query = string.Format("SELECT [Year].prediction FROM [Year] WHERE [Year].mod = {0}", mod);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, ConnectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        public static DataSet yearCharacter(int year)
        {
            string query;
            int mod;

            mod = year % 12;
            query = string.Format("SELECT [Year].name, [Year].born FROM [Year] WHERE [Year].mod = {0}", mod);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, ConnectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        public static DataSet monthCharacter(DateTime date)
        {
            string query;
            string dateQuery;

            dateQuery = string.Format("{0}.{1}.2020", date.Month, date.Day);

            query = string.Format("SELECT Horoscope.[name], Horoscope.prediction FROM Horoscope WHERE Format('{0}', \"mm\\/ dd\\/ yy\") BETWEEN  Horoscope.dateFrom AND Horoscope.dateTo;", dateQuery);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, ConnectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        public static DataSet dayPrediction(DateTime date)
        {
            string query;
            string dateQuery;
            int offset;

            dateQuery = string.Format("{0}.{1}.2020", date.Day, date.Month);
            query = string.Format("SELECT id FROM Horoscope WHERE Format('{0}', \"mm\\/ dd\\/ yy\") BETWEEN  Horoscope.dateFrom AND Horoscope.dateTo;", date);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, ConnectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            offset = date.Month + DateTime.Now.Day % 7;
            offset %= 13;
            query = string.Format("SELECT Prediction.Prediction FROM Prediction WHERE id = {0}", offset);
            dataAdapter = new OleDbDataAdapter(query, ConnectionString);
            DataSet ds1 = new DataSet();
            dataAdapter.Fill(ds1);
            return ds1;
        }
    }
}
