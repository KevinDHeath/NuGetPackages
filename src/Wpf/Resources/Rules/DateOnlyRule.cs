﻿// Ignore Spelling: Rqd

using System.Globalization;
using System.Windows.Controls;
using Common.Wpf.Converters;

namespace Common.Wpf.Rules;

/// <summary>Validation rule for date only values.</summary>
public class DateOnlyRule : RuleBase
{
	#region Properties

	/// <summary>Indicates if a value is required. The default is <see langword="false"/>.</summary>
	public bool Rqd { get; set; }

	#endregion

	/// <inheritdoc/>
	public override ValidationResult Validate( object value, CultureInfo cultureInfo )
	{
		if( value is null ) // Handle null value
		{
			if( Rqd ) { return new ValidationResult( false, cEnterValue ); }
			else { return ValidationResult.ValidResult; }
		}

		if( value is string str ) // Handle RawProposedValue
		{
			if( Rqd && string.IsNullOrWhiteSpace( str ) )
			{ return new ValidationResult( false, cEnterValue ); }

			str = str.Trim();
			bool ok = StringConverter.TryParse( ref str, out DateOnly _, cultureInfo );
			if( !ok ) { return new ValidationResult( false, cEnterDate ); }
		}

		return ValidationResult.ValidResult;
	}
}