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
    public partial class UC : UserControl
    {
        // CONTROLS
        protected Control[] defaultEnabledControls = null;
        protected Control[] defaultDisabledControls = null;
        protected Control[] alwaysEnabledControls = null;
        protected Dictionary<String, Control> controls = null;

        // BUTTONS
        protected Button editBt = null;
        protected Button saveBt = null;
        protected Button deleteBt = null;
        protected Button addBt = null;
        protected Button cancelBt = null;
        protected Button[] defaultEnabledButtons = null;
        protected Button[] defaultDisabledButtons = null;

        public UC()
        {
            this.controls = new Dictionary<string, Control>();
        }

        protected virtual void editButton_Click(object sender, EventArgs e)
        {
        }
        protected virtual void saveButton_Click(object sender, EventArgs e)
        {
        }
        protected virtual void addButton_Click(object sender, EventArgs e)
        {
        }
        protected virtual void deleteButton_Click(object sender, EventArgs e)
        {
        }
        protected virtual void annullaButton_Click(object sender, EventArgs e)
        {
        }
    }

    public class UC<T> : UC
    {
        protected DbSet dbSet = null;
        protected ListBox list = null;
        protected BindingList<T> data = null;
        protected BindingList<T> dataSubset = null;
        protected int selectedIndex = -1;

        protected String TName = null;

        protected bool listInhibit = false;
        protected T newInstance;
        protected int previousSelected = -1;

        // CONSTRUCTORS
        public UC() : base()
        {
            this.listInhibit = true;
            this.TName = typeof(T).Name;
        }
        // ENABLE/DISABLE FUNCTIONS
        protected void buttonsUpdate(bool editStatus)
        {
            if (this.selectedIndex == -1)
            {
                this.controlsEnable(this.defaultEnabledButtons, false);
                this.controlsEnable(this.defaultDisabledButtons, false);
                this.controlsEnable(new Control[] { this.addBt }, true);
                return;
            }
            this.controlsEnable(this.defaultEnabledButtons, !editStatus);
            this.controlsEnable(this.defaultDisabledButtons, editStatus);
        }
        protected void textBoxesEnable(bool enabled)
        {
            this.controlsEnable(this.controls.Values.OfType<TextBox>().ToArray(), enabled);
        }
        protected void controlsUpdate(bool editStatus)
        {
            this.controlsEnable(this.defaultEnabledControls, !editStatus);
            this.controlsEnable(this.defaultDisabledControls, editStatus);
        }
        private void controlsEnable(Control[] controls, bool enabled, bool forceAlwaysEnabled = false)
        {
            if (controls != null)
            {
                Control[] controlsToUse = controls;
                if (this.alwaysEnabledControls != null && !forceAlwaysEnabled)
                {
                    controlsToUse = (controls.Except(this.alwaysEnabledControls).ToArray());
                }
                foreach (var control in controlsToUse)
                {
                    control.Enabled = enabled;
                }
            }
        }


        protected DialogResult messageBoxShow(String text, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            return Shared.messageBox(text, this.TName, buttons, icon);
        }

        protected void initialize(Action orderListFunction, Control[] defaultEnabledControls = null, Control[] defaultDisabledControls = null, Control[] alwaysEnabledControls = null)
        {
            this.initializeFull(orderListFunction, this.getData, defaultEnabledControls, defaultDisabledControls, alwaysEnabledControls);
        }
        protected void initializeFull(Action orderListFunction, Action getDataFunction, Control[] defaultEnabledControls, Control[] defaultDisabledControls, Control[] alwaysEnabledControls)
        {
            this.defaultEnabledButtons = new Button[] { this.editBt, this.deleteBt, this.addBt };
            this.defaultDisabledButtons = new Button[] { this.saveBt, this.cancelBt };
            if (defaultEnabledControls != null)
            {
                this.defaultEnabledControls = defaultEnabledControls;
                this.defaultEnabledButtons = (Button[])(this.defaultEnabledButtons.Union(defaultEnabledControls.OfType<Button>()).ToArray());
            }
            if (defaultDisabledControls != null)
            {
                this.defaultDisabledControls = defaultDisabledControls;
                this.defaultDisabledButtons = (Button[])(this.defaultDisabledButtons.Union(defaultDisabledControls.OfType<Button>()).ToArray());
            }
            this.controlsUpdate(false);

            getDataFunction();
            orderListFunction();
            this.initializeTextBoxes();
            this.textBoxesEnable(false);
            this.listInhibit = false;
            if (this.selectedIndex != -1)
            {
                this.updateUI(this.data[this.selectedIndex]);
            }
            if (alwaysEnabledControls != null)
            {
                this.controlsEnable(this.alwaysEnabledControls = alwaysEnabledControls, true, (this.selectedIndex != -1));
            }
            this.buttonsUpdate(false);
            this.list.SelectedIndexChanged += new EventHandler(this.listBox_SelectedIndexChangedBefore);
            this.editBt.Click += new EventHandler(this.editButton_Click);
            this.saveBt.Click += new EventHandler(this.saveButton_Click);
            this.addBt.Click += new EventHandler(this.addButton_Click);
            this.deleteBt.Click += new EventHandler(this.deleteButton_Click);
            this.cancelBt.Click += new EventHandler(this.annullaButton_Click);
        }
        
        protected virtual void listBox_SelectedIndexChangedBefore(object sender, EventArgs e)
        {
            if (this.listInhibit)
            {
                return;
            }
            this.selectedIndex = this.list.SelectedIndex;
            this.listBox_SelectedIndexChanged(sender, e);
            this.listBox_SelectedIndexChangedAfter(sender, e);
        }
        protected virtual void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected virtual void listBox_SelectedIndexChangedAfter(object sender, EventArgs e)
        {
            if(this.dataSubset.Count > 0)
            {
                this.updateUI(this.dataSubset[this.selectedIndex]);
            }
            this.previousSelected = this.list.SelectedIndex;
        }
        
        // DATA GETTERS
        protected void getData()
        {
            this.data = this.dataSubset = new BindingList<T>(this.dbSet.OfType<T>().ToList());
            if (this.data.Count() > 0)
            {
                this.selectedIndex = 0;
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

        protected void initializeTextBoxes(bool isIndirizzo = false)
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
                            this.controls["indirizzo_" + item.Name.ToLower()] = ss.First();
                        }
                        else
                        {
                            this.controls[item.Name.ToLower()] = ss.First();
                        }
                    }
                }
            }
            /*
            Object unmododiverso = new Object();
            unmododiverso = a.InvokeMember("", BindingFlags.CreateInstance, null, unmododiverso, null);
            */
        }
        protected void eraseTextBoxes()
        {
            foreach (var textbox in this.controls.Values.OfType<TextBox>())
            {
                textbox.Clear();
            }
        }

        // DATABASE FUNCTIONS
        protected void databaseAdd(T instanceToSave)
        {
            this.databaseSave(instanceToSave);
        }
        protected void databaseSave(T instanceToSave, bool isUpdate = false)
        {
            foreach (var item in typeof(T).GetRuntimeProperties())
            {
                if (this.controls.ContainsKey(item.Name.ToLower()) || item.PropertyType.IsClass)
                {
                    if (item.PropertyType == typeof(Int32))
                    {
                        item.SetValue(instanceToSave, Int32.Parse(this.controls[item.Name.ToLower()].Text));
                    }
                    else if (item.PropertyType == typeof(Indirizzo))
                    {
                        item.SetValue(instanceToSave, this.createIndirizzo());
                    }
                    else if (item.PropertyType == typeof(Cliente) || item.PropertyType == typeof(Categoria))
                    {
                        if (this.controls[item.Name.ToLower()].GetType() == typeof(ListBox))
                        {
                            item.SetValue(instanceToSave, ((ListBox)this.controls[item.Name.ToLower()]).SelectedItem);
                        }
                        else if (this.controls[item.Name.ToLower()].GetType() == typeof(ComboBox))
                        {
                            item.SetValue(instanceToSave, ((ComboBox)this.controls[item.Name.ToLower()]).SelectedItem);
                        }
                        else if (this.controls[item.Name.ToLower()].GetType() == typeof(TextBox))
                        {
                            if (item.PropertyType == typeof(Cliente))
                            {
                                IQueryable<Cliente> var = Shared.cdc.AziendaSet.OfType<Cliente>().Where(c => c.Ragione == this.controls[item.Name.ToLower()].Text);
                                if (var.Count() == 1)
                                {
                                    item.SetValue(instanceToSave, var.First());
                                }
                                else
                                {
                                    item.SetValue(instanceToSave, null);
                                }
                            }
                            else if (item.PropertyType == typeof(Categoria))
                            {
                                IQueryable<Categoria> var = Shared.cdc.CategoriaSet.OfType<Categoria>().Where(c => c.Nome == this.controls[item.Name.ToLower()].Text);
                                if (var.Count() == 1)
                                {
                                    item.SetValue(instanceToSave, var.First());
                                }
                                else
                                {
                                    item.SetValue(instanceToSave, null);
                                }
                            }
                        }
                    }
                    else if(item.PropertyType == typeof(Utente))
                    {
                        item.SetValue(instanceToSave, Shared.utente);
                    }
                    else
                    {
                        item.SetValue(instanceToSave, this.controls[item.Name.ToLower()].Text);
                    }
                }
            }
            if (!isUpdate)
            {
                this.dbSet.Add(instanceToSave);
            }
            Shared.cdc.SaveChanges();
            if (!isUpdate)
            {
                this.updateUI(instanceToSave);
            }
        }
        protected void databaseUpdate(T instanceToSave)
        {
            this.databaseSave(instanceToSave, true);
        }
        protected void databaseRemove(T instanceToSave)
        {
            this.listInhibit = true;
            this.dbSet.Remove(instanceToSave);
            this.data.Remove(instanceToSave);
            this.dataSubset.Remove(instanceToSave);
            this.listInhibit = false;
            Shared.cdc.SaveChanges();
            if (this.data.Count() <= 0)
            {
                this.eraseTextBoxes();
            }
        }

        protected void updateUI(T instanceToShow)
        {
            this.updateUIbeforeFull(instanceToShow);
            foreach (var item in typeof(T).GetRuntimeProperties())
            {
                if (this.controls.ContainsKey(item.Name.ToLower()) || item.PropertyType == typeof(Indirizzo))
                {
                    if (item.PropertyType == typeof(Indirizzo))
                    {
                        Indirizzo temp = (Indirizzo) item.GetValue(instanceToShow);
                        foreach (var itemm in typeof(Indirizzo).GetRuntimeProperties())
                        {
                            this.controls["indirizzo_" + itemm.Name.ToLower()].Text = itemm.GetValue(temp).ToString();
                        }
                    }
                    else if (item.PropertyType == typeof(Categoria))
                    {
                        if(((Categoria)item.GetValue(instanceToShow)) != null)
                        {
                            this.controls[item.Name.ToLower()].Text = ((Categoria)item.GetValue(instanceToShow)).Nome;
                        }
                        else
                        {
                            this.controls[item.Name.ToLower()].Text = "";
                        }
                    }
                    else if (item.PropertyType == typeof(Cliente) || item.PropertyType == typeof(Fornitore))
                    {
                        if (this.controls[item.Name.ToLower()].GetType() == typeof(ListBox))
                        {
                            ((ListBox)this.controls[item.Name.ToLower()]).SelectedItem = ((Azienda)item.GetValue(instanceToShow));
                        }
                        else if (this.controls[item.Name.ToLower()].GetType() == typeof(ComboBox))
                        {
                            ((ComboBox)this.controls[item.Name.ToLower()]).SelectedItem = ((Azienda)item.GetValue(instanceToShow));
                        }
                        else if (this.controls[item.Name.ToLower()].GetType() == typeof(TextBox))
                        {
                            this.controls[item.Name.ToLower()].Text = ((Azienda)item.GetValue(instanceToShow)).Ragione;
                        }
                    }
                    else if (item.PropertyType == typeof(Utente))
                    {
                        this.controls[item.Name.ToLower()].Text = ((Utente)item.GetValue(instanceToShow)).Username;
                    }
                    else
                    {
                        this.controls[item.Name.ToLower()].Text = item.GetValue(instanceToShow).ToString();
                    }
                }
            }
            this.updateUIafterFull(instanceToShow);
        }
        private void updateUIbeforeFull(T instanceToShow)
        {
            this.updateUIbefore(instanceToShow);
        }
        protected virtual void updateUIbefore(T instanceToShow)
        {
        }
        private void updateUIafterFull(T instanceToShow)
        {
            this.updateUIafter(instanceToShow);
        }
        protected virtual void updateUIafter(T instanceToShow)
        {
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
                if (this.controls.ContainsKey("indirizzo_" + item.Name.ToLower()))
                {
                    item.SetValue(indirizzo, this.controls["indirizzo_" + item.Name.ToLower()].Text);
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
        protected BindingList<T1> dataSecondarySubSet = null;
        protected int selectedIndexSecondary = -1;

        public UC() : base()
        {

        }

        protected void searchTextBoxFilterData1(Func<T1, bool> filter1)
        {
            IEnumerable<T1> dataFull = this.dataSecondary.Where(filter1).ToList();
            this.dataSecondarySubSet = new BindingList<T1>(dataFull.ToList());
            this.listSecondary.DataSource = dataFull;
        }

        protected new void initialize(Action orderListFunction, Control[] defaultEnabledControls = null, Control[] defaultDisabledControls = null, Control[] alwaysEnabledControls = null)
        {
            this.initializeFull(orderListFunction, this.getData, defaultEnabledControls, defaultDisabledControls, alwaysEnabledControls);
        }
        protected new void getData()
        {
            base.getData();
            this.dataSecondary = this.dataSecondarySubSet = new BindingList<T1>(this.dbSetSecondary.OfType<T1>().ToList());
            if (this.dataSecondary.Count() > 0)
            {
                this.selectedIndexSecondary = 0;
            }
        }
        protected void orderList(Func<T, Object> orderBy, Func<T1, Object> orderBy1)
        {
            base.orderList(orderBy);
            if (this.dataSecondary != null && this.dataSecondarySubSet != null)
            {
                this.dataSecondary = new BindingList<T1>(this.dataSecondary.OrderBy(orderBy1).ToList());
                this.dataSecondarySubSet = new BindingList<T1>(this.dataSecondarySubSet.OrderBy(orderBy1).ToList());
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

        protected new void initialize(Action orderListFunction, Control[] defaultEnabledControls = null, Control[] defaultDisabledControls = null, Control[] alwaysEnabledControls = null)
        {
            this.initializeFull(orderListFunction, this.getData, defaultEnabledControls, defaultDisabledControls, alwaysEnabledControls);
        }
        protected virtual new void getData()
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