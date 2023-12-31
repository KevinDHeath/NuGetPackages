﻿using System.Windows;
using System.Windows.Controls;

namespace Sample.Controls;

/// <summary>
/// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
///
/// Step 1a) Using this custom control in a XAML file that exists in the current project.
/// Add this XmlNamespace attribute to the root element of the markup file where it is 
/// to be used:
///
///     xmlns:cc="clr-namespace:Controls"
///
///
/// Step 1b) Using this custom control in a XAML file that exists in a different project.
/// Add this XmlNamespace attribute to the root element of the markup file where it is 
/// to be used:
///
///     xmlns:cc="clr-namespace:Controls;assembly=Controls"
///
/// You will also need to add a project reference from the project where the XAML file lives
/// to this project and Rebuild to avoid compilation errors:
///
///     Right click on the target project in the Solution Explorer and
///     "Add Reference"->"Projects"->[Browse to and select this project]
///
///
/// Step 2)
/// Go ahead and use your control in the XAML file.
///
///     <cc:CustomControl1/>
///
/// </summary>
public class CustomControl1 : TextBox
{
	static CustomControl1()
	{
		DefaultStyleKeyProperty.OverrideMetadata( typeof( CustomControl1 ), 
			new FrameworkPropertyMetadata( typeof( CustomControl1 ) ) );
	}

	private Button? _btnOpen = null;

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();

		_btnOpen = GetTemplateChild( "btnOpen" ) as Button;
		if( _btnOpen is not null )
		{
			_btnOpen.Click += BtnOpen_OnClick;
		}
	}

	private int counter;
	private void BtnOpen_OnClick( object sender, RoutedEventArgs e )
	{
		counter++;
		Text += counter.ToString();
	}
}