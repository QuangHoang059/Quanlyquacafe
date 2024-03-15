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
    public class FoodDAO
    {
        private static FoodDAO instance = null;

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodDAO();
                    return instance;
                }

                return FoodDAO.instance;
            }
            private set { FoodDAO.instance = value; }
        }
        private FoodDAO() { }
        public List<Food> GetFoodbyCreat(int id)
        {
            List<Food> listfood = new List<Food>(id);
            DataTable data = DataProvider.Instance.ExecuteQuery("select *from Food where idcate = "+id );
          foreach(DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listfood.Add(food);
            }
           return listfood;
        }

        public List<Food> GetFoodbyCreatn()
        {
            List<Food> listfood = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select *from Food " );
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listfood.Add(food);
            }
            return listfood;
        }
        public List<Food> SearchFood(string namefood)
        {
            List<Food> listfood = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery("exec pro_searchfood  @name=N'" + namefood+"'");
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listfood.Add(food);
            }
            return listfood;
        }
        public bool ThemFood(string name,int idcate,float gia)
        {
            int resul = DataProvider.Instance.ExecuteNumQuery(string.Format("insert Food(name1,idcate,gia) values (N'{0}', {1}, {2})",name,idcate,gia));
            return resul > 0;
        }
        public bool SuaFood(int idfood, string name, int idcate, float gia)
        {
            int resul = DataProvider.Instance.ExecuteNumQuery(string.Format("update Food set name1=N'{0}',idcate={1},gia={2} where id={3}", name, idcate, gia,idfood));
            return resul > 0;
        }
        public bool DeleteFood(int id)
        {
            BillistDAO.Instance.DeleteBillisstByIdfood(id);
            int resul = DataProvider.Instance.ExecuteNumQuery(string.Format("delete Food where id={0}", id));
            return resul > 0;
        }
    }
}
