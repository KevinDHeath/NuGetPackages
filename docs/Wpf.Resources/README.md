## About
The Wpf.Resources package contains Windows Desktop resources which can be includes in .NET WPF projects.

See [Change Log](https://github.com/KevinDHeath/NuGetPackages/blob/main/src/Wpf/Resources/README.md) for release notes.

## Key Features
Custom styles for `Buttons`, `CheckBoxes`, `ListViews`, `TabControls`, and `TextBoxes`.

## How to Use
To include the resources in a WPF project:
- Add a reference to the `Common.Wpf.Resources` package.
- Include the required resource dictionaries in the `App.xaml` file.

```xml
<ResourceDictionary>
  <ResourceDictionary.MergedDictionaries>
    <ResourceDictionary Source="pack://application:,,,/Common.Wpf.Resources;component/Themes/Common.xaml"/>
  </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>
```

## Main Types
- `RelayCommand` - Classes to relay functionality to other objects by invoking delegates.
- `ConverterBase` - Base class for `IValueConverter` classes.
- `RuleBase` - Base class for validation rules.

## Feedback
This is provided as open source under the MIT license.\
Bug reports and contributions are welcome [at the GitHub repository](https://github.com/KevinDHeath/NuGetPackages).