## About
The Wpf.Controls package contains classes to create elements, known as controls, that enables a user to interact with an application.

See [Change Log](https://github.com/KevinDHeath/NuGetPackages/blob/main/src/Wpf/Controls/README.md) for all release notes.

## Key Features
Custom controls for user interface elements such as `ComboBoxes`, `DatePickers` and `TextBoxes`.

## Main Types
- `ComboBox` - Extension to the System.Windows.Controls.ComboBox class.
- `DatePicker` - Extension to the System.Windows.Controls.DatePicker class.
- `FilePathTextBox` - Control to implement the selection of a file or folder for a TextBox.
- `HamburgerMenu` - Control to implement the Hamburger style menu _(or Navigation Drawer)_ control.
- `ModalDialog` - Control to implement a modal dialog for displaying User Controls.
- `NumericSpinner` - Control to implement the ability to increase and decrease numeric values using a 'NumericUpDown' style control.
- `PasswordBoxExtend` - Extends the `PasswordBox` control to allow binding of the `Password` property.
- `SearchTextBox` - Control to implement the entry of search criteria in a TextBox.
- `SortableListView` - Control to implement the sorting and filtering of a ListView.

See [WPF Packages](https://kevindheath.github.io/shfb/html/N_Common_Wpf_Controls.htm) for technical documentation.

## How to Use
To include the controls in a WPF project:
- Add a reference to the `Common.Wpf.Controls` package.
- Include the required controls in a `.xaml` file.

```xml
xmlns:cc="clr-namespace:Common.Wpf.Controls;assembly=Common.Wpf.Controls"
'''
<cc:NumericSpinner Step="2" ... />
```

## Feedback
This is provided as open source under the MIT license.\
Bug reports and contributions are welcome in the [GitHub repository](https://github.com/KevinDHeath/NuGetPackages/issues).