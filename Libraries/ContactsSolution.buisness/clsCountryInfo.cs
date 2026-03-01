

using ContactsSolution.Data;
using System.Collections.Generic;
using System.Data;

namespace ContactsSolution.buisness
{
    public class clsCountryInfo
    {

        private enum enMode
        {
            Insert,
            Update,
            Delete
        }

        public int countryID { get; set; }

        public string countryName { get; set; }

        public string code { get; set; }

        public string phoneCode { get; set; }

        private enMode Mode { get; set; }







        public clsCountryInfo()
        {
            this.countryID = 0;
            this.countryName = "";
            this.code = "";
            this.phoneCode = "";
        }

        private clsCountryInfo(int countryID, string countryName,string code,string phoneCode)
        {
            this.countryID = countryID;
            this.countryName = countryName;
            this.code = code;
            this.phoneCode = phoneCode;
        }




        private bool _create()
        {
        
            this.countryID = clsCountryDataAcess.create(this.countryName,this.code,this.phoneCode);
            return this.countryID >= 0;
        }


        private bool _update()
        {

            return clsCountryDataAcess.update(this.countryID, this.countryName, this.code,this.phoneCode);

        }



        public bool save()
        {
            switch(Mode)
            {
                case enMode.Insert:
                    if (this._create())
                    {
                        Mode= enMode.Insert;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return this._update();
                default:
                    return false;

            }
        }



        public static clsCountryInfo FindById(int countryID)
        {
        
            string countryName = "";
            string code = "";
            string phoneCode = "";
            if (clsCountryDataAcess.findCountryById(countryID, ref countryName,ref code,ref phoneCode))
            {
                return new clsCountryInfo(countryID, countryName,code,phoneCode);
            }
            else
            {
                return null;
            }

        }


        public static clsCountryInfo FindByName(string countryName)
        {
            int countryID = 0;
            string code = "";
            string phoneCode = "";
            if (clsCountryDataAcess.findCountryByName(countryName, ref countryID, ref code, ref phoneCode ))
            {
                return new clsCountryInfo(countryID, countryName,code,phoneCode);
            }
            else
            {
                return null;
            }
        }




        public static DataTable getAllCountries()
        {
         
            DataTable countriesDataTable = clsCountryDataAcess.getAllCountries();



            if(countriesDataTable.Rows.Count == 0)
            {
                return null;
            }

            return countriesDataTable;



        }



        public static bool Delete(int countryID)
        {
            return clsCountryDataAcess.DeleteCountryById(countryID);
        }








        }
}
