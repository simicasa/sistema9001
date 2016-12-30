using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Reflection;

namespace ProgettoCMA
{
    public partial class UC<T> : UserControl
    {
        protected Home home = null;
        protected ClassDiagramContainer cdc = null;
        
        protected DbSet dbSet = null;
        protected ListBox list = null;
        protected BindingList<T> data = null;
        protected BindingList<T> dataSubset = null;
        protected int selectedIndex = -1;

        protected bool inhibit = false;
        protected T newInstance;
        protected int previousSelected = -1;

        // BUTTONS
        protected Button editBt = null;
        protected Button saveBt = null;
        protected Button deleteBt = null;
        protected Button addBt = null;
        protected Button cancelBt = null;
        private Button[] defaultEnabledButtons  = null;
        private Button[] defaultDisabledButtons = null;

        // TEXT BOXES
        private Dictionary<String, Control> textBoxes = null;

        public UC()
        {
            this.cdc = new ClassDiagramContainer();
            this.textBoxes = new Dictionary<string, Control>();
        }
        public UC(Home home) : this()
        {
            this.home = home;
            //QueryBuilder<T> qb = QueryBuilder<T>.from(this.dbSet);
            //Console.WriteLine(qb.query().ToString());
        }

        protected void getData()
        {
            this.data = this.dataSubset = new BindingList<T>(this.dbSet.OfType<T>().ToList());
            if (this.data.Count() > 0)
            {
                this.selectedIndex = 0;
            }
        }

        protected void buttonsUpdate(bool editStatus)
        {
            if (this.defaultEnabledButtons == null || this.defaultDisabledButtons == null)
            {
                this.defaultEnabledButtons = new Button[] { this.editBt, this.deleteBt, this.addBt };
                this.defaultDisabledButtons = new Button[] { this.saveBt, this.cancelBt };
            }
            this.controlsEnable(this.defaultEnabledButtons, !editStatus);
            this.controlsEnable(this.defaultDisabledButtons, editStatus);
        }

        protected void textBoxesUpdate(bool enabled)
        {
            this.initializeTextBoxes();
            this.controlsEnable(this.textBoxes.Values.OfType<TextBox>().ToArray(), enabled);
        }

        private void controlsEnable(Control[] controls, bool enabled)
        {
            foreach (var control in controls)
            {
                if (control != null)
                {
                    control.Enabled = enabled;
                }
                else
                {
                    throw new Exception("controllo null");
                }
            }
        }

        protected void orderList(Func<T, Object> orderBy)
        {
            if (this.data != null && this.dataSubset != null)
            {
                this.data = new BindingList<T>(this.data.OrderBy(orderBy).ToList());
                this.dataSubset = new BindingList<T>(this.dataSubset.OrderBy(orderBy).ToList());
            }
        }

        protected void searchTextBoxFilterData(Func<T,bool> filter)
        {
            IEnumerable<T> dataFull = this.data.Where(filter).ToList();
            this.dataSubset = new BindingList<T>(dataFull.ToList());
            this.list.DataSource = dataFull;
        }

        private void initializeTextBoxes(bool isIndirizzo = false)
        {
            Type a;
            PropertyInfo[] properties;
            if (isIndirizzo)
            {
                a = typeof(Indirizzo);
            }
            else
            {
                a = typeof(T);
            }
            properties = a.GetProperties();
            foreach (var item in properties)
            {
                if (item.Name.Contains("Indirizzo"))
                {
                    this.initializeTextBoxes(true);
                }
                else
                {
                    Control[] ss = this.Controls.Find(item.Name.ToLower() + "Value", true);
                    if (ss.Count() > 0)
                    {
                        if (typeof(Indirizzo).GetRuntimeProperties().Contains(item))
                        {
                            this.textBoxes["indirizzo_" + item.Name.ToLower()] = ss.First();
                        }
                        else
                        {
                            this.textBoxes[item.Name.ToLower()] = ss.First();
                        }
                    }
                }
            }
            /*
            foreach (var item in this.textBoxes)
            {
                //Console.WriteLine(item.Value.Name + " " + item.Value.Text);
            }
            */

            /*
            Object unmododiverso = new Object();
            unmododiverso = a.InvokeMember("", BindingFlags.CreateInstance, null, unmododiverso, null);
            foreach (var item in typeof(T).GetRuntimeProperties())
            {
                Console.WriteLine(item.Name + item.PropertyType.ToString());
                if (this.textBoxes.ContainsKey(item.Name.ToLower()))
                {
                    if (item.PropertyType == typeof(Int32))
                    {
                        item.SetValue(unmododiverso, Int32.Parse(this.textBoxes[item.Name.ToLower()].Text));
                    }
                    else
                    {
                        item.SetValue(unmododiverso, this.textBoxes[item.Name.ToLower()].Text);
                    }
                }
            }
            */

            /*
            if(a == typeof(Indirizzo))
            {
                return (Indirizzo)unmododiverso;
            }
            else
            {
                unmododiverso.Indirizzo = addr;
                this.cdc.AziendaSet.Add((Cliente)unmododiverso);
                this.cdc.SaveChanges();
            }*/
        }
        protected void databaseAdd(T instanceToSave)
        {
            this.databaseSave(instanceToSave);
        }
        protected void databaseSave(T instanceToSave, bool isUpdate = false)
        {
            this.initializeTextBoxes();
            foreach (var item in typeof(T).GetRuntimeProperties())
            {
                if (this.textBoxes.ContainsKey(item.Name.ToLower()) || item.PropertyType == typeof(Indirizzo))
                {
                    if (item.PropertyType == typeof(Int32))
                    {
                        item.SetValue(instanceToSave, Int32.Parse(this.textBoxes[item.Name.ToLower()].Text));
                    }
                    else if (item.PropertyType == typeof(Indirizzo))
                    {
                        item.SetValue(instanceToSave, this.createIndirizzo());
                    }
                    else
                    {
                        item.SetValue(instanceToSave, this.textBoxes[item.Name.ToLower()].Text);
                    }
                }
            }
            if (!isUpdate)
            {
                this.dbSet.Add(instanceToSave);
            }
            this.cdc.SaveChanges();
        }
        protected void databaseUpdate(T instanceToSave)
        {
            this.databaseSave(instanceToSave, true);
        }

