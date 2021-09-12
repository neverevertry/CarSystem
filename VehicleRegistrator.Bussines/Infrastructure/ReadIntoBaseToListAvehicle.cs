using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace VehicleRegistrator.Bussines

{

    public interface IReadToListAvehicle
    {
        List<string> ReadToListAvehicle();
    }

    public class ReadIntoFileToListAvehicle : IReadToListAvehicle
    {
        public List<string> ReadToListAvehicle()
        {
            Console.WriteLine("Укажите путь к файлу");
            List <string> list = new List<string>();
            string path = Console.ReadLine();
            try
            {
                StreamReader sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
                Console.WriteLine("Successful import");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Not found file");
                Console.WriteLine(ex.Message);
            }
            return list;
        }
    }

    public class ReadIntoDBToListAvehicle : IReadToListAvehicle
    {
        public List<string> ReadToListAvehicle()
        {
            List<string> datasetToString = new List<string>();

            DB db = new DB();

            DataSet dataset = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM hiject_cars", db.ConnectDB());

            adapter.Fill(dataset);

            datasetToString = dataset.Tables[0].AsEnumerable().Select(n => n.Field<string>(0)).ToList();
            return datasetToString;
        }
    }
}
