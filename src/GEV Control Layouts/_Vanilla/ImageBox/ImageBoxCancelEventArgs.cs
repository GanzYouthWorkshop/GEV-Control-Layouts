using System.ComponentModel;
using System.Drawing;

namespace GEV.Layouts.Vanilla
{
  /// <summary>
  /// Provides data for a cancelable event.
  /// </summary>
  public class ImageBoxCancelEventArgs : CancelEventArgs
  {
    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ImageBoxCancelEventArgs"/> class.
    /// </summary>
    /// <param name="location">The location of the action being performed.</param>
    public ImageBoxCancelEventArgs(Point location)
      : this()
    {
      this.Location = location;
    }

    #endregion

    #region Protected Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ImageBoxCancelEventArgs"/> class.
    /// </summary>
    protected ImageBoxCancelEventArgs()
    { }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the location of the action being performed.
    /// </summary>
    /// <value>The location of the action being performed.</value>
    public Point Location { get; protected set; }

    #endregion
  }
}
