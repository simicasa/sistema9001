﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ProgettoCMA
{
    public partial class Categorie : UC<Categoria>
    {
        public Categorie(Home home) : base(home)
        {
            InitializeComponent();

            // DB SET
            this.dbSet = Shared.cdc.CategoriaSet;

            // LIST
            this.list = listBox;
            this.list.DisplayMember = "Nome";
            this.list.ValueMember = "Nome";

            // BUTTONS
            this.editBt = editButton;
            this.saveBt = saveButton;
            this.deleteBt = deleteButton;
            this.addBt = addButton;
            this.cancelBt = annullaButton;

            this.initialize(this.orderList);
        }

        protected override void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.newInstance != null)
            {
                if (DialogResult.Yes == this.messageBoxShow("Cambiare categoria e perdere il nuovo?", MessageBoxButtons.YesNo))
                {
                    this.listInhibit = true;
                    this.data.Remove(this.newInstance);
                    this.dataSubset.Remove(this.newInstance);
                    //this.list.Items.Remove(this.newInstance);
                    this.orderList();
                    this.list.SetSelected(this.selectedIndex, true);
                    this.listInhibit = false;
                    this.newInstance = null;
                }
                else
                {
                    this.listInhibit = true;
                    this.list.SetSelected(this.selectedIndex, true);
                    this.listInhibit = false;
                    return;
                }
            }
            if (this.selectedIndex == -1)
            {
                if (this.data.Count() == 0)
                {
                    MessageBox.Show("L'elenco e' vuoto");
                    editButton.Enabled = false;
                }
                return;
            }
        }
        private void editButtons()
        {
            this.buttonsUpdate(true);
            searchTextBox.Enabled = false;
            this.list.Enabled = false;

            this.textBoxesEnable(true);
            idValue.Enabled = false;
        }
        private void saveButtons()
        {
            this.buttonsUpdate(false);
            searchTextBox.Enabled = true;
            this.list.Enabled = true;

            this.textBoxesEnable(false);
        }
        private void updateFields()
        {
            this.listInhibit = true;
            bool isNew = (this.newInstance == null) ? false : true;
            Categoria categoria;
            if (!isNew)
            {
                int ID = Int32.Parse(idValue.Text);
                categoria = Shared.cdc.CategoriaSet.Where(x => x.Id == ID).First();
                this.databaseUpdate(categoria);
                Categoria old = this.dataSubset[this.selectedIndex];
                this.dataSubset[this.selectedIndex] = categoria;
                this.data[this.data.IndexOf(old)] = categoria;
            }
            else
            {
                categoria = this.newInstance;
                this.databaseAdd(categoria);
            }
            try
            {
                this.orderList();
                this.list.SelectedItem = categoria;
                searchTextBox.Text = "";
                this.newInstance = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            this.listInhibit = false;
        }
        private void orderList()
        {
            base.orderList(x => x.Nome);
            this.list.DataSource = this.dataSubset;
        }

        protected override void editButton_Click(object sender, EventArgs e)
        {
            if (this.selectedIndex == -1)
            {
                MessageBox.Show("Nessun categoria presente", "Gestione Categoria", MessageBoxButtons.OK);
                return;
            }
            this.editButtons();
        }
        protected override void saveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Continuare con il salvataggio?", "Aggiunta Categoria", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.saveButtons();
                this.updateFields();
            }
        }
        protected override void addButton_Click(object sender, EventArgs e)
        {
            this.listInhibit = true;
            this.newInstance = new Categoria(-1, "");
            this.data.Add(newInstance);
            this.dataSubset.Add(newInstance);
            this.orderList();
            this.list.SelectedItem = newInstance;
            this.selectedIndex = this.list.SelectedIndex;
            Console.WriteLine("1");
            this.editButtons();
            Console.WriteLine("2");
            this.updateUI(this.newInstance);
            this.listInhibit = false;
        }
        protected override void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Eliminare il categoria?", "Gestione categorie", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Categoria categoria = (Categoria)this.listBox.SelectedItem;
                this.listInhibit = true;
                Shared.cdc.CategoriaSet.Remove(categoria);
                this.data.Remove(categoria);
                this.dataSubset.Remove(categoria);
                this.listInhibit = false;
                this.orderList();
                Shared.cdc.SaveChanges();
            }
        }
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            base.searchTextBoxFilterData(c => c.Nome.Contains(searchTextBox.Text));
        }
        protected override void annullaButton_Click(object sender, EventArgs e)
        {
            updateUI(this.dataSubset[this.selectedIndex]);
            saveButtons();
        }
    }
}