        protected void updateUI(T instanceToShow)
        {
            this.initializeTextBoxes();
            foreach (var item in typeof(T).GetRuntimeProperties())
            {
                if (this.textBoxes.ContainsKey(item.Name.ToLower()) || item.PropertyType == typeof(Indirizzo))
                {
                    if (item.PropertyType == typeof(Indirizzo))
                    {
                        Indirizzo temp = (Indirizzo) item.GetValue(instanceToShow);
                        foreach (var itemm in typeof(Indirizzo).GetRuntimeProperties())
                        {
                            this.textBoxes["indirizzo_" + itemm.Name.ToLower()].Text = itemm.GetValue(temp).ToString();
                        }
                    }
                    else if (item.PropertyType == typeof(Cliente) || item.PropertyType == typeof(Fornitore))
                    {
                        this.textBoxes[item.Name.ToLower()].Text = ((Azienda)item.GetValue(instanceToShow)).Ragione;
                    }
                    else if (item.PropertyType == typeof(Utente))
                    {
                        this.textBoxes[item.Name.ToLower()].Text = ((Utente)item.GetValue(instanceToShow)).Username;
                    }
                    else
                    {
                        this.textBoxes[item.Name.ToLower()].Text = item.GetValue(instanceToShow).ToString();
                    }
                }
            }
        }
        // CLASSES INSTANCE
        private Indirizzo createIndirizzo(Indirizzo indirizzo = null)
        {
            if(indirizzo == null)
            {
                indirizzo = new Indirizzo();
            }
            foreach (var item in typeof(Indirizzo).GetRuntimeProperties())
            {
                if (this.textBoxes.ContainsKey("indirizzo_" + item.Name.ToLower()))
                {
                    item.SetValue(indirizzo, this.textBoxes["indirizzo_" + item.Name.ToLower()].Text);
                }
            }
            return indirizzo;
        }
    }

    public class UC<T, T1> : UC<T>
    {
        protected DbSet dbSetSecondary = null;
        protected ListBox listSecondary = null;
        protected BindingList<T1> dataSecondary = null;
        protected int selectedIndexSecondary = -1;

        public UC() : base()
        {

        }
        public UC(Home home) : base(home)
        {

        }

        protected new void getData()
        {
            base.getData();
            this.dataSecondary = new BindingList<T1>(this.dbSetSecondary.OfType<T1>().ToList());
            if (this.dataSecondary.Count() > 0)
            {
                this.selectedIndexSecondary = 0;
            }
        }
        protected void orderList(Func<T, Object> orderBy, Func<T1, Object> orderBy1)
        {
            base.orderList(orderBy);
            if (this.dataSecondary != null)
            {
                this.dataSecondary = new BindingList<T1>(this.dataSecondary.OrderBy(orderBy1).ToList());
            }
        }
    }

    public class UC<T, T1, T2> : UC<T, T1>
    {
        protected DbSet dbSetCombine = null;
        protected ListBox listCombine = null;
        protected BindingList<T2> dataCombine = null;
        protected int selectedIndexCombine = -1;

        public UC() : base()
        {

        }
        public UC(Home home) : base(home)
        {

        }

        protected new void getData()
        {
            base.getData();
            this.dataCombine = new BindingList<T2>(this.dbSetCombine.OfType<T2>().ToList());
            if (this.dataCombine.Count() > 0)
            {
                this.selectedIndexCombine = 0;
            }
        }
        protected void orderList(Func<T, Object> orderBy, Func<T1, Object> orderBy1, Func<T2, Object> orderBy2)
        {
            base.orderList(orderBy);
            if (this.dataCombine != null)
            {
                this.dataCombine = new BindingList<T2>(this.dataCombine.OrderBy(orderBy2).ToList());
            }
        }
    }
}