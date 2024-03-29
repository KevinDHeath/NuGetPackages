﻿// Ignore Spelling: Naics Bal

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using Common.Core.Classes;
using Common.Core.Converters;
using Common.Core.Interfaces;

namespace Common.Core.Models;

/// <summary>This class contains details of a Company.</summary>
public class Company : ModelEdit, ICompany
{
	/// <summary>Default name of the Company data file.</summary>
	public const string cDefaultFile = "Company.json";

	#region Private Variables

	private int _id;
	private string? _name;
	private Address _address = new();
	private string? _governmentNumber;
	private string? _primaryPhone;
	private string? _secondaryPhone;
	private string? _email;
	private string? _naicsCode;
	private bool? _private;
	private int? _depositsCount;
	private decimal? _depositsBal;

	#endregion

	#region ICompany Properties

	/// <inheritdoc/>
	public override int Id
	{
		get => _id;
		set
		{
			if( value != _id )
			{
				_id = value;
				OnPropertyChanged( nameof( Id ) );
			}
		}
	}

	/// <inheritdoc/>
	[Required]
	[MaxLength( 100 )]
	public string Name
	{
		get => ( _name is not null ) ? _name : string.Empty;
		set
		{
			if( !value.Equals( _name ) )
			{
				_name = value;
				OnPropertyChanged( nameof( Name ) );
			}
		}
	}

	/// <inheritdoc/>
	public Address Address
	{
		get => _address;
		set
		{
			if( value != _address )
			{
				_address = value;
				OnPropertyChanged( nameof( Address ) );
			}
		}
	}

