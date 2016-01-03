using System;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.Reflection;
using System.Xml;
using Microsoft.Win32;

using Xceed.Wpf.DataGrid.Views;

namespace NeginProject.Themes
{
  public static class ViewImportExportManager
  {
    public static string AskForExportFileName()
    {
      string fileName = "";
      SaveFileDialog saveDialog = new SaveFileDialog();

      saveDialog.AddExtension = true;
      saveDialog.CheckPathExists = true;
      saveDialog.DefaultExt = "xaml";
      saveDialog.Filter = "Resource dictionary (*.xaml)|*.xaml";
      saveDialog.OverwritePrompt = true;
      saveDialog.Title = "Export View Settings";
      saveDialog.ValidateNames = true;

      if( saveDialog.ShowDialog().GetValueOrDefault() )
        fileName = saveDialog.FileName;

      return fileName;
    }

    public static void ExportView( ViewBase view )
    {
      if( view == null )
        throw new ArgumentNullException( "view" );

      string fileName = ViewImportExportManager.AskForExportFileName();

      if( fileName.Length > 0 )
        ViewImportExportManager.ExportViewToXaml( view, fileName );
    }

    public static void ExportViewToXaml( ViewBase view, string fileName )
    {
      if( view == null )
        throw new ArgumentNullException( "view" );

      object value;
      DependencyProperty dp;
      ResourceDictionary resourceDictionary = new ResourceDictionary();
      Type viewType = view.GetType();
      Style viewStyle = new Style( viewType );

      foreach( FieldInfo fieldInfo in viewType.GetFields( BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static ) )
      {
        dp = fieldInfo.GetValue( view ) as DependencyProperty;

        if( dp != null )
        {
          value = view.ReadLocalValue( dp );

          if( value != DependencyProperty.UnsetValue )
            viewStyle.Setters.Add( new Setter( dp, value ) );
        }
      }

      resourceDictionary.Add( viewType, viewStyle );

      XmlWriterSettings settings = new XmlWriterSettings();
      settings.Indent = true;
      settings.OmitXmlDeclaration = true;

      using( XmlWriter xmlWriter = XmlWriter.Create( fileName, settings ) )
      {
        XamlWriter.Save( resourceDictionary, xmlWriter );
      }
    }

    public static ResourceDictionary AskForResourceDictionary()
    {
      OpenFileDialog openDialog = new OpenFileDialog();
      ResourceDictionary resourceDictionary = null;

      openDialog.AddExtension = false;
      openDialog.CheckFileExists = true;
      openDialog.DefaultExt = "xaml";
      openDialog.Filter = "Resource dictionary (*.xaml)|*.xaml";
      openDialog.Multiselect = false;
      openDialog.ShowReadOnly = false;
      openDialog.Title = "Import View Settings";
      openDialog.ValidateNames = true;

      if( openDialog.ShowDialog().GetValueOrDefault() )
      {
        using( StreamReader streamReader = new StreamReader( openDialog.FileName ) )
        {
          resourceDictionary = XamlReader.Load( streamReader.BaseStream ) as ResourceDictionary;
        }
      }

      return resourceDictionary;
    }

    public static void ImportView( ViewBase view )
    {
      if( view == null )
        throw new ArgumentNullException( "view" );

      ResourceDictionary resourceDictionary = ViewImportExportManager.AskForResourceDictionary();

      if( resourceDictionary != null )
        ViewImportExportManager.ImportViewFromResourceDictionary( view, resourceDictionary );
    }

    // In a typical application, this way of applying a style would be undesirable. The 
    // style would rather simply be added to a ResourceDictionary as implicit.
    // Here, we want to set all CardflowView3D properties so that the ConfigurationPanel
    // reflects them.
    public static void ImportViewFromStyle( ViewBase view, Style viewStyle )
    {
      if( view == null )
        throw new ArgumentNullException( "view" );

      // Remove the local values on the CardflowView3D so that the newly selected preset
      // is applied in its entirety. The properties set in a style have a priority less 
      // than a local value (set by the various sliders and checkboxes).
      ViewImportExportManager.ClearViewPropertyValues( view );

      if( viewStyle != null )
      {
        foreach( Setter setter in viewStyle.Setters )
        {
          view.SetValue( setter.Property, setter.Value );
        }
      }
    }

    public static void ImportViewFromResourceDictionary( ViewBase view, ResourceDictionary resourceDictionary )
    {
      if( view == null )
        throw new ArgumentNullException( "view" );

      if( resourceDictionary == null )
        throw new ArgumentNullException( "resourceDictionary" );

      Type viewType = view.GetType();

      // Try extracting a implicit style for the specified view from the ResourceDictionary.
      Style viewStyle = resourceDictionary[ viewType ] as Style;

      if( viewStyle == null )
      {
        // There is no implicit style for the specified view in the ResourceDictionary. 
        // Use the first Style having the view type as TargetType.
        Style tempStyle;

        foreach( object value in resourceDictionary.Values )
        {
          tempStyle = value as Style;

          if( ( tempStyle != null ) && ( tempStyle.TargetType == viewType ) )
          {
            viewStyle = tempStyle;
            break;
          }
        }
      }

      ViewImportExportManager.ImportViewFromStyle( view, viewStyle );
    }

    private static void ClearViewPropertyValues( ViewBase view )
    {
      if( view == null )
        throw new ArgumentNullException( "view" );

      DependencyProperty dp;

      foreach( FieldInfo fieldInfo in view.GetType().GetFields( BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static ) )
      {
        dp = fieldInfo.GetValue( view ) as DependencyProperty;

        if( dp != null )
          view.ClearValue( dp );
      }
    }
  }
}
