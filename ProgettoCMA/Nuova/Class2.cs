using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA
{
    class ListBoxUC : ListBox
    {
        dynamic source;
        public void asd<T>(DbSet dbSet)
        {
            this.DataSource = new BindingList<T>(dbSet.OfType<T>().ToList());
            this.ValueMember = "Nome";
            this.DisplayMember = "Nome";
        }
        public void dsa(Type tipo, DbSet dbSet)
        {
            //variabile = Activator.CreateInstance(tipo);
            dynamic t = typeof(BindingList<>).MakeGenericType(tipo);
            //var lista = Activator.CreateInstance(t);
            var lista = Activator.CreateInstance(t, new Object[] { Shared.cdc.CategoriaSet.ToList() });

            //BindingList<Categoria> c = new BindingList<Categoria>();
            //c.Count();

            //t.GetMethod("Count").Invoke(lista, null);
            //lista = t.GetConstructor(new Type[] { typeof(BindingList<>).MakeGenericType(tipo) }).Invoke(new Object[] { Shared.cdc.CategoriaSet.ToList() });
            //Shared.messageBox(lista.GetType().ToString() + " - " + lista.ToString());
            this.DataSource = lista;
            this.ValueMember = "Nome";
            this.DisplayMember = "Nome";
            foreach (MethodInfo item in t.GetMethods())
            {
                Console.WriteLine(item.Name);
            }
            string str = t.GetMethod("ToString").Invoke(lista, null).ToString();
            //string str = t.GetProperty("Count").GetValue(lista).ToString();
            Shared.messageBox(str);
            //t.GetProperty("DataSource").SetValue(t, Shared.cdc.CategoriaSet.ToList());
            //this.DataSource
            //return variabile;
        }
    }
}