	/// <inheritdoc/>
	[MaxLength( 50 )]
	[JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
	public string? GovernmentNumber
	{
		get => _governmentNumber;
		set
		{
			if( value != _governmentNumber )
			{
				_governmentNumber = SetNullString( value );
				OnPropertyChanged( nameof( GovernmentNumber ) );
			}
		}
	}

	/// <inheritdoc/>
	[MaxLength( 50 )]
	[JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
	public string? PrimaryPhone
	{
		get => _primaryPhone;
		set
		{
			if( value != _primaryPhone )
			{
				_primaryPhone = SetNullString( value );
				OnPropertyChanged( nameof( PrimaryPhone ) );
			}
		}
	}

	/// <inheritdoc/>
	[MaxLength( 50 )]
	[JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
	public string? SecondaryPhone
	{
		get => _secondaryPhone;
		set
		{
			if( value != _secondaryPhone )
			{
				_secondaryPhone = SetNullString( value );
				OnPropertyChanged( nameof( SecondaryPhone ) );
			}
		}
	}

	/// <inheritdoc/>
	[MaxLength( 50 )]
	[JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
	public string? Email
	{
		get => _email;
		set
		{
			if( value != _email )
			{
				_email = SetNullString( value );
				OnPropertyChanged( nameof( Email ) );
			}
		}
	}

	/// <inheritdoc/>
	[MaxLength( 20 )]
	[JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
	public string? NaicsCode
	{
		get => _naicsCode;
		set
		{
			if( value != _naicsCode )
			{
				_naicsCode = SetNullString( value );
				OnPropertyChanged( nameof( NaicsCode ) );
			}
		}
	}

	/// <inheritdoc/>
	[Column( TypeName = "char(1)" )]
	[JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
	[JsonConverter( typeof( JsonBooleanString ) )]
	public bool? Private
	{
		get => _private;
		set
		{
			if( value != _private )
			{
				_private = value;
				OnPropertyChanged( nameof( Private ) );
			}
		}
	}

	/// <inheritdoc/>
	[Range( 0, 100 )]
	[JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
	[JsonConverter( typeof( JsonIntegerString ) )]
	public int? DepositsCount
	{
		get => _depositsCount;
		set
		{
			if( value != _depositsCount )
			{
				_depositsCount = value;
				OnPropertyChanged( nameof( DepositsCount ) );
			}
		}
	}

	/// <inheritdoc/>
	[Column( TypeName = "decimal(18,2)" )]
	[JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
	[JsonConverter( typeof( JsonDecimalString ) )]
	public decimal? DepositsBal
	{
		get => _depositsBal;
		set
		{
			if( value != _depositsBal )
			{
				_depositsBal = value;
				OnPropertyChanged( nameof( DepositsBal ) );
			}
		}
	}

	#endregion

	#region Public Methods

	/// <inheritdoc/>
	public override object Clone()
	{
		return ReflectionHelper.CreateDeepCopy( this ) as Company ?? new Company();
	}

	/// <inheritdoc/>
	/// <param name="obj">An object implementing the ICompany interface to compare with this object.</param>
	public override bool Equals( object? obj )
	{
		if( obj is null || obj is not ICompany other ) { return false; }
		return ReflectionHelper.IsEqual( this, other );
	}

	/// <inheritdoc/>
	/// <param name="obj">An object implementing the ICompany interface with the changed values.</param>
	public override void Update( object? obj )
	{
		if( obj is null || obj is not ICompany other || other is not Company company ) { return; }

        ReflectionHelper.ApplyChanges( company, this );
	}

	/// <summary>Gets the Json serializer options for Company objects.</summary>
	/// <returns>A JsonSerializerOptions object.</returns>
	public static JsonSerializerOptions GetSerializerOptions()
	{
		var rtn = JsonHelper.DefaultSerializerOptions();
		rtn.Converters.Add( new InterfaceFactory( typeof( Company ), typeof( ICompany ) ) );
		rtn.NumberHandling = JsonNumberHandling.AllowReadingFromString;

		return rtn;
	}

	/// <summary>Builds a Company object from a database table row.</summary>
	/// <param name="row">Database row containing the Company columns.</param>
	/// <param name="addPrefix">Table column prefix for Address fields if required.</param>
	/// <returns>Company object containing the database values.</returns>
	/// <remarks>This method assumes that the table column names are the same as the property names.</remarks>
	public static Company Read( DataRow row, string addPrefix = "" )
	{
		return new Company()
		{
			Id = row.Field<int>( nameof( Id ) ),
			Name = row.Field<string>( nameof( Name ) )!,
			Address = Address.BuildAddress( row, addPrefix ),
			GovernmentNumber = row.Field<string?>( nameof( GovernmentNumber ) ),
			PrimaryPhone = row.Field<string?>( nameof( PrimaryPhone ) ),
			SecondaryPhone = row.Field<string?>( nameof( SecondaryPhone ) ),
			Email = row.Field<string?>( nameof( Email ) ),
			NaicsCode = row.Field<string?>( nameof( NaicsCode ) ),
			Private = Generic.CharToBool( row[nameof( Private )] ),
			DepositsCount = row.Field<int?>( nameof( DepositsCount ) ),
			DepositsBal = row.Field<decimal?>( nameof( DepositsBal ) ),
		};
	}

	/// <summary>Builds the SQL script for any value changes.</summary>
	/// <param name="row">Database row containing the current Company data.</param>
	/// <param name="obj">ICompany object containing the original values.</param>
	/// <param name="mod">ICompany object containing the modified values.</param>
	/// <param name="addPrefix">Table column name prefix for Address fields (if required).</param>
	/// <returns>An empty string is returned if no changes were found.</returns>
	/// <remarks>This method assumes that the table column names are the same as the property names.</remarks>
	public static string UpdateSQL( DataRow row, ICompany obj, ICompany mod, string addPrefix = "" )
	{
		IList<string> sql = new List<string>();
		Company cur = Read( row, addPrefix );
		if( cur.Id != mod.Id ) { return string.Empty; }

		if( !cur.Equals( obj ) )
		{
			mod.Name = cur.Name;
			mod.Address = cur.Address;
			mod.GovernmentNumber = cur.GovernmentNumber;
			mod.PrimaryPhone = cur.PrimaryPhone;
			mod.SecondaryPhone = cur.SecondaryPhone;
			mod.Email = cur.Email;
			mod.NaicsCode = cur.NaicsCode;
			mod.DepositsCount = cur.DepositsCount;
			mod.DepositsBal = cur.DepositsBal;
			mod.Private = cur.Private;
			return string.Empty;
		}

		if( obj.Name != mod.Name ) { SetSQLColumn( nameof( Name ), mod.Name, sql ); }
		_ = Address.UpdateAddress( obj.Address, mod.Address, cur.Address, sql, addPrefix );
		UpdateOthers( obj, mod, sql );
		if( obj.Private != mod.Private )
		{
			// Special handling for boolean as char
			char? val = mod.Private is null ? null : mod.Private.Value ? 'Y' : 'N';
			SetSQLColumn( nameof( Private ), val, sql );
		}

		return string.Join( ", ", sql );
	}

	#endregion

	private static void UpdateOthers( ICompany obj, ICompany mod, IList<string> sql )
	{
		if( obj.GovernmentNumber != mod.GovernmentNumber ) { SetSQLColumn( nameof( GovernmentNumber ), mod.GovernmentNumber, sql ); }
		if( obj.PrimaryPhone != mod.PrimaryPhone ) { SetSQLColumn( nameof( PrimaryPhone ), mod.PrimaryPhone, sql ); }
		if( obj.SecondaryPhone != mod.SecondaryPhone ) { SetSQLColumn( nameof( SecondaryPhone ), mod.SecondaryPhone, sql ); }
		if( obj.Email != mod.Email ) { SetSQLColumn( nameof( Email ), mod.Email, sql ); }
		if( obj.NaicsCode != mod.NaicsCode ) { SetSQLColumn( nameof( NaicsCode ), mod.NaicsCode, sql ); }
		if( obj.DepositsCount != mod.DepositsCount ) { SetSQLColumn( nameof( DepositsCount ), mod.DepositsCount.ToString(), sql ); }
		if( obj.DepositsBal != mod.DepositsBal ) { SetSQLColumn( nameof( DepositsBal ), mod.DepositsBal.ToString(), sql ); }
	}
}