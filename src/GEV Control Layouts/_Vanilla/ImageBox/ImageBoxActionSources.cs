﻿using System;

namespace GEV.Layouts.Vanilla
{
  /// <summary>
  /// Specifies the source of an action being performed.
  /// </summary>
  [Flags]
  public enum ImageBoxActionSources
  {
    /// <summary>
    /// Unknown source.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// A user initialized the action.
    /// </summary>
    User = 1
  }
}
