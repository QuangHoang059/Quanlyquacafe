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
namespace banhang
{
    public class CreatFoodDAO
    {
        private static CreatFoodDAO instance = null;

        public static CreatFoodDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CreatFoodDAO();
                    return instance;
                }

                return CreatFoodDAO.instance;
            }
            private set { CreatFoodDAO.instance = value; }
        }
        private CreatFoodDAO() { }
        public List<Creatfood> LoadCreatFoodList()
        {
            List<Creatfood> creatlist = new List<Creatfood>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select *from FoodCate ");
            foreach (DataRow item in data.Rows)
            {
                Creatfood table = new Creatfood(item);
                creatlist.Add(table);
            }
            return creatlist;
        }
        public List<Creatfood> SearchFoodCate(string namefoodcate)
        {
            List<Creatfood> listfoodcate = new List<Creatfood>();
            DataTable data = DataProvider.Instance.ExecuteQuery("exec pro_searchFoodCate  @name=N'" + namefoodcate + "'");
            foreach (DataRow item in data.Rows)
            {
                Creatfood foodcate = new Creatfood(item);
                listfoodcate.Add(foodcate);
            }
            return listfoodcate;
        }
        public Creatfood GetNamecatebyId(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select *from FoodCate where id="+id.ToString());
            if (data.Rows.Count > 0)
            {
                Creatfood namecate = new Creatfood(data.Rows[0]);
                return namecate;
            }
            return null;
        }
        public bool ThemCateFood(string name)
        {
            int resul = DataProvider.Instance.ExecuteNumQuery(string.Format("insert FoodCate(name1) values (N'{0}') ", name));
            return resul > 0;
        }
        public bool SuaCateFood(int idcatefoood,string name)
        {
            int resul = DataProvider.Instance.ExecuteNumQuery(string.Format("update FoodCate set name1=N'{0}' where id={1} ", name,idcatefoood));
            return resul > 0;
        }
        public bool DeleteCateFood(int idcatefoood)
        {
            int resul = DataProvider.Instance.ExecuteNumQuery(string.Format("exec Pro_DeeteCatefood @idcate={0} ", idcatefoood));
            return resul > 0;
        }
    }
}
