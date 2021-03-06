﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HighStocks
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TESTODBML")]
	public partial class TESTDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTEST2(TEST2 instance);
    partial void UpdateTEST2(TEST2 instance);
    partial void DeleteTEST2(TEST2 instance);
    partial void InsertTEST(TEST instance);
    partial void UpdateTEST(TEST instance);
    partial void DeleteTEST(TEST instance);
    #endregion
		
		public TESTDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["TESTODBMLConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TESTDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TESTDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TESTDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TESTDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TEST2> TEST2s
		{
			get
			{
				return this.GetTable<TEST2>();
			}
		}
		
		public System.Data.Linq.Table<TEST> TESTs
		{
			get
			{
				return this.GetTable<TEST>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TEST2")]
	public partial class TEST2 : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Program_Name;
		
		private System.DateTime _Start_Date;
		
		private bool _Is_Active;
		
		private System.Nullable<int> _Created_By;
		
		private System.Nullable<System.DateTime> _Created_On;
		
		private System.Nullable<int> _Updated_By;
		
		private System.Nullable<System.DateTime> _Updated_On;
		
		private System.Nullable<System.DateTime> _End_Date;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnProgram_NameChanging(string value);
    partial void OnProgram_NameChanged();
    partial void OnStart_DateChanging(System.DateTime value);
    partial void OnStart_DateChanged();
    partial void OnIs_ActiveChanging(bool value);
    partial void OnIs_ActiveChanged();
    partial void OnCreated_ByChanging(System.Nullable<int> value);
    partial void OnCreated_ByChanged();
    partial void OnCreated_OnChanging(System.Nullable<System.DateTime> value);
    partial void OnCreated_OnChanged();
    partial void OnUpdated_ByChanging(System.Nullable<int> value);
    partial void OnUpdated_ByChanged();
    partial void OnUpdated_OnChanging(System.Nullable<System.DateTime> value);
    partial void OnUpdated_OnChanged();
    partial void OnEnd_DateChanging(System.Nullable<System.DateTime> value);
    partial void OnEnd_DateChanged();
    #endregion
		
		public TEST2()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Program_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Program_Name
		{
			get
			{
				return this._Program_Name;
			}
			set
			{
				if ((this._Program_Name != value))
				{
					this.OnProgram_NameChanging(value);
					this.SendPropertyChanging();
					this._Program_Name = value;
					this.SendPropertyChanged("Program_Name");
					this.OnProgram_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Start_Date", DbType="DateTime2 NOT NULL")]
		public System.DateTime Start_Date
		{
			get
			{
				return this._Start_Date;
			}
			set
			{
				if ((this._Start_Date != value))
				{
					this.OnStart_DateChanging(value);
					this.SendPropertyChanging();
					this._Start_Date = value;
					this.SendPropertyChanged("Start_Date");
					this.OnStart_DateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Is_Active", DbType="Bit NOT NULL")]
		public bool Is_Active
		{
			get
			{
				return this._Is_Active;
			}
			set
			{
				if ((this._Is_Active != value))
				{
					this.OnIs_ActiveChanging(value);
					this.SendPropertyChanging();
					this._Is_Active = value;
					this.SendPropertyChanged("Is_Active");
					this.OnIs_ActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created_By", DbType="Int")]
		public System.Nullable<int> Created_By
		{
			get
			{
				return this._Created_By;
			}
			set
			{
				if ((this._Created_By != value))
				{
					this.OnCreated_ByChanging(value);
					this.SendPropertyChanging();
					this._Created_By = value;
					this.SendPropertyChanged("Created_By");
					this.OnCreated_ByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created_On", DbType="DateTime")]
		public System.Nullable<System.DateTime> Created_On
		{
			get
			{
				return this._Created_On;
			}
			set
			{
				if ((this._Created_On != value))
				{
					this.OnCreated_OnChanging(value);
					this.SendPropertyChanging();
					this._Created_On = value;
					this.SendPropertyChanged("Created_On");
					this.OnCreated_OnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Updated_By", DbType="Int")]
		public System.Nullable<int> Updated_By
		{
			get
			{
				return this._Updated_By;
			}
			set
			{
				if ((this._Updated_By != value))
				{
					this.OnUpdated_ByChanging(value);
					this.SendPropertyChanging();
					this._Updated_By = value;
					this.SendPropertyChanged("Updated_By");
					this.OnUpdated_ByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Updated_On", DbType="DateTime")]
		public System.Nullable<System.DateTime> Updated_On
		{
			get
			{
				return this._Updated_On;
			}
			set
			{
				if ((this._Updated_On != value))
				{
					this.OnUpdated_OnChanging(value);
					this.SendPropertyChanging();
					this._Updated_On = value;
					this.SendPropertyChanged("Updated_On");
					this.OnUpdated_OnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_End_Date", DbType="DateTime")]
		public System.Nullable<System.DateTime> End_Date
		{
			get
			{
				return this._End_Date;
			}
			set
			{
				if ((this._End_Date != value))
				{
					this.OnEnd_DateChanging(value);
					this.SendPropertyChanging();
					this._End_Date = value;
					this.SendPropertyChanged("End_Date");
					this.OnEnd_DateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TEST")]
	public partial class TEST : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Program_Nmae;
		
		private System.DateTime _Start_Date;
		
		private bool _Is_Active;
		
		private System.Nullable<int> _Created_By;
		
		private System.Nullable<System.DateTime> _Created_On;
		
		private System.Nullable<int> _Updated_By;
		
		private System.Nullable<System.DateTime> _Updated_On;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnProgram_NmaeChanging(string value);
    partial void OnProgram_NmaeChanged();
    partial void OnStart_DateChanging(System.DateTime value);
    partial void OnStart_DateChanged();
    partial void OnIs_ActiveChanging(bool value);
    partial void OnIs_ActiveChanged();
    partial void OnCreated_ByChanging(System.Nullable<int> value);
    partial void OnCreated_ByChanged();
    partial void OnCreated_OnChanging(System.Nullable<System.DateTime> value);
    partial void OnCreated_OnChanged();
    partial void OnUpdated_ByChanging(System.Nullable<int> value);
    partial void OnUpdated_ByChanged();
    partial void OnUpdated_OnChanging(System.Nullable<System.DateTime> value);
    partial void OnUpdated_OnChanged();
    #endregion
		
		public TEST()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Program_Nmae", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Program_Nmae
		{
			get
			{
				return this._Program_Nmae;
			}
			set
			{
				if ((this._Program_Nmae != value))
				{
					this.OnProgram_NmaeChanging(value);
					this.SendPropertyChanging();
					this._Program_Nmae = value;
					this.SendPropertyChanged("Program_Nmae");
					this.OnProgram_NmaeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Start_Date", DbType="DateTime2 NOT NULL")]
		public System.DateTime Start_Date
		{
			get
			{
				return this._Start_Date;
			}
			set
			{
				if ((this._Start_Date != value))
				{
					this.OnStart_DateChanging(value);
					this.SendPropertyChanging();
					this._Start_Date = value;
					this.SendPropertyChanged("Start_Date");
					this.OnStart_DateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Is_Active", DbType="Bit NOT NULL")]
		public bool Is_Active
		{
			get
			{
				return this._Is_Active;
			}
			set
			{
				if ((this._Is_Active != value))
				{
					this.OnIs_ActiveChanging(value);
					this.SendPropertyChanging();
					this._Is_Active = value;
					this.SendPropertyChanged("Is_Active");
					this.OnIs_ActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created_By", DbType="Int")]
		public System.Nullable<int> Created_By
		{
			get
			{
				return this._Created_By;
			}
			set
			{
				if ((this._Created_By != value))
				{
					this.OnCreated_ByChanging(value);
					this.SendPropertyChanging();
					this._Created_By = value;
					this.SendPropertyChanged("Created_By");
					this.OnCreated_ByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created_On", DbType="DateTime")]
		public System.Nullable<System.DateTime> Created_On
		{
			get
			{
				return this._Created_On;
			}
			set
			{
				if ((this._Created_On != value))
				{
					this.OnCreated_OnChanging(value);
					this.SendPropertyChanging();
					this._Created_On = value;
					this.SendPropertyChanged("Created_On");
					this.OnCreated_OnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Updated_By", DbType="Int")]
		public System.Nullable<int> Updated_By
		{
			get
			{
				return this._Updated_By;
			}
			set
			{
				if ((this._Updated_By != value))
				{
					this.OnUpdated_ByChanging(value);
					this.SendPropertyChanging();
					this._Updated_By = value;
					this.SendPropertyChanged("Updated_By");
					this.OnUpdated_ByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Updated_On", DbType="DateTime")]
		public System.Nullable<System.DateTime> Updated_On
		{
			get
			{
				return this._Updated_On;
			}
			set
			{
				if ((this._Updated_On != value))
				{
					this.OnUpdated_OnChanging(value);
					this.SendPropertyChanging();
					this._Updated_On = value;
					this.SendPropertyChanged("Updated_On");
					this.OnUpdated_OnChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
