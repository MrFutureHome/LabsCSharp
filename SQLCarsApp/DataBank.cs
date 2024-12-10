using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLCarsApp
{
    static class DataBank
    {
        //хранение в памяти данных о текущем пользователе
        public static int client_ID;
        public static string client_name;
        public static string client_login;

        //включение нужных ролей у пользователя
        public static bool check_for_director = false;
        public static bool check_for_sysadmin = false;
        public static bool check_for_consult = false;
        public static bool check_for_manager = false;
        public static bool check_for_client = false;

        //данные о выбранном пользователе в админ-панели
        public static bool selectedUser_check_for_director = false;
        public static bool selectedUser_check_for_sysadmin = false;
        public static bool selectedUser_check_for_consult = false;
        public static bool selectedUser_check_for_manager = false;
        public static bool selectedUser_check_for_client = false;
        public static int selectedUser_id;

        //данные о выбранной машине в панели ассортимента
        public static string selectedCarVIN;

        //данные о выбранной машине в панели заказов

        public static string orders_selectedCarVIN;
        public static string orders_selectedCarBrand;
        public static string orders_selectedCarModel;
        public static string orders_selectedCarBody;
        public static string orders_selectedCarGear;
        public static string orders_selectedCarDrive;
        public static string orders_selectedCarEngine;

        public static int buyer_id;

    }
}
