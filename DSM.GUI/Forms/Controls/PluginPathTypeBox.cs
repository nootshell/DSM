using DSM.API.Extensions;
using DSM.API.Plugins.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSM.GUI.Forms.Controls {

	public class PluginPathTypeBox : ComboBox {

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		new public ObjectCollection Items { get; set; } = new ObjectCollection(null);

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		new public ComboBoxStyle DropDownStyle { get; set; }

		public PluginPathType SelectedType {
			get => ((this.SelectedItem is Item item) ? item.Type : PluginPathType.Unknown);
			set {
				foreach (Item item in base.Items) {
					if (item.Type == value) {
						base.SelectedItem = item;
						break;
					}
				}
			}
		}




		internal class Item {

			public PluginPathType Type { get; private set; }
			public string Display { get; private set; }

			internal Item(MemberInfo member, DescriptionAttribute attribute = null) : base() {
				this.Type = (PluginPathType)Enum.Parse(typeof(PluginPathType), member.Name);

				if (attribute == null) {
					attribute = member.GetAttribute<DescriptionAttribute>(false);
				}
				this.Display = (attribute?.Description ?? member.Name);
			}

			public override string ToString()
				=> this.Display;

		}




		public PluginPathTypeBox() : base() {
			base.Items.Clear();

			DescriptionAttribute attr;
			foreach (MemberInfo member in typeof(PluginPathType).GetMembers(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)) {
				attr = member.GetAttribute<DescriptionAttribute>(false);
				if (attr == null) {
					// TODO: make configurable or something?
					continue;
				}

				_ = base.Items.Add(new Item(member, attr));
			}

			base.DropDownStyle = ComboBoxStyle.DropDownList;
			this.SelectedIndex = 0;
		}

	}

}
