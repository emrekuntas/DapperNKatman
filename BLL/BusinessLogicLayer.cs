using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BusinessLogicLayer
    {
        DataAccessLayer dal;

        public BusinessLogicLayer()
        {
            dal = new DataAccessLayer();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ad"></param>
        /// <param name="soyad"></param>
        /// <param name="telefon"></param>
        /// <param name="email"></param>
        /// <param name="maas"></param>
        /// <param name="sehir"></param>
        /// <param name="departman"></param>
        /// <returns></returns>
        //Ad,Soyad,telefon,email,maas,sehir,departman
        public int PersonelKaydet(string ad, string soyad, string telefon, string email, int maas, string sehir, string departman)
        {
            int kayitSayisi;
            Personel p = new Personel();
            if (!string.IsNullOrEmpty(ad) && !string.IsNullOrEmpty(soyad) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(departman))
            {
                p.Ad = ad;
                p.Soyad = soyad;
                p.telefon = string.IsNullOrEmpty(telefon) ? " ":telefon;
                p.maas = (maas > 0) ? maas : 2020;
                p.email = email;
                p.sehir = string.IsNullOrEmpty(sehir) ? " " : sehir;
                p.departman = departman;
                kayitSayisi = dal.PersonelKaydet(p);
                
            }
            else
            {
                kayitSayisi = -1;
            }

            return kayitSayisi;
        }

        public int LoginKontrol(string email,string password)
        {
            int ret = 0;
            User u = new User();
            if (EmailKontrol(email) && !string.IsNullOrEmpty(password))
            {
                u.email = email;
                u.pasword = password;
                ret = dal.LoginKontrol(u);

            }
            else
            {
                ret = -1;
            }
            return ret;
        }

        private bool EmailKontrol(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

        }
    }
}
