using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace PBOManager
{
	public static class PBOM_Localization
	{
		static PBOM_Localization()
		{
		}

		private static ResourceManager InitLocalization()
		{
			try
			{
				CultureInfo culture = new CultureInfo(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);
				Assembly satelliteAssembly = typeof(PBOM_Explorer).Assembly.GetSatelliteAssembly(culture);
				return new ResourceManager("PBOManager.Language", satelliteAssembly);
			}
			catch
			{
				return null;
			}
		}

		public static void LocalizeForm(Form Object)
		{
			ResourceManager resourceManager = InitLocalization();
			if (resourceManager == null)
			{
				return;
			}
			FieldInfo[] fields = ((object)Object).GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);
			FieldInfo[] array = fields;
			foreach (FieldInfo fieldInfo in array)
			{
				PropertyInfo property = fieldInfo.FieldType.GetProperty("Text");
				if (property != null)
				{
					object @object = resourceManager.GetObject($"{fieldInfo.Name}_Text");
					if (@object != null)
					{
						object value = fieldInfo.GetValue(Object);
						if (value != null)
						{
							property.SetValue(value, @object, null);
						}
					}
				}
				property = fieldInfo.FieldType.GetProperty("ToolTipText");
				if (property != null)
				{
					object object2 = resourceManager.GetObject($"{fieldInfo.Name}_ToolTip");
					if (object2 != null)
					{
						object value2 = fieldInfo.GetValue(Object);
						if (value2 != null)
						{
							property.SetValue(value2, object2, null);
						}
					}
				}
				property = fieldInfo.FieldType.GetProperty("HeaderText");
				if (!(property != null))
				{
					continue;
				}
				object object3 = resourceManager.GetObject($"{fieldInfo.Name}_Text");
				if (object3 != null)
				{
					object value3 = fieldInfo.GetValue(Object);
					if (value3 != null)
					{
						property.SetValue(value3, object3, null);
					}
				}
			}
			string @string = resourceManager.GetString(((Control)Object).get_Name());
			if (@string != null)
			{
				((Control)Object).set_Text(@string);
			}
		}

		public static string LocalizeString(string DefaultValue, string PropertyName)
		{
			ResourceManager resourceManager = InitLocalization();
			if (resourceManager != null)
			{
				string @string = resourceManager.GetString(PropertyName);
				if (@string != null)
				{
					return @string;
				}
				return DefaultValue;
			}
			return DefaultValue;
		}
	}
}
