using System.Data.SqlClient;
using Dapper;
namespace DAL
{
    public class DataAccessLayer
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter dap;
        SqlDataReader rdr;

        string constr = "Data Source=SEM-BILGISAYAR;Initial Catalog=test;User ID=test;Password=test;MultipleActiveResultSets=True";
        public DataAccessLayer()
        {
            con = new SqlConnection(constr);
        }

        public int PersonelKaydet(Personel p)
        {
            int kayitsayisi = 0;
            string sql = "Insert into Calisan (Ad,Soyad,telefon,email,maas,sehir,departman)Values (@ad,@soyad,@telefon,@email,@maas,@sehir,@departman) ";
            kayitsayisi = con.Execute(sql , new { @ad = p.Ad ,@soyad=p.Soyad,@telefon= p.telefon,@email= p.email,@maas=p.maas,@sehir=p.sehir,@departman = p.departman  } );

            return kayitsayisi;
            
        }
        public int LoginKontrol(User u)
        {
            int kayitsayisi = 0;
           
            var user= con.Query<User>("Select uid ,email ,islogin from users where email=@email and password= @password", new { @email = u.email, @password = u.pasword });
            //-		user	Count = 1	System.Collections.Generic.IEnumerable<DAL.User> {System.Collections.Generic.List<DAL.User>}

            if (((System.Collections.Generic.List<DAL.User>)user).Count>0 )
            {
                kayitsayisi = 1;

            }

            return kayitsayisi;
        }
    }
}
