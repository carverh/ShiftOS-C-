using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftUI;
using System.Reflection;
using System.Drawing;

namespace ShiftOS.Controls
{
    class WinFormsHost : Widget
    {
        private System.Windows.Forms.Control guest = null;

        /// <summary>
        /// Creates a new Windows Forms host that will host the given control.
        /// </summary>
        /// <param name="ctrl">The control to use.</param>
        public WinFormsHost(System.Windows.Forms.Control ctrl)
        {
            guest = ctrl;
            ScanProperties();
        }

        /// <summary>
        /// Scan the guest for any properties that this widget contains, and set our properties to the ShiftUI equivalent.
        /// </summary>
        private void ScanProperties()
        {
            var guest_properties = guest.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var host_properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var valid_types = new Type[] { typeof(string), typeof(int), typeof(Size), typeof(Point), typeof(Font), typeof(Color), typeof(bool) };

            var guest_names = new Dictionary<string, PropertyInfo>();
            var host_names = new Dictionary<string, PropertyInfo>();

            foreach(var property in guest_properties)
            {
                if (!property.CanWrite || !property.CanRead)
                    continue; //We want to be able to read and write from and to the property...

                if (!valid_types.Contains(property.PropertyType) || !property.PropertyType.IsEnum)
                    continue; //Need to be valid propertytype...

                guest_names.Add(property.Name, property); //Add to the guest dictionary for easy access.
            }

            //Now let's do the same for our host.
            foreach (var property in host_properties)
            {
                if (!property.CanWrite || !property.CanRead)
                    continue; //We want to be able to read and write from and to the property...

                if (!valid_types.Contains(property.PropertyType) || !property.PropertyType.IsEnum)
                    continue; //Need to be valid propertytype...

                host_names.Add(property.Name, property); //Add to the guest dictionary for easy access.
            }

            //Cool. Properties scanned. Let's set our properties to the guest's!
            foreach(var property in host_names)
            {
                if(guest_names.ContainsKey(property.Key))
                {
                    var p = guest_names[property.Key];
                    if(p.PropertyType.IsEnum)
                    {
                        //If it's an enum, convert it to an integer value
                        //so that Reflection won't yell at us.

                        var value = p.GetValue(guest); //Get the guest's value of this property
                        int value_int = (int)value;
                        property.Value.SetValue(this, value_int);
                    }
                    else
                    {
                        var value = p.GetValue(guest);
                        property.Value.SetValue(this, value);
                    }
                }
            }
        }
    }
}
