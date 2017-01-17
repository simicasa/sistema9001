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
using System.Data.Entity.Core.Objects.DataClasses;
using ProgettoCMA.Controller;

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
        public static List<T> GetAllControlsRecursive<T>(ControlCollection controls, Type[] notToTakeTypes = null) where T : Control
        {
            List<T> controlsList = new List<T>();
            foreach (Control item in controls)
            {
                controlsList.AddRange(GetAllControlsRecursive<T>(item, notToTakeTypes));
            }
            return controlsList;
        }
        public static List<T> GetAllControlsRecursive<T>(Control control, Type[] notToTakeTypes = null) where T : Control
        {
            var rtn = new List<T>();
            foreach (Control item in control.Controls)
            {
                var ctr = item as T;
                if (ctr != null)
                {
                    if(!notToTakeTypes?.Contains(ctr.GetType()) ?? true)
                    {
                        rtn.Add(ctr);
                    }
                    if (ctr.HasChildren)
                    {
                        rtn.AddRange(GetAllControlsRecursive<T>(item));
                    }
                }
                else
                {
                    rtn.AddRange(GetAllControlsRecursive<T>(item));
                }
            }
            return rtn;
        }

        #region Create/Update Instance from UI
        protected List<T> CreateInstanceFromUI<T>()
        {
            List<T> instance = new List<T>();
            Type classType = Type.GetType("ProgettoCMA." + typeof(T).Name);
            if (classType?.IsClass ?? false)
            {
                foreach (Panel item in GetAllControlsRecursive<Panel>(this.subUC.Controls))
                {
                    if (item.Name.StartsWith(typeof(T).Name.ToLower()))
                    {
                        instance.Add(this.CreateInstanceFromUI<T>(item.Controls));
                        /*
                        instance.Add(this.GetType().GetMethod("CreateInstanceFromUI")
                            .MakeGenericMethod(new Type[] { classType })
                            .Invoke(this, new Object[] { item.Controls }));
                        */
                    }
                }
            }
            return instance;
        }
        private T CreateInstanceFromUI<T>(ControlCollection controls)
        {
            T newInstance = (T)Activator.CreateInstance(typeof(T));
            return (this.FillInstanceFromUI<T>(controls, newInstance));
        }

        protected T UpdateInstanceFromUI<T>(T instanceToUpdate)
        {
            //List<T> instance = new List<T>();
            Type classType = Type.GetType("ProgettoCMA." + typeof(T).Name);
            if (classType != null && classType.IsClass)
            {
                List<Panel> controls = GetAllControlsRecursive<Panel>(this.subUC.Controls);
                foreach (Panel item in controls.ToList())
                {
                    if (!item.Name.StartsWith(typeof(T).Name.ToLower()))
                    {
                        controls.Remove(item);
                    }
                }
                if (controls.Count == 1)
                {
                    Panel panel = controls.First();
                //foreach (Panel item in controls)
                //{
                    if (panel.Name.StartsWith(typeof(T).Name.ToLower()))
                    {
                        //instance.Add(this.UpdateInstanceFromUI<T>(panel.Controls, instanceToUpdate));
                        instanceToUpdate = this.UpdateInstanceFromUI<T>(panel.Controls, instanceToUpdate);
                        /*
                        instance.Add(this.GetType().GetMethod("CreateInstanceFromUI")
                            .MakeGenericMethod(new Type[] { classType })
                            .Invoke(this, new Object[] { item.Controls }));
                        */
                    }
                }
            }
            return instanceToUpdate;
        }
        private T UpdateInstanceFromUI<T>(ControlCollection controls, T instanceToUpdate)
        {
            return (this.FillInstanceFromUI<T>(controls, instanceToUpdate));
        }

        private T FillInstanceFromUI<T>(ControlCollection controls, T newInstance)
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
                        instance =
                            typeof(ControllerUC)
                            .GetMethod("CreateInstanceFromUI", BindingFlags.NonPublic | BindingFlags.Instance, Type.DefaultBinder, new Type[] { typeof(ControlCollection) }, new ParameterModifier[] { })
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
                        this.ControlGet<T>(ref newInstance, property.Name, controlTemp);
                    }
                    else
                    {
                        Console.WriteLine("Campo " + property.Name + " non trovato e non assegnato all'istanza");
                    }
                }
            }
            return newInstance;
        }
        #endregion

        #region Update UI using T instance
        protected void UpdateUIFromInstance<T>(T instance)
        {
            Type classType;
            classType = Type.GetType("ProgettoCMA." + this.type.Name);
            if (classType != null && classType.IsClass)
            {
                foreach (Control item in GetAllControlsRecursive<Panel>(this.subUC.Controls))
                {
                    if ((item.GetType() == typeof(Panel)) && item.Name.StartsWith(this.type.Name.ToLower()))
                    {
                        this.UpdateUI<T>(item.Controls, instance);
                    }
                }
            }
        }
        private void UpdateUI<T>(ControlCollection controls, T newInstance)
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
                        typeof(ControllerUC)
                            .GetMethod("UpdateUI", BindingFlags.NonPublic | BindingFlags.Instance)
                            .MakeGenericMethod(new Type[] { property.PropertyType })
                            .Invoke(this, new Object[] { subPanels.First().Controls, property.GetValue(newInstance) });
                    }
                    else
                    {
                        Debug.ConsoleWriteLine("Istanza " + property.Name + " non trovata e non assegnata alla classe principale [" + typeof(T).Name + "]");
                    }
                }
                else
                {
                    controlsArray = controls.Find(property.Name, true);
                    if (controlsArray.Count() == 1)
                    {
                        controlTemp = controlsArray.First();
                        this.ControlSet<T>(ref newInstance, property.Name, controlTemp);
                    }
                    else
                    {
                        Debug.ConsoleWriteLine("Controllo " + property.Name + " non trovato e non assegnato");
                    }
                }
            }
        }
        #endregion

        #region Clean UI
        protected void CleanUI(params Control[] parentControl)
        {
            List<Control> controls;
            if(parentControl.Count() > 0)
            {
                controls = new List<Control>();
                foreach (var control in parentControl)
                {
                    controls.AddRange(ControllerUC.GetAllControlsRecursive<Control>(control));
                }
            }
            else
            {
                controls = ControllerUC.GetAllControlsRecursive<Control>(this.subUC.Controls);
            }
            foreach (Control control in controls)
            {
                if (
                    control.GetType().GetRuntimeProperty("Text") != null &&
                    new Type[] { typeof(TextBox) }.Contains(control.GetType())
                    )
                {
                    control.Text = "";
                }
            }
        }
        #endregion

        #region Control get/set
        private void ControlSet<T>(ref T instance, String fieldName, Control control)
        {
            PropertyInfo field = typeof(T).GetProperty(fieldName);
            control.Text = this.ControlSetValue<T>(ref instance, field, control.GetType());
        }
        private dynamic ControlSetValue<T>(ref T instance, PropertyInfo field, Type destinationType)
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
        private void ControlGet<T>(ref T instance, String fieldName, Control control)
        {
            PropertyInfo field = typeof(T).GetProperty(fieldName);
            field.SetValue(instance, this.ControlGetValue(control, field.PropertyType));
        }
        private dynamic ControlGetValue(Control control, Type destinationType)
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
                    try
                    {
                        return int.Parse(control.Text);
                    }
                    catch (FormatException fe)
                    {
                        Debug.ConsoleWriteLine(fe.ToString());
                        return -1;
                    }
                }
            }
            return null;
        }
        #endregion

        protected List<String> GetPropertiesName(Type classType = null)
        {
            classType = classType ?? this.type;
            List <String> propertyNames = new List<String>();
            foreach (var property in classType.BaseType.GetProperties())
            {
                if (!property.PropertyType.Namespace.StartsWith("ProgettoCMA") && !property.PropertyType.IsGenericType)
                {
                    propertyNames.Add(property.Name);
                }
            }
            return propertyNames;
        }
    }
}
