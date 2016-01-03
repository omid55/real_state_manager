using System;
using System.Windows;
using System.Windows.Media;

namespace NeginProject
{
  public class PresetItem
  {
    public string Description
    {
      get;
      set;
    }

    public ResourceDictionary ResourceDictionary
    {
      get;
      set;
    }

    public Brush PreferredDataGridBackgroundBrush
    {
      get;
      set;
    }
  }
}
