using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ProgettoCMA.UserControls
{
    public partial class ControllerUC : UserControl
    {
        ControllerUC subUC;
        Type type;
        public ControllerUC()
        {
        }
        protected void Initialize(ControllerUC subUC, Type type)
        {
            this.subUC = subUC;
            this.type = type;
        }
        protected List<T> CreateInstanceFromUI<T>()
        {
            Type classType;
            List<T> instance = new List<T>();
            List<Panel> controls = new List<Panel>();
            classType = Type.GetType("ProgettoCMA." + this.type.Name);
            if (classType != null && classType.IsClass)
            {
                foreach (Control item in this.subUC.Controls)
                {
                    controls.AddRange(GetAllControlsRecusrvive<Panel>(item));
                }
                foreach (Control item in controls)
                {
                    if ((item.GetType() == typeof(Panel)) && item.Name.StartsWith(this.type.Name.ToLower()))
                    {
                        instance.Add(this.fillInstance<T>(item.Controls));
                        /*
                        instance.Add(this.GetType().GetMethod("fillInstance")
                            .MakeGenericMethod(new Type[] { classType })
                            .Invoke(this, new Object[] { item.Controls }));
                        */
                    }
                }
            }
            return instance;
        }
        public static List<T> GetAllControlsRecusrvive<T>(Control control) where T : Control
        {
            var rtn = new List<T>();
            foreach (Control item in control.Controls)
            {
                var ctr = item as T;
                if (ctr != null)
                {
                    rtn.Add(ctr);
                    if (ctr.HasChildren)
                    {
                        rtn.AddRange(GetAllControlsRecusrvive<T>(item));
                    }
                }
                else
                {
                    rtn.AddRange(GetAllControlsRecusrvive<T>(item));
                }
            }
            return rtn;
        }

        #region fillInstance functions
        private T fillInstanceBody<T>(ControlCollection controls, T newInstance)
        {
            Control controlTemp;
            Control[] controlsArray;
            dynamic instance;
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (Type.GetType("ProgettoCMA." + property.PropertyType.Name) != null)
                {
                    Control[] subPanels = controls.Find(property.PropertyType.Name + "Panel", false);
                    if (subPanels.Count() == 1)
                    {
                        instance = this.GetType().GetMethod("fillInstance", new Type[] { typeof(ControlCollection) })
                            .MakeGenericMethod(new Type[] { property.PropertyType })
                            .Invoke(this, new Object[] { subPanels.First().Controls });
                        property.SetValue(newInstance, instance);
                    }
                    else
                    {
                        Console.WriteLine("Istanza " + property.Name + " non trovata e non assegnata alla classe principale [" + typeof(T).Name + "]");
                    }
                }
                else
                {
                    controlsArray = controls.Find(property.Name, true);
                    if (controlsArray.Count() == 1)
                    {
                        controlTemp = controlsArray.First();
                        this.controlGet<T>(ref newInstance, property.Name, controlTemp);
                    }
                    else
                    {
                        Console.WriteLine("Campo " + property.Name + " non trovato e non assegnato all'istanza");
                    }
                }
            }
            return newInstance;
        }
        public T fillInstance<T>(ControlCollection controls)
        {
            T newInstance = (T)Activator.CreateInstance(typeof(T));
            return (this.fillInstanceBody<T>(controls, newInstance));
        }
        public T fillInstance<T>(ControlCollection controls, T oldInstance)
        {
            return (this.fillInstanceBody<T>(controls, oldInstance));
        }
        #endregion

        #region UpdateUI functions
        protected void UpdateUIFromInstance<T>(T instance)
        {
            Type classType;
            List<Panel> controls = new List<Panel>();
            classType = Type.GetType("ProgettoCMA." + this.type.Name);
            if (classType != null && classType.IsClass)
            {
                foreach (Control item in this.subUC.Controls)
                {
                    controls.AddRange(GetAllControlsRecusrvive<Panel>(item));
                }
                foreach (Control item in controls)
                {
                    if ((item.GetType() == typeof(Panel)) && item.Name.StartsWith(this.type.Name.ToLower()))
                    {
                        this.UpdateUI<T>(item.Controls, instance);
                    }
                }
            }
        }
        public void UpdateUI<T>(ControlCollection controls, T newInstance)
        {
            Control controlTemp;
            Control[] controlsArray;
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (Type.GetType("ProgettoCMA." + property.PropertyType.Name) != null)
                {
                    Control[] subPanels = controls.Find(property.PropertyType.Name + "Panel", false);
                    if (subPanels.Count() == 1)
                    {
                        this.GetType().GetMethod("UpdateUI")
                            .MakeGenericMethod(new Type[] { property.PropertyType })
                            .Invoke(this, new Object[] { subPanels.First().Controls, property.GetValue(newInstance) });
                    }
                    else
                    {
                        Console.WriteLine("Istanza " + property.Name + " non trovata e non assegnata alla classe principale [" + typeof(T).Name + "]");
                    }
                }
                else
                {
                    controlsArray = controls.Find(property.Name, true);
                    if (controlsArray.Count() == 1)
                    {
                        controlTemp = controlsArray.First();
                        this.controlSet<T>(ref newInstance, property.Name, controlTemp);
                    }
                    else
                    {
                        Console.WriteLine("Controllo " + property.Name + " non trovato e non assegnato");
                    }
                }
            }
        }
        #endregion

        #region controlPanelInstance functions
        private void controlSet<T>(ref T instance, String fieldName, Control control)
        {
            PropertyInfo field = typeof(T).GetProperty(fieldName);
            control.Text = this.setValue<T>(ref instance, field, control.GetType());
        }
        private dynamic setValue<T>(ref T instance, PropertyInfo field, Type destinationType)
        {
            // CONTROLS HAVING .TEXT
            if (destinationType == typeof(TextBox))
            {
                if (new Type[] { typeof(String), typeof(int), typeof(Int32) }.Contains(field.PropertyType))
                {
                    return field.GetValue(instance).ToString();
                }
            }
            return null;
        }
        private void controlGet<T>(ref T instance, String fieldName, Control control)
        {
            PropertyInfo field = typeof(T).GetProperty(fieldName);
            field.SetValue(instance, this.getValue(control, field.PropertyType));
        }
        private dynamic getValue(Control control, Type destinationType)
        {
            // CONTROLS HAVING .TEXT
            if(control.GetType() == typeof(TextBox))
            {
                if(destinationType == typeof(String))
                {
                    return control.Text;
                }
                else if (new Type[] { typeof(int), typeof(Int32) }.Contains(destinationType))
                {
                    return int.Parse(control.Text);
                }
            }
            return null;
        }
        #endregion
    }
}
