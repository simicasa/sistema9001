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

        protected BindingList<T> data = null;
        protected BindingList<T> dataSubset = null;
        protected DbSet dbSet = null;

        protected ListBox list = null;

        protected bool inhibit = false;
        protected int selectedIndex = -1;
        protected Cliente newCliente = null;
        protected Fornitore newFornitore = null;
        protected Categoria newCategoria = null;
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
            this.buttonsEnable(this.defaultEnabledButtons, !editStatus);
            this.buttonsEnable(this.defaultDisabledButtons, editStatus);
        }
        private void buttonsEnable(Button[] buttons, bool enable = true)
        {
            foreach (var button in buttons)
            {
                if(button != null)
                {
                    button.Enabled = enable;
                }
                else
                {
                    Console.WriteLine("Un bottone non esiste");
                }
            }
        }

        protected void textBoxesUpdate(bool enable)
        {
            foreach (var textbox in this.textBoxes.Values.OfType<TextBox>())
            {
                if (textbox != null)
                {
                    textbox.Enabled = enable;
                }
                else
                {
                    Console.WriteLine("Una textbox non esiste");
                }
            }
        }

        protected void orderList(Func<T, Object> orderBy)
        {
            this.data = new BindingList<T>(this.data.OrderBy(orderBy).ToList());
            this.dataSubset = new BindingList<T>(this.dataSubset.OrderBy(orderBy).ToList());
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
}