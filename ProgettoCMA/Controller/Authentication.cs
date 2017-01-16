using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA.Controller
{
    class Authentication
    {
        public class asd
        {
            public enum AuthRule
            {
                None = 0x0,
                Create = 0x1,
                Read = 0x2,
                Update = 0x4,
                Delete = 0x8,
                CRUD = Create | Read | Update | Delete,
                Administrator = CRUD,
                Employee = CRUD ^ Delete,
                clienti = 0x100,
                categorie = 0x200
                /*
                 * 0x10
                 * 0x20
                 * 0x40
                 * 0x80
                */
            }
            public int ID_ruolo;
            public int ID_Maschera;
        }

        public Authentication()
        {
            asd.AuthRule a = asd.AuthRule.Create | asd.AuthRule.Read;
            int s = (int)(asd.AuthRule.None | a);
            Console.WriteLine(s.ToString());
            Byte d = Byte.Parse(s.ToString());
            Console.WriteLine(d.ToString());
            String f = Convert.ToString(d, 2).PadLeft(8, '0');
            Console.WriteLine(f);
            /*
            int i;
            this.dsa("ciao", out i);
            */
            //this.Check(asd.AuthRule.Create, asd.AuthRule.Employee);
            //this.Check(asd.AuthRule.Create, asd.AuthRule.CRUD);
        }
        public bool dsa(String casa, out int ciao)
        {
            ciao = 2;
            return false;
        }
        public void Check(asd.AuthRule controlRule, asd.AuthRule userPermission)
        {
            Byte res = (Byte)(controlRule & userPermission);
            String f = Convert.ToString(res, 2).PadLeft(8, '0');
            if (res != 0x0)
            {
                Console.WriteLine("permessi accordati");
            }
            else
            {
                Console.WriteLine("permessi NON accordati");
            }
            Console.WriteLine(f);
        }
        /*
    public static Dictionary<Control, asd.AuthRule> SetControlsVisibility(Dictionary<Control, asd.AuthRule> controls, asd.AuthRule formPermission, asd.AuthRule userPermission, asd.AuthRule userFormPermission)
    {
        asd a = new asd();
        a.ID_Maschera = 0x100;

        Console.WriteLine(((asd.AuthRule.CRUD ^ asd.AuthRule.Delete) ^ asd.AuthRule.Update).ToString());
        foreach (var item in controls)
        {
            if ((item.Value & userPermission) == 0x0 && (formPermission ^ userFormPermission) == 0x0)
            {
                item.Key.Visible = false;
                //controls.Remove(item.Key);
            }
            //Console.WriteLine(((int)item.Value).ToString() + " " + ((int)userPermission).ToString() + " " + ((int)formPermission).ToString() + " " + ((int)userFormPermission).ToString());
        }
        return controls;
    }
        */
    }
}
